using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class Collections
    {
        public static void List()
        {
            var people = new List<string>();
            List<string> list = new List<string>(16) { "vlad","kostya","serega"};
            list[0] = "larik";
            var count = list.Count;
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.Add("vladik");
            list.AddRange(new[] { "mama", "papa" });
            list.Insert(0, "eugene");
            list.InsertRange(1, new List<string> { "vanya", "danya" });


            list.RemoveAt(1);
            list.Remove("vanya");
            list.RemoveAll(x => x.Contains("lox"));
            list.RemoveRange(0, 2);
            list.Clear();

            Console.WriteLine(list.Contains("vlad"));
            Console.WriteLine(list.Exists(x=>x.Length==2));
            var el = list.Find(x => x.Length == 10);
            var el2 = list.FindLast(x => x is null);
            var newList = list.FindAll(x => x.Length != 0);

            var range = list.GetRange(0, 10);

            list.Reverse();
            list.Reverse(0, 5);
            

        }
        public static void LinkedList()
        {
            List<string> tmp = new List<string>() { "vlad", "kostya", "vanya" };
            LinkedList<string> list = new LinkedList<string>(tmp);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(list.First?.Value);
            Console.WriteLine(list.Last?.Value);

            var current = list.First;
            while(current is not null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            current = list.Last;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Previous;
            }

            var peopple = new LinkedList<string>();
            peopple.AddLast("vlad");
            peopple.AddFirst("vanya");
            if (peopple.First is not null) peopple.AddAfter(peopple.First, "jenya");
            foreach (var item in peopple) Console.WriteLine(item);
        }
        public static void Queue()
        {
            Queue<string> people = new Queue<string>();
            people.Enqueue("vlad");
            people.Enqueue("kostya");
            people.Enqueue("vanya");

            var person = people.Peek();
            Console.WriteLine(person);

            person = people.Dequeue();
            Console.WriteLine(person);
            person = people.Dequeue();
            Console.WriteLine(person);
            person = people.Dequeue();
            Console.WriteLine(person);

            if (people.Count > 0)
            {
                var pers = people.Peek();
                people.Dequeue();
            }

            var success = people.TryDequeue(out var tmp);
            if (success) Console.WriteLine(tmp);

            var success2 = people.TryPeek(out var tmp1);
            if (success2) Console.WriteLine(tmp1);
        }
        public static void Stack()
        {
            Stack<string> people = new Stack<string>();
            people.Push("vlad");
            people.Push("vanya");
            people.Push("serega");

            string person = people.Peek();
            Console.WriteLine(person);

            people.Pop();
            people.Pop();
            people.Pop();

            var result = people.TryPop(out var tmp);
            if (result) Console.WriteLine(tmp);
        }
        public static void Dictionary()
        {
            Dictionary<int, string> people = new Dictionary<int, string>()
            {
                {5,"tom" },
                {3,"sam" },
                {11,"bob" }
            };
            foreach (var item in people)
            {
                Console.WriteLine($"Key: {item.Key}\nValue: {item.Value}");
            }
            people[5] = "vlad";
            people[228] = "serega";

            var phoneBook = new Dictionary<string, string>();
            phoneBook.Add("228335", "vlad");

            var phone1 = phoneBook.ContainsKey("228335");
            Console.WriteLine($"228335: {phone1}");

            var exist = phoneBook.ContainsValue("vlad");
            Console.WriteLine($"vlad: {exist}");

            Console.WriteLine(phoneBook.Count);

    }
        public static void ObservableColl()
        {
            ObservableCollection<string> people = new ObservableCollection<string>(new string[] {"vkad","kostya","vanya"});
            Console.WriteLine(people[0]);
            people[1] = "serega";
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
            people.Add("jenya");
            people.Insert(0, "danya");
            bool vladexist = people.Contains("vlad");
            Console.WriteLine($"vlad: {vladexist}");
            people.Remove("danya");
            people.RemoveAt(people.Count - 1);

            var peupils = new ObservableCollection<PeopleForColl>()
            {
                new PeopleForColl("Vlad"),
                new PeopleForColl("Vanya"),
                new PeopleForColl("Serega")
            };

            peupils.CollectionChanged += Peupils_CollectionChanged;
            peupils.Add(new PeopleForColl("dodik"));
            peupils.Remove(new PeopleForColl("dodik"));
            peupils[0] = new PeopleForColl("durak");

            void Peupils_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewItems?[0] is PeopleForColl pers)
                            Console.WriteLine($"Добавлен новый объект: {pers.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems?[0] is PeopleForColl oldpers)
                            Console.WriteLine($"Удален объект: {oldpers.Name}");
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        if ((e.NewItems?[0] is PeopleForColl replacingPers) &&
                            (e.OldItems?[0] is PeopleForColl replacedPers))
                            Console.WriteLine($"Объект {replacedPers.Name} заменен на {replacingPers.Name}");
                        break;
                }
            }
        }
        public static void IEnumerableIEnumerator()
        {
            string[] people = { "vlad", "vanya", "serega" };
            IEnumerator enumerator = people.GetEnumerator();
            while(enumerator.MoveNext())
            {
                string item = (string)enumerator.Current;
                Console.WriteLine(item);
            }
            enumerator.Reset();

            Week week = new Week();
            foreach (var item in week)
            {
                Console.WriteLine(item);
            }
        }
        public static void Yield()
        {
            Numbers numbers = new Numbers();
            foreach(int n in numbers)
                Console.WriteLine(n);

            foreach(int a in 5)
                Console.WriteLine(a);
            foreach(int a in -5)
                Console.WriteLine(a);
        }
    }
    static class Int32Extension
    {
        public static IEnumerator<int> GetEnumerator(this int val)
        {
            int k = (val > 0) ? val : 0;
            for(int i =  val - k; i<=k; i++)
                yield return i;
        }
    }
    class Numbers
    {
        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0; i < 10; i++)
            {
                yield return i * i;
            }
        }
    }
    internal class WeekEnumerator : IEnumerator
    {
        string[] days;
        int pos = -1;
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }

        public object Current
        {
            get
            {
                if (pos == -1 || pos >= days.Length)
                    throw new ArgumentException();
                else
                    return days[pos];
            }
        }

        public bool MoveNext()
        {
            if (pos < days.Length - 1)
            {
                pos++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            pos = -1;
        }
    }

    internal class Week 
    {
        string[] days = { "pn", "vt", "sr", "cht", "pt", "sb", "vs" };
        public IEnumerator GetEnumerator() => new WeekEnumerator(days);
       
    }
    internal class PeopleForColl
    {
        public string Name { get; set; }
        public PeopleForColl(string name)
        {
            Name = name;
        }
    }
}
