using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Study
{
    internal class StringWork
    {
        public static void String()
        {
            string s1 = "hello";
            string s2 = new String('a', 6);
            string s3 = new String(new char[] { 'a', 'b', 'c', 'd' });
            string s4 = new String(new char[] { 'a', 'b', 'c', 'd' }, 1, 3);
            var first = s1[0];
            Console.WriteLine(s1.Length);

            for(int i=0;i<s1.Length;i++)
                Console.WriteLine(s1[i]);
            foreach (var ch in s1)
            {
                Console.WriteLine(ch);
            }

            Console.WriteLine(s1 == new String("hello"));
        }
        public static void Operations()
        {
            string s1 = "hello";
            string s2 = "world";
            string s3 = s1 + " " + s2;
            string s4 = string.Concat(s3, "!!!");
            Console.WriteLine(s4);

            string s5 = "apple";
            string s6 = "a day";
            string s7 = "keeps";
            string s8 = "a doctor";

            string[] values = { s5, s6, s7, s8};

            string s9 = string.Join(' ',values);
            Console.WriteLine(s9);

            int result = string.Compare(s1, s2);
            if(result<0)
                Console.WriteLine("s1 перед s2");
            else if(result>0)
                Console.WriteLine("s1 после s2");
            else
                Console.WriteLine("s1 и s2 идентичны");

            int index = s1.IndexOf('h');
            Console.WriteLine(index);

            int index2 = s1.IndexOf("hel");
            Console.WriteLine(index2);

            var files = new string[]
            {
                "myapp.exe",
                "forest.jpg",
                "main.exe",
                "book.pdf"
            };
            foreach (var item in files)
            {
                if(item.EndsWith(".exe"))
                    Console.WriteLine(item);
            }

            string text = "придурок мать твою сука блять";
            var words = text.Split(' ');
            var words1 = text.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

            string text1 = " hello world ";
            text1 = text1.Trim();
            text1 = text1.Trim('h', 'w');

            string text2 = "Good day";
            text2 = text2.Substring(text2.Length-3);
            Console.WriteLine(text2);
            text2 = text2.Substring(0,text2.Length-1);
            Console.WriteLine(text2);

            string text3 = "ti ";
            string text4 = " pidor";
            text3 = text3.Insert(2,text4);

            string text5 = "good day";
            text5 = text5.Remove(text5.Length - 1);
            Console.WriteLine(text5);

            text5 = text5.Remove(0, 2);
            Console.WriteLine(text5);

            string text6 = "Good day";
            text6 = text6.Replace("good", "Bad", true,System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(text6);

            Console.WriteLine(text6.ToLower());
            Console.WriteLine(text6.ToUpper());
        }
        public static void FormatAndInterpolation()
        {
            string name = "tom";
            int age = 23;
            Console.WriteLine("Name: {0} Age: {1}",name,age);

            string output = string.Format("Name: {0} Age: {1}", name, age);

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            double num = 23.7;
            
            string result = string.Format("{0:C0}",num);
            Console.WriteLine(result);

            result = string.Format("{0:C2}",num);
            Console.WriteLine(result);

            int num1 = 23;

            result = string.Format("{0:d}", num1);
            Console.WriteLine(result);

            result = string.Format("{0:d4}", num1);
            Console.WriteLine(result);

            result = string.Format("{0:f}", num1);
            Console.WriteLine(result);

            result = string.Format("{0:f4}", 45.08);
            Console.WriteLine(result);

            result = string.Format("{0:f1}", 25.08);
            Console.WriteLine(result);

            result = string.Format("{0:P1}", 0.15345m);
            Console.WriteLine(result);

            long tel = 375296307745;
            result = string.Format("{0:+### (##) ###-##-##}",tel);
            Console.WriteLine(result);

            Console.WriteLine(tel.ToString("+### (##) ###-##-##"));
            Console.WriteLine((24.8).ToString("C2"));

            int x = 8;
            int y = 7;
            Console.WriteLine($"{x} + {y} = {x+y}");

            Console.WriteLine($"Name: {name, -5} Age: {age}");
            Console.WriteLine($"Name: {name, 5} Age: {age}");
        }
        public static void StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder("hello");

            Console.WriteLine($"Length: {sb1.Length}\nCapacity: {sb1.Capacity}");

            var sb2 = new StringBuilder("Название: ");
            Console.WriteLine(sb2);
            Console.WriteLine($"Length: {sb2.Length}\nCapacity: {sb2.Capacity}");

            sb2.Append(" Руководство");
            Console.WriteLine(sb2);
            Console.WriteLine($"Length: {sb2.Length}\nCapacity: {sb2.Capacity}");

            sb2.Append(" по C#");
            Console.WriteLine(sb2);
            Console.WriteLine($"Length: {sb2.Length}\nCapacity: {sb2.Capacity}");

            sb1.Append("!");
            sb1.Insert(sb1.Length, " world");
            Console.WriteLine(sb1);

            sb1.Replace("hello", "priv");
            Console.WriteLine(sb1);
        }
        public static void Regex()
        {
            string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
            Regex regex = new Regex(@"туп(\w*)",RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(s);
            if(matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    Console.WriteLine(item.Value);
                }
            }
            else
                Console.WriteLine("Совпадений не найдено");

            string s1 = "456-435-2318";
            Regex regex1 = new Regex(@"\d{3}-\d{3}-\d{4}");
            Regex regex2 = new Regex(@"[0-9]{3}-[0-9]{3}-[0-9]{4}");
            Regex regex3 = new Regex(@"[a-v]{5}");
            Regex regex4 = new Regex(@"(2|3){3}-[0-9]{3}-\d{4}");
            Regex regex5 = new Regex(@"(2|3){3}\.[0-9]{3}\.\d{4}");

            string num = "+375(29)630-7745";
            string pattern = @"\D";
            string target = "";
            Regex regex6 = new Regex(pattern);
            string result = regex6.Replace(num,target);
            Console.WriteLine(result);

        }
    }
}
