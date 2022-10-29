using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Study
{
    internal class NetClasses
    {
        public static void Lazy()
        {
            Reader reader = new Reader();
            reader.ReadEbook();
            reader.ReadBook();
        }
        public static void ClassMath()
        {
            double result = Math.Abs(-12.5);
            double result1 = Math.Acos(1);
            double result2 = Math.Asin(1);
            double result3 =Math.Atan(1);
            double result4 = Math.BigMul(100, 9340);
            double result5 = Math.Ceiling(2.34);
            double result6 = Math.Cos(1);
            double result7 = Math.Cosh(1);
            double result8 = Math.DivRem(10, 3, out int res);
            double result9 = Math.Exp(2.34);
            double result10 = Math.Floor(2.56);
            double result11 = Math.IEEERemainder(26, 4);
            double result12 = Math.Log(10);
            double result13 = Math.Log(10, 5);
            double result14 = Math.Log10(10);
            double result15 = Math.Max(10, 6);
            double result16 = Math.Min(10, 7);
            double result17 = Math.Pow(2, 8);
            double result18 = Math.Round(20.56);
            double result19 = Math.Round(10.2435632, 5);
            int result20 = Math.Sign(-1);
            (double sin, double cos) = Math.SinCos(1);
            double result21 = Math.Sqrt(16);
            double result22 = Math.Truncate(16.2342);
            Console.WriteLine(Math.PI);
            Console.WriteLine(Math.E);
        }
        public static void ClassConver()
        {
            IFormatProvider format = new NumberFormatInfo { NumberDecimalSeparator = "." };
            int a = int.Parse("10");
            double b = double.Parse("23,56",format);
            decimal c = decimal.Parse("12,45");
            byte d = byte.Parse("4");

            string input = "aaa";
            bool res = int.TryParse(input, out a);
            if(res)
                Console.WriteLine("good");
            else
                Console.WriteLine("bad");

            int n = Convert.ToInt32("23");
            bool tmp = true;
            decimal e = Convert.ToDecimal(tmp);
        }
        public static void Arr()
        {
            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            int bobIndex = Array.BinarySearch(people, "Bob");
            int tomFirstIndex = Array.IndexOf(people, "Tom");
            int tomLastIndex = Array.LastIndexOf(people, "Tom");
            int lengthFirstIndex = Array.FindIndex(people, x => x.Length > 3);
            int lengthLastIndex = Array.FindLastIndex(people, x => x.Length > 3);

            string? first = Array.Find(people,x=>x.Length>3);
            string? last = Array.FindLast(people, x => x.Length > 3);

            var group = Array.FindAll(people, x => x.Length == 3);

            Array.Reverse(people);

            Array.Reverse(people, 1, 3);

            Array.Resize(ref people, 20);

            var empl = new string[3];

            Array.Copy(people, 1, empl, 0, 3);

            Array.Sort(people);
        }
        public static void TypeSpan()
        {
            string[] people = new string[] { "Tom", "Alice", "Bob" };
            Span<string> span = new Span<string>(people);
            span = people;
            span[0] = "Vlad";
            Console.WriteLine(span[0]);
            Console.WriteLine(span.Length);

            int[] temp = new int[]
            {
                10,12,13,14,15,11,13,15,16,17,
                18,16,15,16,17,14, 9, 8,10,11,
                12,14,15,15,16,15,13,12,12,11
            };

            Span<int> tempSpan = temp;

            Span<int> firstDecade = tempSpan.Slice(0, 10);
            Span<int> lastDecade = tempSpan.Slice(20, 10);

            string text = "hello, world";
            string worldString = text.Substring(7, 5);
            ReadOnlySpan<char> worldSpan = text.AsSpan().Slice(7, 5);
        }
        public static void IndexRange()
        {
            Index index = 1;
            Index index1 = ^2;

            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            string man = people[index];
            string man2 = people[index1];

            string[] peopleRange = people[1..4];
            string[] peopleRange1 = people[..4];
            string[] peopleRange2 = people[1..];
            string[] peopleRange3 = people[^2..];
            string[] peopleRange4 = people[..^1];
            string[] peopleRange5 = people[^3..^1];

        }
    }
    public class Reader
    {
        Lazy<Library> Library = new Lazy<Library> ();
        public void ReadBook()
        {
            Library.Value.GetBook();
            Console.WriteLine("Читаем бумажную книгу");
        }
        public void ReadEbook()
        {
            Console.WriteLine("Читаем эл книгу");
        }
    }
    public class Library
    {
        private string[] books = new string[99];
        public void GetBook()
        {
            Console.WriteLine("Выдаем книгу");
        }
    }

}
