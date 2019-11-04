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
        public static T TimeBoth<T>(int megs, string msg, Func<T> action) where T: class
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var watch = new Stopwatch();
            GC.TryStartNoGCRegion((long)megs * 1024 * 1024);
            watch.Start();
            action();
            watch.Stop();
            GC.EndNoGCRegion();
            GC.Collect(3, GCCollectionMode.Forced, true, true);
            var e1 = watch.ElapsedTicks;
            Console.WriteLine($"{msg}    (cold): {watch.Elapsed}");

            var max = 5;
            T? result = null;
            List<(long, TimeSpan)> elapsed = new List<(long, TimeSpan)>();
            for (var i = 0; i < max; ++i)
            {
                GC.TryStartNoGCRegion((long)megs * 1024 * 1024);
                watch.Restart();
                result = action();
                watch.Stop();
                GC.EndNoGCRegion();
                GC.Collect(3, GCCollectionMode.Forced, true, true);
                elapsed.Add((watch.ElapsedTicks, watch.Elapsed));
            }
            for (var i = 0; i < max; ++i)
            {
                var timers = elapsed[i];

                Console.WriteLine($"{msg} (warmed{i}): {timers.Item2} (x{e1 / timers.Item1})");
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
