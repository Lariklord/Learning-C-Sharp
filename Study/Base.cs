using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public static class Base
    {
        public static void Literaly()
        {
            //Логические 

            Console.WriteLine(true);
            Console.WriteLine(false);

            //Целочисленные

            Console.WriteLine(228);
            Console.WriteLine(335);

            // Для двоичной формы используется 0b

            Console.WriteLine(0b11);// 3 
            Console.WriteLine(0b1011);//11 

            //Для шестнадцатеричной формы используется 0x

            Console.WriteLine(0x0A);// 10
            Console.WriteLine(0xFF);//255

            //перевод

            Console.WriteLine(Convert.ToString(255, 2));
            Console.WriteLine(Convert.ToString(255, 8));
            Console.WriteLine(Convert.ToString(255, 16));

            //Вещественные

            Console.WriteLine(3.5);
            Console.WriteLine(-0.7);

            //Экспоненциальная форма MEp

            Console.WriteLine(3.2e3);
            Console.WriteLine(1.2e-1);

            //Символьные

            Console.WriteLine('A');
            Console.WriteLine('z');

            //Управляющая последовательность

            Console.WriteLine("\n \t \\ \" \" ");
            // /n - перенос строки
            // /t - табуляция
            // \" \" - ""

            //ASCII - \x

            Console.WriteLine('\x78');// x
            Console.WriteLine('\x5A');// Z

            //Unicode - \u

            Console.WriteLine('\u0411');
            Console.WriteLine('\u0421');

            //Строковые

            Console.WriteLine("\"eblan\"");


            //null - ссылка вникуда
        }

        public static void DataType()
        {
            //bool
            //byte 
            //sbyte
            //short 
            //ushort;
            //int
            //uint
            //long
            //ulong
            //float
            //double
            //decinal
            //char
            //string
            //object - значение любого тд

            //суффиксы

            /*
            float a = 3.14F;
            decimal b = 30.6M;
            uint c = 35U;
            long d = 25563L;
            ulong e = 74352UL;
            */

            //var - для неявной типизации
            /*
            var tmp = "Vlad";
            var tmp1 = 2343;
            */
        }

        public static void OutPut()
        {
            string name = "Tom";
            int age = 34;
            double height = 1.7;
            Console.WriteLine($"Имя: {name}  Возраст: {age}  Рост: {height}м");
            Console.WriteLine("Имя: {0}  Возраст: {2}  Рост: {1}м", name, height, age);
        }

        public static void Checked()
        {
            try
            {
                int a = 33;
                int b = 600;
                byte c = checked((byte)(a + b));
                Console.WriteLine(c);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void Sum(params int[] nums)
        {
            int result = 0;
            foreach (var num in nums)
            {
                result += num;
            }
            Console.WriteLine($"Сумма : {result}");
        }

        public static int Factorial(int num)
        {
            if (num == 1) return 1;

            return num * Factorial(num - 1);
        }

        public static int Fibo(int num)
        {
            if (num == 1 || num == 0) return num;
            return Fibo(num - 1) + Fibo(num - 2);
        }

        public static int DoOperation(int op, int a, int b) => op switch
        {
            1=> a+b,
            2=> a-b,
            3=> a*b,
            _=>0
        };

        enum DayTime
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }
        public static void Enums()
        {
            Console.WriteLine(Enum.GetName(typeof(DayTime), DayTime.Morning));
            var names = Enum.GetNames(typeof(DayTime));
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var values = Enum.GetValues(typeof(DayTime));
            foreach (int item in values)
            {
                Console.WriteLine(item);
            }
        }
          

    }
}
