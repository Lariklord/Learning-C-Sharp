using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class Linq
    {

        public static void MainLinq()
        {
            string[] people = { "Tom", "Bob", "Sam", "tim", "Bill" };
            var list = people.Where(x => x.ToUpper().StartsWith('T')).OrderBy(x => x); foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Proection()
        {
            var people = new List<(string, int)>()
           {
               new ("Vlad",18),
               new ("Vanya",17),
               new ("Jenya",17),
               new ("Sereja",18)

           };

            var names = people.Select(x => x.Item1);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            var personal = people.Select(x => new { FirstName = x.Item1, Age = x.Item2 });
            foreach (var item in personal)
            {
                Console.WriteLine($"{item.FirstName}\t{item.Age}");
            }

            var personal1 = from p in people
                            let name = $"Mr. {p.Item1}"
                            let year = DateTime.Now.Year - p.Item2
                            select new { FirstName = name, Age = year };

            Console.WriteLine();
            foreach (var item in personal1)
            {
                Console.WriteLine($"{item.FirstName}\t{item.Age}");
            }

            var comp = new List<Comp>
            {
                new Comp("Microsoft",new List<Per>{new Per("Vlad"),new Per("Vanya")}),
                new Comp("Google",new List<Per>{new Per("Kostya"),new Per("serega")})
            };

            var empl = comp.SelectMany(c => c.Staff,
                                       (c, emp) => new { Name = emp.Name, Company = c.Name });
            Console.WriteLine();
            foreach (var item in empl)
            {
                Console.WriteLine($"{item.Name}\t{item.Company}");
            }
        }
        public static void Filter()
        {
            string[] people = { "Tom", "Bob", "Sam", "tim", "Bill" };

            var selected = people.Where(x => x.Length == 3);
            foreach (var item in selected)
            {
                Console.WriteLine(item);
            }

            int[] nums = { 1, 2, 3, 4, 5, 6, 10, 12, 11, 13, 14, 66, 77, 88 };
            var evens = nums.Where(x => x % 2 == 0 && x > 10);
            foreach (var item in evens)
            {
                Console.WriteLine(item);
            }

            var mens = new List<LangPer>()
            {
                new LangPer("Vlad",23,new List<string>{"Eng","Rus"}),
                new LangPer("Vanya",27,new List<string>{"Eng","Fre"}),
                new LangPer("Serega",29,new List<string>{"Eng","Ger"}),
                new LangPer("Jenya",24,new List<string>{"Ger","Ukr"})
            };

            var sel = mens.SelectMany(x => x.Languages, (x, u) =>
                                            new { Person = x, Lang = u }).Where
                                            (x => x.Lang == "Eng" && x.Person.Age < 28).Select(x => x.Person);
            foreach (var item in sel)
            {
                Console.WriteLine($"{item.Name}\t{item.Age}");
            }

            var mens1 = new List<Per>()
            {
                new Per("Tom"),
                new Stu("Vlad"),
                new Per("Serega"),
                new Stu("Vanya")
            };

            var students = mens1.OfType<Stu>();
            foreach (var item in students)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void Sort()
        {
            int[] nums = { 3, 12, 4, 10 };

            foreach (var item in nums.OrderBy(x => x))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            foreach (var item in nums.OrderByDescending(x => x))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            string[] people = { "Tom", "Bob", "Sam" };
            foreach (var item in people.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

            var people1 = new List<(string, int)>()
            {
               new ("Vlad",18),
               new ("Vanya",17),
               new ("Jenya",17),
               new ("Sereja",18)

            };

            foreach (var item in people1.OrderBy(x => x.Item1).ThenBy(x => x.Item2))
            {
                Console.WriteLine(item.Item1 + "\t" + item.Item2);
            }

            string[] people2 = new[] { "Kate", "Tom", "Sam", "Mike", "Alice" };
            Console.WriteLine();
            var sorted = people2.OrderBy(s => s, new CustomStrimgComparer());
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
        public static void ExceptIntersectUnionDistinct()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            foreach (var item in soft.Except(hard))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            foreach (var item in soft.Intersect(hard))
            {
                Console.WriteLine(item + "\t");
            }
            Console.WriteLine();
            string[] dist = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };
            foreach (var item in dist.Distinct())
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            foreach (var item in soft.Union(hard))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            foreach (var item in soft.Concat(hard))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            Per[] people = { new Per("Vlad"), new Per("Vanya"), new Per("Serega") };
            Per[] people1 = { new Per("Kostya"), new Per("Vanya"), new Per("Serega") };
            foreach (var item in people.Union(people1))
            {
                Console.Write(item.Name + "\t");
            }
        }
        public static void Agregate()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            int query = numbers.Aggregate((x, y) => x - y);
            Console.WriteLine(query);

            string[] words = { "Gaudeamus", "igitur", "Juvenes", "dum", "sumus" };
            string sent = words.Aggregate("Text:", (first, next) => $"{first} {next}");
            Console.WriteLine(sent);

            Console.WriteLine(numbers.Count());

            Console.WriteLine(numbers.Count(x=> x%2==0 && x>10));

            Console.WriteLine(numbers.Sum());

            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Average());
        }
        public static void SkipTake()
        {
            string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };

            foreach (var item in people.Skip(2))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.SkipLast(2))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.SkipWhile(x => x.Length == 3))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.Take(2))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.TakeLast(2))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.TakeWhile(x => x.Length == 3))
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (var item in people.Skip(2).Take(2))
            {
                Console.Write($"{item}\t");
            }
        }
        public static void Group()
        {
            Person[] persons =
            {
                new Person("Vlad",18),new Person("Vanya",18),
                new Person("Jenya",17),new Person("Serega",15),
                new Person("Danya",17),new Person("Kostya",16)
            };

            var ages = persons.GroupBy(x => x.age);

            foreach (var item in ages)
            {
                Console.Write($"{item.Key}\t");
                foreach (var item1 in item)
                {
                    Console.Write($"{item1.name}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var tmp = persons.GroupBy(x => x.age).Select(g => new { Age = g.Key, Count = g.Count() });
            foreach (var item in tmp)
            {
                Console.WriteLine(item.Age + "\t" + item.Count);
            }
        }
        public static void Join()
        {
            LinqPers[] people =
            {
                new LinqPers("Tom","Microsoft"),new LinqPers("Sam","Microsoft"),
                new LinqPers("Bob","JetBrains"), new LinqPers("Mike","Google")
            };

            LinqComp[] companies =
            {
                new LinqComp("Microsoft","C#"),
                new LinqComp("Google","Go"),
                new LinqComp("Oracle","Java")
            };
            var result = people.Join(companies,
                x => x.Company,
                y => y.Title,
                (x, y) => new
                { Name = x.Name,
                  Company = y.Title,
                  Language = y.Language
                });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Company}:{item.Language}");
            }
            Console.WriteLine();

            var result1 = companies.GroupJoin(people,
                x => x.Title,
                y => y.Company,
                (x, employess) => new
                {
                    Title = x.Title,
                    Employes = employess
                });
            foreach (var item in result1)
            {
                Console.WriteLine(item.Title);
                foreach (var item1 in item.Employes)
                {
                    Console.WriteLine(item1.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (var item in people.Zip(companies))
            {
                Console.WriteLine(item.First+"\t"+item.Second);
            }
        }
        public static void Check()
        {
            string[] people = { "Tom", "Tim", "Bob", "Sam" };

            var allHas3Chars = people.All(x=>x.Length==3);
            Console.WriteLine(allHas3Chars);

            var allStartWithT = people.All(x=>x.StartsWith('T'));
            Console.WriteLine(allStartWithT);

            var oneHasMore3Char = people.All(x => x.Length > 3);
            Console.WriteLine(oneHasMore3Char);

            var oneStartWithT = people.Any(x => x.StartsWith('T'));
            Console.WriteLine(oneStartWithT);

            Console.WriteLine(people.Contains("Tom"));
            Console.WriteLine(people.Contains("tOm"));

            Console.WriteLine(people.First());
            Console.WriteLine(people.First(x => x.StartsWith("B")));
            Console.WriteLine(people.FirstOrDefault());
            Console.WriteLine(people.FirstOrDefault(x=>x.Length>10,"Undefined"));
            Console.WriteLine(people.Last());
            Console.WriteLine(people.Last(x=>x.StartsWith('B')));
            Console.WriteLine(people.LastOrDefault());
            Console.WriteLine(people.LastOrDefault(x=>x.StartsWith("A"),"Undefined"));
        }
        public static void DeferredImmediate()
        {
            string[] people = { "Tom", "Sam", "Bob" };

            var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);

            people[2] = "Mike";
            foreach (string s in selectedPeople)
                Console.WriteLine(s);

            var count = people.Where(s => s.Length == 3).OrderBy(s => s).Count();
            Console.WriteLine(count);
            people[1] = "Mike";
            Console.WriteLine(count); 
        }
        public static void Parallel()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            nums.AsParallel().
                Select(x => x * x).
                ForAll(Console.WriteLine);
        }
        public static void Ordered()
        {
            int[] nums = new int[] { -1, 2, -3, 4, -5, 6, 7, -8, 9 };
            var res = nums.AsParallel().AsOrdered().Where(x=>x>0).Select(x => x * x);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        public static void Cancel()
        {
            object[] nums = new object[] { 1, 2, 3, 4, 5, "6" };
            var tmp = nums.AsParallel().Select(x => Square((int)x));
            try
            {
                tmp.ForAll(n => Console.WriteLine(n));
            }
            catch(AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }

            CancellationTokenSource cts = new CancellationTokenSource();

            new Task(() =>
            {
                Thread.Sleep(400);
                cts.Cancel();
            }).Start();
            try
            {
                int[] nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                var squares = nums1.AsParallel().WithCancellation(cts.Token).Select(x => Square1(x));
                foreach (var item in squares)
                {
                    Console.WriteLine(item);
                }
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Операция прервана");
            }
            catch(AggregateException ex)
            {
                if(ex.InnerExceptions!=null)
                {
                    foreach (var item in ex.InnerExceptions)
                    {
                        Console.WriteLine(item.Message);
                    }
                }
            }
            finally
            {
                cts.Dispose();
            }
            int Square1(int n)
            {
                var res = n * n;
                Console.WriteLine($"Квадрат числа {n} равен {res}");
                Thread.Sleep(1000);
                return res;
            }
            int Square(int n) => n * n;
        }
    }

record class Comp(string Name, List<Per> Staff);
record class Per(string Name);
record class Stu(string Name) : Per(Name);
record class LangPer(string Name, int Age, List<string> Languages);
class CustomStrimgComparer : IComparer<String>
{
    public int Compare(string? x, string? y)
    {
        int xLength = x?.Length ?? 0;
        int yLength = y?.Length ?? 0;

        return xLength - yLength;
    }
}
record class LinqPers(string Name, string Company);
record class LinqComp(string Title,string Language);
}

