﻿using System;
using System.Diagnostics;

namespace Lipeg.Runtime.Tools
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

        public static T Time<T>(string msg, ref TimeSpan accu, Func<T> action)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = action();
            watch.Stop();
            accu = accu.Add(watch.Elapsed);
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
