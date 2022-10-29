using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class Person
    {
        public int age;
        public string name;
        private int code;
        public int Code
        {
            get => code;
            set => code = value;
        }

        public Person() : this("None", 18) { }
        public Person(string name):this(name, 18) { }
        public Person(string name, int age) { this.name = name; this.age = age;}

        public void Deconstruct(out string name, out int age)// деконструктор
        {
            name = this.name;
            age = this.age;
        }
    }
   
    public struct SPerson
    {
        public string name;
        public int age;

       
    }
}
