using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class MyExeption
    {
        public static void Syntax()
        {
            int x = 0;
            int y = 1;
            try
            {
                int res1 = x / y;
                int res2 = y / x;
                Console.WriteLine($"Результат: {y}");
            }
            catch (DivideByZeroException) when (y==0)
            {

                Console.WriteLine("Возникло исключение");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.TargetSite);
               
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
        public static void ThrowSyntax()
        {
            try
            {
                try
                {
                    Console.Write("Enter name:");
                    string? name = Console.ReadLine();
                    if (name == null || name.Length <= 2)
                        throw new Exception("Длина имени меньше 2 символов");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        
    }
    internal class PersonExeption : Exception
    {
        public int Value { get; set; }
        public PersonExeption(string? message, int value)
            : base(message)
        {
            Value = value;
        }
    }
    internal class Persons
    {
        private int age;
        public string Name { get; set; } = "";
        public int AGE
        {
            get => age;
            set
            {
                if (value < 18)
                    throw new PersonExeption("Вам нет 18",value);
                else
                    age = value;
            }
        }
    }

    internal class FindCatch
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Catch Metho1: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally Method1");
            }
            Console.WriteLine("Конец Method1");
        }
        static void Method2()
        {
            try
            {
                int x = 8;
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("Finally Method2");
            }
            Console.WriteLine("Конец Method2");
        }
    }

}
