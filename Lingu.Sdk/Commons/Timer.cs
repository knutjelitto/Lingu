using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lingu.Commons
{
    public static class Timer
    {
        public static T Time<T>(string msg, Func<T> action)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = action();
            watch.Stop();
            Console.WriteLine($"{msg}: {watch.Elapsed}");
            return result;
        }
        public static void Time(string msg, Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            Console.WriteLine($"{msg}: {watch.Elapsed}");
        }
    }
}
