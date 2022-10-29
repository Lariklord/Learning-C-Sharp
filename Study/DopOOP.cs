using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class DopOOP
    {
    }
    class Counter
    {
        public int Value { get; set; }
        public static void Check()
        {
            Counter a = new Counter { Value = 1 };
            Counter b = new Counter { Value = 45 };

            Console.WriteLine(a<b);
            Console.WriteLine(a>b);

            Counter c = a + b;

            int val = c + 5;

            if(c)
                Console.WriteLine(c.Value);

            Counter d = new Counter { Value = 10 };
            int x = (int)d;//явное

            Counter e = x;//неявное
        }
        public static implicit operator Counter(int x)//неявное
        {
            return new Counter { Value = x };
        }
        public static explicit operator int (Counter counter)//явное
        {
            return counter.Value;
        }
        public static bool operator !(Counter counter)
        {
            return counter.Value == 0;
        }
        public static bool operator true(Counter counter)
        {
            return counter.Value != 0;
        }
        public static bool operator false(Counter counter)
        {
            return counter.Value == 0;
        }
        public static Counter operator ++(Counter counter)
        {
            return new Counter { Value = counter.Value + 1 };
        }
        public static Counter operator +(Counter counter1, Counter counter2)
        {
            return new Counter { Value = counter1.Value + counter2.Value };
        }
        public static int operator +(Counter counter, int value) => counter.Value + value;
        public static bool operator >(Counter counter1, Counter counter2)
        {
            return counter1.Value > counter2.Value;
        }
        public static bool operator <(Counter counter1, Counter counter2)
        {
            return counter1.Value < counter2.Value;
        }
    }

    class Worker
    {
        public string Name { get; set; }
        public Worker(string name)
        {
            Name = name;
        }
    }
    class Corp
    {
        Worker[] workers;
        public Corp(Worker[] workers)
        {
            this.workers = workers;
        }
        public Worker this[int index]
        {
            get
            {
                if (index < 0 || index >= workers.Length)
                    throw new Exception("out of range");
                return workers[index];
            }
            set
            {
                if (index < 0 || index >= workers.Length)
                    throw new Exception("out of range");
                workers[index] = value;
            }
        }
        public static void Syntax()
        {
            var microsoft = new Corp(new[]
            {
                new Worker("Vlad"),
                new Worker("Vania"),
                new Worker("Jenya")
            });

            Worker first = microsoft[0];
            microsoft[0] = new Worker("Kostya");
        }
    }
    class Polzovat
    {
        string name = "";
        string email = "";
        string phone = "";
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "name": return name;
                    case "email": return email;
                    case "phone": return phone;
                    default: throw new Exception("unknown prop");   
                }
            }
            set
            {
                switch (propname)
                {
                    case "name":
                        name = value;
                        break;
                    case "email":
                        email = value;
                        break;
                    case "phone":
                        phone = value;
                        break;
                    default: throw new Exception("unknown prop");
                }
            }
        }
        public static void Syntax()
        {
            Polzovat tom = new Polzovat();
            tom["name"] = "tom";
            tom["email"] = "tom@gmail.com";
            tom["phone"] = "228335";
        }
    }
    class Matrix
    {
        int[,] numbers = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 5, 6, 7 } };
        public int this[int i, int j]
        { 
            get { return numbers[i, j]; }
            private set { numbers[i, j] = value; }
        }
    }
    class Reference
    {
        public static void Syntax()
        {
            int x = 5;
            ref int xRef = ref x;
            Console.WriteLine(x);
            xRef = 125;
            Console.WriteLine(x);//125
            x = 625;
            Console.WriteLine(xRef);//625

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ref int numRef = ref Find(4, numbers);
            numRef = 9;
            Console.WriteLine(numbers[3]);//9
            ref int Find(int number, int[] numbers)
            {
                for(int i=0;i<numbers.Length; i++)
                {
                    if (numbers[i]==number)
                        return ref numbers[i];
                }
                throw new Exception("no find");
            }
            int a = 5;
            int b = 8;
            ref int pointer = ref Max(ref a, ref b);
            pointer = 34;
            ref int Max(ref int n1, ref int n2)
            {
                if(n1>n2)
                    return ref n1;
                return ref n2;
            }
        }
    }
    static class StringExtension
    {
        public static int CharCount(this string str,char c)
        {
            return str.Where(x => x == c).Count();
        }
    }
    public partial class Part1
    {
        public partial void Do();
        public void Eat()
        {
            Do();
            Console.WriteLine("Im eating");
        }
    }
    public partial class Part1
    {
        public partial void Do()
        {
            Console.WriteLine("from first");
        }
        public void Move()
        {
            Console.WriteLine("Im moving");
        }
    }
    public class AnonymType//в основном для выборки из бд
    { 
        public static void Syntax()
        {
            var user = new { Name = "tom", Age = 34 };
            Console.WriteLine(user.Age);
            var people = new[]
            {
                new {Name = "tom"},
                new {Name = "bob"}
            };
            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
    public class Kortege
    {
        public static void Syntax()
        {
            var tuple = (5, 10);
            Console.WriteLine(tuple.Item1);
            tuple.Item2 += 5;
            Console.WriteLine(tuple.Item2);
            //(int, int) tuple1 = (5, 10);

            var person = (Name: "vlad", Age: 18);
            Console.WriteLine(person.Name);
            var (name, age) = person;//декомпозиция

            string main = "Java";
            string second = "C#";
            (main, second) = (second, main);//обмен значениями

            var tmp = GetValues();
            Console.WriteLine(tmp.Item1);
            (int, int) GetValues()
            {
                var res = (1, 2);
                return res;
            }

            var inf = GetInfo(new int[] {1,2,3,4,5,5});
            Console.WriteLine(inf.sum);
            Console.WriteLine(inf.count);
            (int sum,int count) GetInfo(int[] numbers)
            {
                int sum = numbers.Sum();
                int count = numbers.Count();
                var result = (sum,count);
                return result;
            }

            Print(("Vlad", 18));
            void Print((string name,int age) person)
            {
                Console.WriteLine($"{person.name} {person.age}");
            }
        }
    }
    public record Human (string Name,int Age);
    




}
