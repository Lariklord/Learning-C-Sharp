using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    sealed class Admin//sealed - запрещает наследование
    { 
    }
    class People
    {
        public string Name { get; set; }
        public People()
        {
            Name = "";
        }
        public People(string name)
        {
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine("Base print(people)");
        }
        public override string? ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is People people) return Name == people.Name;
            return false;
        }
    }
    class Employee : People
    {
        public Employee() : base() { }
        public Employee(string name) : base(name)
        {
        }

        public new void Print()
        {
            Console.WriteLine("Ovveride print(empl)");
        }
    }

    abstract class Transport
    {
        public abstract int Speed { get; set; }
        public abstract void Move();
    }

    class Car : Transport
    {
        private int speeed;
        public override int Speed
        {
            get => speeed;
            set => speeed = value;
        }

        public override void Move()
        {
            Console.WriteLine("Машина едет");
        }
       
    }

    class Client<T>
    {
        public string? Name { get; set; }
        public T? Id { get; set; }
        public static T? code;//для каждого типа будет своя переменная
        public Client()
        {
            Id = default(T);
        }
        public Client(string name, T id)
        {
            Name = name;
            Id = id;
        }

        public void Swap<K>(ref K x, ref K y) where K : People
        {
            (x, y) = (y, x);
        }
    }
}
