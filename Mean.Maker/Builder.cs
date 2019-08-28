using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Mean.Maker.Builders;

namespace Mean.Maker
{
    public class Builder
    {
        public Builder()
        {
            Mingw = new MingwRunner();
            ObjConv = new ObjConvRunner();
            Llvm = new LlvmRunner();
        }

        public static readonly string BuildTop = @"D:/MeanBuild";

        private MingwRunner Mingw { get; }
        private LlvmRunner Llvm { get; }
        private ObjConvRunner ObjConv { get; }

        public bool BuildTheDemo()
        {
            Directory.SetCurrentDirectory(BuildTop);

            var capture = BuildDemo();

            return capture.IsOk;
        }

        public Func<Capture> RunAny(FileRef file, string arguments = "")
        {
            var description = $"run {file}";
            return () => Mingw.Any(description, file, arguments);
        }

        public Func<Capture> DisAsm(FileRef file)
        {
            var description = $"disasm {file} => {file}.nasm";
            return () => ObjConv.ObjConv(description, $"-v0 -fnasm {file} {file}.nasm");
        }

        public Func<Capture> GccOne(FileRef entry)
        {
            var from = entry.C;
            var to = entry.Dst.Obj;

            if (from.NewerThan(to))
            {
                var arguments =
                    $"-c " +
                    $"-O0 " +
                    $"-I{Mingw.Include} " +
                    $"-x c " +
                    $"{from} " +
                    $"-o {to} " +
                    "";

                var description = $"compile {from} => {to}";

                return () => Mingw.GCC(description, arguments);
            }

            return () => Capture.Ok;
        }

        public Func<Capture> GccLinkStandalone(FileRef mainObj, params FileRef[] objs)
        {
            var sources = string.Join(" ", objs.Select(sourceFile => sourceFile.Obj));

            var arguments =
                $"{mainObj.Obj} " +
                $"{sources} " +
                $"-mconsole " +
                $"-nostdlib " +
                $"--entry=Entry " +
                $"-L{Mingw.Lib} " +
                $"-lkernel32 " +
                $"-lgcc " +
                $"-o {mainObj.Exe} " +
                "";

            var description = $"link {mainObj.Obj} {sources} => {mainObj.Exe}";
            return () => Mingw.GCC(description, arguments);
        }

        public Func<Capture> GccLinkClib(FileRef mainObj, params FileRef[] objs)
        {
            var output = mainObj.Exe;

            //var mustBuild = objs.Concat(Enumerable.Repeat(mainObj.Obj, 1))
            //    .Any(obj => obj.NewerThan(output));

            var mustBuild = true;

            if (mustBuild)
            {
                var objNames = string.Join(" ", objs.Select(sourceFile => sourceFile.Obj));

                var arguments =
                    $"{mainObj.Obj} " +
                    $"{objNames} " +
                    $"-mconsole " +
                    //$"-nostdlib " +
                    //$"--entry=Entry " +
                    $"-L{Mingw.Lib} " +
                    //$"-lkernel32 " +
                    //$"-lgcc " +
                    $"-o {output} " +
                    "";

                var description = $"link {mainObj.Obj} {objNames} => {mainObj.Exe}";
                return () => Mingw.GCC(description, arguments);
            }

            return () => Capture.Ok;
        }


        public Func<Capture> ClangLL(FileRef entry)
        {
            var from = entry.C;
            var to = entry.Dst.LL;

            if (from.NewerThan(to))
            {
                var arguments =
                    $"-S " +
                    $"-O0 " +
                    $"-emit-llvm " +
                    $"-I{Llvm.Include} " +
                    $"-x c " +
                    $"{from} " +
                    $"-o {to} " +
                    "";

                var description = $"compile {from} => {to}";

                return () => Llvm.Clang(description, arguments);
            }

            return () => Capture.Ok;
        }

        public Capture BuildInSequence(params Func<Capture>[] buildSteps)
        {
            var capture = Capture.Ok;

            foreach (var buildStep in buildSteps)
            {
                capture = buildStep();
                if (!capture.IsOk)
                {
                    break;
                }
            }

            return capture;
        }

        private Capture BuildDemo()
        {
            var entry = FileRef.Source($"ccore/Entry.c");
            var coreObject = FileRef.Source($"ccore/CoreObject.c");
            var coreString = FileRef.Source($"ccore/CoreString.c");
            var coreConsole = FileRef.Source($"ccore/CoreConsole.c");

            return BuildInSequence(
                GccOne(entry), DisAsm(entry.Dst.Obj),
                GccOne(coreObject), DisAsm(coreObject.Dst.Obj),
                GccOne(coreString), DisAsm(coreString.Dst.Obj),
                GccOne(coreConsole), DisAsm(coreConsole.Dst.Obj),
                GccLinkStandalone(entry.Dst.Obj, coreObject.Dst.Obj, coreString.Dst.Obj, coreConsole.Dst.Obj),
                DisAsm(entry.Dst.Exe),
                () => Mingw.Any("running", entry.Dst.Exe, string.Empty));
        }
    }
}
