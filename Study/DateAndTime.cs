using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Study
{
    internal class DateAndTime
    {
        public static void DateTimeMethods()
        {
            Console.WriteLine(DateTime.MinValue);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.UtcNow);
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.Now.Day+"\t"+DateTime.Now.DayOfWeek+"\t"+DateTime.Now.DayOfYear);
            Console.WriteLine(DateTime.MaxValue);
            

            DateTime date = new DateTime(2022, 11, 25);
            Console.WriteLine(date);

            DateTime date1 = new DateTime(2021, 10, 8, 22, 11, 15, 5);
            Console.WriteLine(date1);
            Console.WriteLine();
            DateTime date2 = new DateTime(2022, 7, 20, 18, 30, 35);
            Console.WriteLine(date2.ToFileTime());
            Console.WriteLine(date2.ToLongDateString());
            Console.WriteLine(date2.ToLongTimeString());
            Console.WriteLine(date2.ToOADate());
            Console.WriteLine(date2.ToShortDateString());
            Console.WriteLine(date2.ToShortTimeString());
        }
        public static void FormatDay()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine($"D: {date.ToString("D")}");
            Console.WriteLine($"d: {date.ToString("d")}");
            Console.WriteLine($"F: {date.ToString("F")}");
            Console.WriteLine($"f: {date:f}");
            Console.WriteLine($"G: {date:G}");
            Console.WriteLine($"g: {date:g}");
            Console.WriteLine($"M: {date:M}");
            Console.WriteLine($"O: {date:O}");
            Console.WriteLine($"o: {date:o}");
            Console.WriteLine($"R: {date:R}");
            Console.WriteLine($"s: {date:s}");
            Console.WriteLine($"T: {date:T}");
            Console.WriteLine($"t: {date:t}");
            Console.WriteLine($"U: {date:U}");
            Console.WriteLine($"u: {date:u}");
            Console.WriteLine($"Y: {date:Y}");
            Console.WriteLine(date.ToString("yyyy MMMM dddd gg"));
        }
        public static void Only()
        {
            DateOnly date = new DateOnly(2022, 8, 16);
            Console.WriteLine(date);
            Console.WriteLine(date.Day);
            Console.WriteLine(date.Month);
            Console.WriteLine(date.Year);
            Console.WriteLine(date.DayNumber);
            Console.WriteLine(date.DayOfWeek);
            Console.WriteLine(date.DayOfYear);
            Console.WriteLine(date.ToShortDateString());
            Console.WriteLine(date.ToLongDateString());
            Console.WriteLine();
            Console.WriteLine();
            TimeOnly time = TimeOnly.MaxValue;
            Console.WriteLine(time.Hour);
            Console.WriteLine(time.Minute);
            Console.WriteLine(time.Second);
            Console.WriteLine(time.Millisecond);
            Console.WriteLine(time.ToShortTimeString());
            Console.WriteLine(time.ToLongTimeString());
        }
    }
}
