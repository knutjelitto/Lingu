using System;
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
        public static T TimeBoth<T>(string msg, Func<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var watch = new Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            var e1 = watch.ElapsedTicks;
            Console.WriteLine($"{msg}    (cold): {watch.Elapsed}");

            var max = 5;
            T result;
            for (var i = 0; i < max; ++i)
            {
                watch.Restart();
                result = action();
                watch.Stop();
                var e2 = watch.ElapsedTicks;
                Console.WriteLine($"{msg} (warmed{i}): {watch.Elapsed} (x{e1 / e2})");

                if (i == max - 1)
                {
                    return result;
                }
            }

            throw new NotImplementedException();
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
