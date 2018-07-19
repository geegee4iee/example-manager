using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public static class StopwatchUtil
    {
        public static TimeSpan Time(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }

        public static long TimeInMicroSecond(Action action)
        {
            var timespan = Time(action);
            long microseconds = timespan.Ticks / (TimeSpan.TicksPerMillisecond / 1000);

            return microseconds;
        }

        public static long ConvertToMicroSeconds(this TimeSpan timespan)
        {
            long microseconds = timespan.Ticks / (TimeSpan.TicksPerMillisecond / 1000);

            return microseconds;
        }

        public static int ConvertToMiliSeconds(this int microseconds)
        {
            int miniseconds = microseconds / 1000;

            return miniseconds;
        }
    }
}
