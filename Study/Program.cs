using Study;

/*
static void Helloy()
{
    Console.Write("Введите свое имя: ");
    {
        string? name = Console.ReadLine();// ? - мб null
        Console.WriteLine($"Привет {name}");
    }
}
*/

//Base.Checked();

//Base.Sum(1, 2, 3, 4, 5, 6, 6, 7,8,9,10);

//Console.WriteLine(Base.Factorial(5));

//Console.WriteLine(Base.Fibo(7));

//Console.WriteLine(Base.DoOperation(2, 13, 3));

//Base.Enums();

//Person a = new();//можно не указывать название класс
//(_, int age) = a;
//(string name, int age) = a;


//SPerson tom = new SPerson() { age = 0, name = "Tom" };
//SPerson bob = tom with { name = "Bob" };// с помощью with копируется структура
//People people = new Employee { Name = "Vlad" };

/*
People a = new People();
Employee b = new Employee();
People c = new Employee();
a.Print();
b.Print();
c.Print();
*/

/*
People a = new People { Name = "Vlad" };
People b = new People { Name = "Vlad" };
Console.WriteLine(a.Equals(b));
*/

/*
try
{
    FindCatch.Method1();
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Catch Main: {ex.Message}");
}
finally
{
    Console.WriteLine("Finally Main");
}*/

//DelEveLyam.Base();
//DelEveLyam.Operat();
//DelEveLyam.Make();
//Anonym.Syntax();

/*
Event account = new Event(100);
account.Notify += Display;
account.Notify += DisplayRed;
account.Notify += delegate (string message)
{
    Console.WriteLine(message);
};
account.Notify += message => Console.WriteLine(message);
account.Put(20);
account.Notify -= DisplayRed;
Console.WriteLine($"Сумма на счете: {account.Sum}");
account.Take(70);
Console.WriteLine($"Сумма на счете: {account.Sum}");
account.Take(100);
Console.WriteLine($"Сумма на счете: {account.Sum}");
void Display(string message) => Console.WriteLine(message);
void DisplayRed(string message)
{
    Console.ForegroundColor= ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}
*/

/*
Event acc = new Event(100);
acc.Notify += Display;
acc.Put(20);
acc.Take(70);
acc.Take(150);
void Display(Event sender,Study.EventArgs e)
{
    Console.WriteLine($"Сумма транзакции: {e.Sum}");
    Console.WriteLine(e.Message);
    Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
}
*/

//string str = "sosi huy";
//Console.WriteLine(str.CharCount('s'));
//StringWork.FormatAndInterpolation();
//StringWork.StringBuilder();
//StringWork.Regex();
//DateAndTime.DateTimeMethods();
//DateAndTime.FormatDay();

//Threads.ThreadClass();
//Threads.ThreadStartDel();
//Threads.Parameterized();
//Threads.Synxronized();
//Threads.AutoReset();
//Threads.Mute();
//Threads.Semafor();

//ParallelProgramingTPL.Classtask();
//ParallelProgramingTPL.TaskWork()
//ParallelProgramingTPL.ContinueTask();
//ParallelProgramingTPL.ClassParalel();
//ParallelProgramingTPL.Cancel();

//Async.AsyncAwaitAsync();

/*
ForAsync a = new ForAsync();
a.Added += PrintAsync;
a.Put(500);

await Task.Delay(2000);
async void PrintAsync(object? obj, string mes)
{
    await Task.Delay(1000);
    Console.WriteLine(mes);
}

var task = PrintAsync1("vlad");
Console.WriteLine("main end");

await task;

async Task PrintAsync1(string mes)
{
    await Task.Delay(0);
    Console.WriteLine(mes);
}

int n1 = await SquareAsync(5);
int n2 = await SquareAsync(6);

async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    return n*n;
}
*/

/*
var task1 = PrintAsync("gg");
var task2 = PrintAsync("wp");
var task3 = PrintAsync("ff");

await Task.WhenAny(task1, task2, task3);

async Task PrintAsync(string mes)
{
    Random random = new Random();
    await Task.Delay(random.Next(5000));
    Console.WriteLine(mes);
}

var task4 = SquareAsync(2);
var task5 = SquareAsync(3);
var task6 = SquareAsync(4);

var a = await Task.WhenAll(task4, task5, task6);

foreach (var item in a)
{
    Console.WriteLine(item);
}
Console.WriteLine(task4.Result);

async Task<int> SquareAsync(int n)
{
    await Task.Delay(1000);
    return n*n;
}
*/

/*
var task = PrintAsync("Hi");
var task1 = PrintAsync("gg");
var task2 = PrintAsync("ff");
var task3 = PrintAsync("good");

var all = Task.WhenAll(task, task1, task2, task3);
try
{
    await all;
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(all.IsFaulted);
    if(all.Exception is not null)
    {
        foreach (var item in all.Exception.InnerExceptions)
        {
            Console.WriteLine(item.Message);
        }
    }
   
}

async Task PrintAsync(string mes)
{
    if (mes.Length < 3)
        throw new ArgumentException("Invalid");
    await Task.Delay(100);
    Console.WriteLine(mes);
}
*/

/*
await foreach (var item in GetNumberAsync())
{
    Console.WriteLine(item);
}
async IAsyncEnumerable<int> GetNumberAsync()
{
    for(int i=0;i<10;i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}*/


//Linq.MainLinq();
//Linq.Proection();
//Linq.Filter();
//Linq.Sort();
//Linq.ExceptIntersectUnionDistinct();
//Linq.Agregate();
//Linq.SkipTake();
//Linq.Group();
//Linq.Join();
//Linq.Check();
//Linq.DeferredImmediate();
//Linq.Parallel();
//Linq.Ordered();
//Linq.Cancel();

//Reflection.TypeClass();
//Reflection.GetMembersMetod()
//Reflection.GetMethodsMethod();
//Reflection.GetFieldsMethod();
//Reflection.AssemblyClass();
//Reflection.AttributeClass();

//DLR.DynamicWord();
//DLR.DynamicAndExpandoObj();

//Files.Drivs();
Files.Catalogs();