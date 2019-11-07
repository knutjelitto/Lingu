using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lipeg.SDK.Common
{
    public static class Timer
    {
        public static T Time<T>(string msg, Func<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var watch = new Stopwatch();
            watch.Start();
            var result = action();
            watch.Stop();
            Console.WriteLine($"{msg}: {watch.Elapsed}");
            return result;
        }
        public static T TimeBoth<T>(int megs, string msg, Func<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var watch = new Stopwatch();

            var max = 5;
            List<(long, TimeSpan)> elapsed = new List<(long, TimeSpan)>();
            T result = Run();
            for (var i = 0; i < max; ++i)
            {
                result = Run();
            }

            T Run()
            {
                GC.TryStartNoGCRegion((long)megs * 1024 * 1024);
                watch.Restart();
                var result = action();
                watch.Stop();
                GC.EndNoGCRegion();
                GC.Collect(3, GCCollectionMode.Forced, true, true);
                elapsed.Add((watch.ElapsedTicks, watch.Elapsed));
                return result;
            }

            var e1 = elapsed[0].Item1;
            for (var i = 0; i < elapsed.Count; ++i)
            {
                var what = i == 0 ? "   cold" : $"warmed{i}";

                var timers = elapsed[i];

                Console.WriteLine($"{msg} ({what}): {timers.Item2} (x{e1 / timers.Item1})");
            }

            Debug.Assert(result != null);
            return result;
        }
        public static void Time(string msg, Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var watch = new Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            Console.WriteLine($"{msg}: {watch.Elapsed}");
        }
    }
}
