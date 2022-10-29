using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class DelEveLyam
    {
        delegate void Messsage();
        public delegate int Operation(int x, int y);
        delegate T Operation1<T, K>(K val);
        public static void Hello() => Console.WriteLine("Welcome to hell");
        public static void HowAreYou() => Console.WriteLine("How are you?");
        public static void Base()
        {
            Messsage? mes = new Messsage(Hello);
            mes += HowAreYou;
            mes += HowAreYou;
            mes -= HowAreYou;
            if(mes!= null) mes();

            Messsage mes1 = Hello;
            Messsage mes2 = HowAreYou;

            Messsage mes3 = mes1 + mes2;
            mes3?.Invoke();

            Operation1<decimal, int> a = Square;
            Console.WriteLine(a.Invoke(5));

            Operation1<double, int> b = Sum;
            Console.WriteLine(b.Invoke(5));
          
        }
        void DoOperation(int x, int y, Operation operation)
        {
            Console.WriteLine(operation.Invoke(x,y));
        }
        public static Operation? Select(OperationType type) => type switch
        {
            OperationType.Add=>Add,
            OperationType.Subtract=>Remove,
            OperationType.Multiply=>Multiply,
            _=>null

        };
        public static void Make()
        {
            Operation? op = Select(OperationType.Add);
            Console.WriteLine(op?.Invoke(10, 15));
        }
        public enum OperationType
        { 
            Add,Subtract,Multiply
        }
        public static decimal Square(int n) => n * n;
        public static double Sum(int b) => b + b;
        public static int Add(int x, int y) => x + y;
        public static int Remove(int x, int y) => x - y;
        public static int Multiply(int x,int y) => x * y;
        public static void Operat()
        {
            Operation operation;

            operation = Add;
            Console.WriteLine(operation(5,4));
            Console.WriteLine();

            operation = Remove;
            Console.WriteLine(operation(5,4));
            Console.WriteLine();

            operation = Multiply;
            Console.WriteLine(operation(5, 4));
            Console.WriteLine();
        }
    }
    public delegate void AccountHandler(string message);
    public class Account
    {
        int sum;
        AccountHandler? taken;
        public Account(int sum) => this.sum = sum;
        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }
        public void UnregisterHandler(AccountHandler del)
        {
            taken -= del;
        }
        public void Add(int sum) => this.sum += sum;
        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                taken?.Invoke($"С вашего счета списано {sum} y.e");
            }
            else
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} y.e");
        }
    }
    public class Anonym
    {
        public delegate void MessageHandler(string message);
        public static void Syntax()
        {
            MessageHandler handler = delegate (string mes)
            {
                Console.WriteLine(mes);
            };

            handler?.Invoke("Helloy");
        }
        public static void Param(string message,MessageHandler handler)
        {
            handler?.Invoke(message);   
        }
        public static void Doing()
        {
            Param("Helloy", delegate (string mes)
            {
                Console.WriteLine(mes);
            });
        }   
    }
    public class Lyambda
    {
        public delegate void MessageHandler();
        public delegate void OperationHandler(int x, int y);
        public delegate void PrintHandler(string message);
        public delegate T DoOperation<T> (T x, T y);
        public delegate int Operat(int x, int y);
        public static void Syntax()
        {
            MessageHandler hello = () => Console.WriteLine("Hello");
            MessageHandler hello2 = () =>
            {
                Console.WriteLine("hello");
                Console.WriteLine("world");
            };

            var hello3 = () => Console.WriteLine("hello");

            OperationHandler sum = (x, y) => Console.WriteLine(x+y);
            var sum1 = (int x,int y) => Console.WriteLine(x+y);
            var substract = (int x, int y) =>
            {
                if (x > y) return x - y;
                else return y - x;
            };

            PrintHandler print = message => Console.WriteLine(message);

            DoOperation<int> multiply = (int x, int y) => x * y;
            DoOperation<string> concat = (string first, string second) => first + second;
        }
        public static void Add()
        {
            var hello = () => Console.WriteLine("hello");
            var message = () => Console.WriteLine("gg");

            message += () => Console.WriteLine("stfu");
            message += hello;
            message -= hello;
            message += hello;

            message.Invoke();
        }
        delegate bool IsEqual(int x);
        public static void Argument()
        {
            Console.WriteLine(Sum(x=>x>0,-5,2,4,46,76,-234,34));
            int result = Sum(x => x % 2 == 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }
        static int Sum(IsEqual func, params int[] arr) => arr.Where(x => func(x)).Sum();
        public enum OpeationType
        {
            Add,Substract,Multiply
        }
        public static Operat Select(OpeationType type)
        {
            switch (type)
            {
                case OpeationType.Add: return (x, y) => x + y;
                case OpeationType.Substract: return (x, y) => x - y;
                default: return (x, y) => x * y;
            }
        }
        public static void Choose()
        {
            Operat sum = Select(OpeationType.Add);
            Console.WriteLine(sum(1,9));
        }
    }
    public class Event
    {
        public delegate void AccountHandler(Event sender,EventArgs e);
        AccountHandler? notify;
        public event AccountHandler Notify
        {
            add
            {
                notify += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                notify -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }
        public int Sum { get; set; }
        public Event(int sum)=> Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            notify?.Invoke(this,new EventArgs($"На счет поступило: {sum}",sum));
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                notify?.Invoke(this,new EventArgs($"Со счета снято: {sum}",sum));
            }
            else
            {
                notify?.Invoke(this,new EventArgs($"Недостаточно средств на счете.",sum));
            }
        }
    }
    public class EventArgs
    {
        public string Message { get;}
        public int Sum { get; }
        public EventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }

    public class Message
    {
        public string Text { get; }
        public Message(string text) => Text = text;
        public virtual void Print() => Console.WriteLine($"Message: {Text}");
    }
    public class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
        public override void Print() => Console.WriteLine($"Email: {Text}");
    }
    public class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
        public override void Print() => Console.WriteLine($"Sms: {Text}");
    }
    class Kovar
    {
        public  delegate Message MessageBuilder(string text);//ковариантность
        public delegate void EmailReceiver(EmailMessage message);//контрвариантность
        public delegate T MessageBuilder1<out T>(string text);//ковариантность
        public delegate void MessageReceiver<in T>(T message);//контрвариантность
        public delegate E MessageConverter<in M,out E>(M message);// оба
        public static void Syntax()
        {
            MessageBuilder messageBuilder = WriteEmailMessage;
            Message message = messageBuilder("Hello");
            message.Print();
            EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);

            EmailReceiver emailBox = ReceiveMessage;
            emailBox(new EmailMessage("Welcome"));
            void ReceiveMessage(Message message) => message.Print();
        
            MessageBuilder1<Message> messageBuilder1 = WriteEmailMessage;
            Message message1 = messageBuilder1("larik");
            message1.Print();

            MessageReceiver <EmailMessage> messageReceiver = ReceiveMessage;
            messageReceiver(new EmailMessage("dodik"));

            MessageConverter<SmsMessage, Message> converter = ConvertToEmail;
            Message message2 = converter(new SmsMessage("delegates"));
            message2.Print();
            EmailMessage ConvertToEmail(Message message) => new EmailMessage(message.Text);
        } 
    }

    class NetDelegates
    {
        public void Action()
        {
            DoOperation(1, 2, Add);
            DoOperation(3, 4, Multiply);
            void DoOperation(int a, int b, Action<int, int > op) => op(a, b);
            void Add(int x, int y) => Console.WriteLine(x+y);
            void Multiply(int x, int y) => Console.WriteLine(x * y);
        }
        public void Predicate()
        {
            Predicate<int> IsPositive = (int x) => x > 0;
            Console.WriteLine(IsPositive(5));
            Console.WriteLine(IsPositive(-5));
        }
        public void Func()
        {
            int result1 = DoOperation(2, DoubleNumber);
            int result2 = DoOperation(3, SquareNumber);

            int DoOperation(int a, Func<int, int> op) => op(a);
            int DoubleNumber(int n) => 2 * n;
            int SquareNumber(int n) => n * n;

            Func<int, int,string> createString =(a,b) =>$"{a} {b}";
            Console.WriteLine(createString(1,2));
            Console.WriteLine(createString(22,8));
        }
    }
    class Closure
    {
        public void Local()
        {
            var fn = Outer;
            fn();//6
            fn();//7
            fn();//8
            Action Outer()//внешняя функ
            {
                int x = 5;//лекс окружение
                void Inner()//локальная функ
                {
                    x++;//операция с лекс окружением
                    Console.WriteLine(x);
                }
                return Inner;//возврат лок функ
            }
        }
        public void Lyamda()
        {
            var outerFn = () =>
            {
                int x = 10;
                var innerFn = () => Console.WriteLine(++x);
                return innerFn;
            };

            var fn = outerFn();
            fn();//11
            fn();//12
            fn();//13
        }
        public void Param()
        {
            var multiply = (int n) => (int m) => n * m;
            var fn = multiply(5);//n
            Console.WriteLine(fn(5));//m
            Console.WriteLine(fn(6));//m
            Console.WriteLine(fn(7));//m
        }
    }




}
