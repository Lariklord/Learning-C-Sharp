using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Study
{
    internal class Reflection
    {
        public static void TypeClass()
        {
            Type type = typeof(ReflectionPerson);
            Console.WriteLine(type);

            ReflectionPerson a = new ReflectionPerson("Tom");
            Type type1 = a.GetType();
            Console.WriteLine(type1);

            Type? type2 = Type.GetType("Study.ReflectionPerson", false, true);
            Console.WriteLine(type2);

            Console.WriteLine();

            Console.WriteLine($"Name: {type.Name}");
            Console.WriteLine($"Full name: {type.FullName}");
            Console.WriteLine($"Namespace: {type.Namespace}");
            Console.WriteLine($"Is class: {type.IsClass}");
            Console.WriteLine($"Module: {type.Module}");
            Console.WriteLine($"Is public: {type.IsPublic}");

            Console.WriteLine();

            foreach (var item in type.GetInterfaces())
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void GetMembersMetod()
        {
            Type type = typeof(ReflPers);

            foreach (var item in type.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"{item.DeclaringType} {item.Name} {item.MemberType} {item.ReflectedType}");
            }

            MemberInfo[] print = type.GetMember("Print", BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine();
            foreach (var item in print)
            {
                Console.WriteLine(item.Name+" "+item.MemberType);
            }
        }
        public static void GetMethodsMethod()
        {
            Type type = typeof(Printer);

            Console.WriteLine("Методы:");

            foreach (var item in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                string mod = "";
                string param = "";
                if (item.IsStatic) mod += "static ";
                if (item.IsVirtual) mod += "virual ";
                if (item.IsAbstract) mod += "abstract ";
                if (item.IsPublic) mod += "public";
                if (item.IsPrivate) mod += "private";
                var parametrs = item.GetParameters();
                foreach (var item1 in parametrs)
                {
                    if (item1.IsIn) param += "in ";
                    if (item1.IsOut) param += "out ";
                    param += item1.ParameterType.Name+" ";
                    param += item1.Name;
                    if (parametrs.Last() != item1) param += ",";
                }
                Console.WriteLine($"{mod} {item.ReturnType.Name} {item.Name}({param})");
            }

            var my = new Printer();
            var print = typeof(Printer).GetMethod("PrintMessage");

            print?.Invoke(my, new object[] {"Vlad",5});
        }
        public static void GetFieldsMethod()
        {
            Type type = typeof(ReflPers);
            Console.WriteLine("Поля:");
            foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                string mod = "";
                if (item.IsPublic) mod += "public ";
                if (item.IsPrivate) mod += "private ";
                if (item.IsAssembly) mod += "internal ";
                if (item.IsFamily) mod += "protected ";
                if (item.IsFamilyAndAssembly) mod += "private protectd ";
                if (item.IsFamilyOrAssembly) mod += "protected internal ";
                if (item.IsStatic) mod += "static ";
                Console.WriteLine($"{mod}{item.FieldType.Name} {item.Name}");
            }
            ReflPers a = new ReflPers("bob",37);
            var name = type.GetField("name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var value = name?.GetValue(a);
            Console.WriteLine(value);
            name?.SetValue(a, "Bob");
            a.Print();
            
        }
        public static void AssemblyClass()
        {

        }
        public static void AttributeClass()
        { 
            ValidPers a = new ValidPers("Tom", 35);
            ValidPers b = new ValidPers("Bob", 16);
            Console.WriteLine($"Valid Tom: {Validate(a)}");
            Console.WriteLine($"Valid Bob: {Validate(b)}");

            bool Validate(ValidPers pers)
            {
                Type type = typeof(ValidPers);
                foreach (var item in type.GetCustomAttributes(false))
                {
                    if (item is AgeValidationAttribute attr)
                        return pers.Age >= attr.Age;

                }
                return true;
            }
        }
       
    }
    [AgeValidation(18)]
    public class ValidPers
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ValidPers(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AgeValidationAttribute:Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }
    public class ReflectionPerson:IEater,IMovableRefl
    {
        public string Name { get; set; }
        string name;
        public ReflectionPerson(string name)
        {
           Name = name;
           this.name = name;
        }

        public void Eat()
        {
            Console.WriteLine("eating");
        }

        public void Move()
        {
            Console.WriteLine("moving");
        }
        public void Print() => Console.WriteLine(name);
    }
    interface IEater
    {
        void Eat();
    }
    interface IMovableRefl
    {
        void Move();
    }

    public class ReflPers
    {
        string name;
        public int Age { get; private set; }
        public string? Country {private get ; set; }

        public ReflPers(string name, int age)
        {
            this.name = name;
            this.Age = age;
        }
        public void Print() => Console.WriteLine(name);
    }
    class Printer
    {
        public string DefaultMessage { get; set; } = "hello";
        public void PrintMessage(string mes, int times = 1)
        {
            while (times-- > 0) Console.WriteLine(mes);
        }
        public string CreateMessage() => DefaultMessage;
    }
}
