using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    interface IMovable
    {
        // public const int MIN_SPEED = 0;
        //private static int maxSpeed = 60;

        //protected internal string Name { get; set; }

        void Move();


        //delegate void MoveHandler(string message);

        //event MoveHandler MoveEvent;
    }


    internal class Chel : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Walking");
        }
        public static void DoAction(IMovable movable) => movable.Move();
    }
    class ChelYavno : IMovable
    {
        void IMovable.Move() => Console.WriteLine("move");
    }

    interface IDoing
    {
        protected internal void Move();
        protected internal string Name { get;}

        delegate void MoveHandler();
        protected internal event MoveHandler MoveEvent;
    }

    class Chelovec : IDoing
    {
        string name;
        IDoing.MoveHandler? moveEvent;
        event IDoing.MoveHandler IDoing.MoveEvent
        {
            add { moveEvent+=value;}
            remove { moveEvent-=value;}
        }
        string IDoing.Name { get => name; }
        void IDoing.Move()
        {
            Console.WriteLine("gg");
            moveEvent?.Invoke();
        }
        public Chelovec(string name)
        {
            this.name = name;
        }
    }


    interface IMessage
    {
        string Text { get; set; }
    }
    interface IPrintable
    {
        void Print();
    }
    class Messages:IMessage,IPrintable
    {
        public string Text { get; set; }
        public Messages(string text)
        {
            Text = text;
        }
        public void Print() => Console.WriteLine(Text);
    }

    class Messanger<T> where T:IMessage,IPrintable
    {
        public void Send(T message)
        {
            Console.WriteLine("Sending...");
            message.Print();
        }
    }

    interface IUser<T>
    {
        T Id { get; }
    }
    class User<T>:IUser<T>
    {
        public T Id { get;}
        public User(T id)=> Id = id;
       
    }

    class Companya
    {
        public string Name { get; set; }
        public Companya(string name)=>Name = name;
    }
    class Clone:ICloneable,IComparable,IComparable<Clone>
    {
        public string Name { get; set; }        
        public int Age { get; set; }
        public Companya Work { get; set; }
        public Clone(string name, int age, Companya work)
        {
            Name = name;
            Age = age;
            Work = work;
        }

        object ICloneable.Clone()
        {
            //return new Clone(Name, Age);
            // return MemberwiseClone();
            return new Clone(Name, Age, new Companya(Work.Name));
        }

        public int CompareTo(object? obj)
        {
            if (obj is Clone clone)
            {
                return Name.CompareTo(clone.Name);
            }
            else
                throw new ArgumentException("invalid data");
        }

        public int CompareTo(Clone? other)
        {
            if (other is null) throw new NullReferenceException();
            else return Name.CompareTo(other.Name);
        }
    }
    class CloneComparer : IComparer<Clone>
    {
        public int Compare(Clone? x, Clone? y)
        {
            if (x is null || y is null)
                throw new NullReferenceException();
            return x.Name.Length - y.Name.Length;
        }
    }

    interface IMes<in T,out K>
    {
        K Write(string text);
        void Send(T message);
    }
    class Mes
    { 
        public string Text { get; set; }
        public Mes(string text) => Text = text;
    }
    class EmailMes:Mes
    {
        public EmailMes(string text) : base(text) { }
    }
    class SimpleMessanger : IMes<Message,EmailMes>
    {
        public void Send(Message message)
        {
            Console.WriteLine(message.Text);
        }

        public EmailMes Write(string text)
        {
            return new EmailMes(text);
        }
    }
    //IMessenger<EmailMessage, Message>,
    //IMessenger<Message, EmailMessage>,
    //IMessenger<Message, Message>
    //IMessenger<EmailMessage, EmailMessage>.




}
