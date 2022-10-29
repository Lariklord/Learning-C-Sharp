using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Study
{
    internal class DLR
    {
        public static void DynamicWord()
        {
            dynamic obj = 3;
            Console.WriteLine(obj);

            obj = "Hello";
            Console.WriteLine(obj);

            obj = new People("Bob");
            Console.WriteLine(obj);

            dynamic dyn = 24;
            dyn += 3;

            Console.WriteLine();
            Console.WriteLine();

            dynamic tom = new DynPerson("Tom", 22);
            Console.WriteLine(tom);
            Console.WriteLine(tom.GetSalary(28, "int"));

            dynamic bob = new DynPerson("Bob", "twenty-eight");
            Console.WriteLine(bob);
            Console.WriteLine(bob.GetSalary("twenty-two","string"));
        }
        public static void DynamicAndExpandoObj()
        {
            dynamic person = new ExpandoObject();
            person.Name = "Tom";
            person.Age = 46;
            person.Languages = new List<string> { "english", "german", "french" };

            Console.WriteLine($"{person.Name}-{person.Age}");
            foreach (var item in person.Languages)
            {
                Console.WriteLine(item);
            }

            person.IncrementAge = (Action<int>)(x =>person.Age += x);
            person.IncrementAge(6);
            Console.WriteLine($"{person.Name}-{person.Age}");

            dynamic pers = new PersonObject();
            pers.Name = "Tom";
            pers.Age = 23;
            Func<int, int> increment = (int n) =>
            {
                pers.Age += n;
                return pers.Age;
            };
            pers.IncrementAge = increment;
            Console.WriteLine($"{pers.Name}-{pers.Age}");
            pers.IncrementAge(6);
            Console.WriteLine($"{pers.Name}-{pers.Age}");
        }
    }
    public class DynPerson
    { 
        public string Name { get; set; }
        public dynamic Age { get; set; }
        public DynPerson(string name, dynamic age)
        {
            Name = name;
            Age = age;
        }
        public dynamic GetSalary(dynamic value, string format)
        {
            if (format == "string") return $"{value} euro";
            else if (format == "int") return value;
            else return 0.0;
        }
        public override string ToString()
        {
            return $"Name: {Name}  Age: {Age}";
        }
    }
    public class PersonObject:DynamicObject
    {
        Dictionary<string,object> members = new Dictionary<string,object>();
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if(value is not null)
            {
                members[binder.Name] = value;
                return true;
            }
            return false;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = null;
            if (members.ContainsKey(binder.Name))
            {
                result = members[binder.Name];
                return true;
            }
            return false;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            result = null;
            if (args?[0] is int number)
            {
                dynamic method = members[binder.Name];
                result = method(number);
            }
            return result!= null;
        }
    }

}
