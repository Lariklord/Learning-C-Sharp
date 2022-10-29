using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class PatternMatching
    {
        public static void TypePatern()
        {
            Empl tom = new Manager();
            UseEmployee(tom);

            void UseEmployee(Empl emp)
            {
                if (emp is Manager manager && manager.IsOnVacation == false)
                    manager.Work();
                else
                    Console.WriteLine("преобразование недопустимо");
            }

            var message = "hello";
            if(message is "hello")
                Console.WriteLine("hello");

            Empl? bob = new Empl();
            Empl? jack = null;
            UseEmployee1(bob);
            UseEmployee1(jack);
            void UseEmployee1(Empl? emp)
            {
                if (emp is not null)
                    emp.Work();
            }

            Empl bob1 = new Manager() { IsOnVacation = true };
            Empl tom1 = new Manager() { IsOnVacation = false };
            UseEmployee2(bob1);//dont work
            UseEmployee2(tom1);//work
            void UseEmployee2(Empl? emp)
            {
                switch(emp)
                {
                    case Manager manager when !manager.IsOnVacation:
                        manager.Work();
                        break;
                    case null:
                        Console.WriteLine("null");
                        break;
                    default:
                        Console.WriteLine("emp dont work");
                        break;
                }
            }
        }
        public static void PropertyPatern()
        {
            TgUser tom = new TgUser { Language = "english", Status = "user", Name = "Tom" };
            TgUser bob = new TgUser { Language = "french", Status = "user", Name = "Bob" };
            SayHello(bob);
            SayHello(tom);
            void SayHello(TgUser user)
            {
                if(user is TgUser { Language:"french", Status:"admin"})
                    Console.WriteLine("salut admin");
                else
                    Console.WriteLine("hello");
            }
            string GetMessage(TgUser? user) => user switch
            {
                { Language:"english"}=>"hello",
                { Language: "german" } => "hallo",
                { Language: "russian" } => "priv",
                {Language: var lang }=>$"unknown lang {lang}",
                null=>"null"
            };
        }
        public static void CortegePatern()
        {
            string GetWelcome(string lang, string daytime,string status) => (lang, daytime,status) switch
            {
                ("english","morning",_)=>"gm",
                ("english", "evening",_) => "ge",
                (_,_,"admin")=>"hi admin",
                _=>"bb"
            };
        }
        public static void PositionPatern()
        {
            string GetWelcome(TgUser user) => user switch
            { 
                ("vlad","admin",_)=>"hi admin vlad",
                (_,"admin","rus")=>"здарова админ",
                (_,"user","eng")=>"hi user",
                (var name,var status,var lang)=>$"hi {name}, {lang} not found",
                _=>"priv"
            };
        }
        public static void RelyacAndLogicPatern()
        {
            decimal Calculate(decimal sum)//реляционный
            {
                return sum switch
                { 
                    <= 0 => 0,
                    < 50000 => sum*0.05m,
                    <100000 => sum*0.1m,
                    _=>sum*0.2m
                };
            }
            string CheckAge(int age)
            {
                return age switch
                {
                    <1 or >110 =>"error",
                    >=1 and <18 =>"bb baby",
                    not 33 =>"ne 33",
                    _=>"gg"
                };
            }
        }
        public static void SpisokPatern()
        {
            /*int GetNumber(int[] values) => values switch
            {
                [1,2,..,4,5]=>1,
                [1,_,3]=>2,
                [1,2]=>3,
                []=>4,
                _=>5

                if(values is [1,2,3,4,5])
            };*/
        }
    }
    class Empl
    {
        public virtual void Work() => Console.WriteLine("empl work");
    }
    class Manager:Empl
    {
        public override void Work() => Console.WriteLine("manager work");
        public bool IsOnVacation { get; set; }
    }

    class TgUser
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Language { get; set; }
        public void Deconstruct(out string name,out string status,out string lang)
        {
            name = Name;
            status = Status;
            lang = Language;
        }
    }
    

}
