using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class Async
    {
        public static async Task AsyncAwaitAsync()
        {
            PrintAsync();
            Console.WriteLine("продолжаем мэйн");
            Thread.Sleep(5000);
            Console.WriteLine("заканчиваем мэйн");

            void Print()
            {
                Thread.Sleep(3000);
                Console.WriteLine("Durak");
            }
            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода");
                await Task.Run(() => Print());
                await Task.Delay(3000);
                Console.WriteLine("Конец метода");
            }
            Task a1 = PrintNameAsync("Vlad");
            Task a2 = PrintNameAsync("Kostya");
            Task a3 = PrintNameAsync("Vanya");

            await a1;
            await a2;
            await a3;

            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);
                Console.WriteLine(name);
            }

            Func<string, Task> printer = async (message) =>
            {
                await Task.Delay(3000);
                Console.WriteLine(message);
            };

            await printer("gg");
            await printer("wp");
        }
        public static async void Vozvrat()
        {
            ForAsync a = new ForAsync();
            a.Added += PrintAsync;
            a.Put(500);

            await Task.Delay(2000);
           async void PrintAsync(object? obj, string mes)
            {
                await Task.Delay(1000);
                Console.WriteLine(mes);
            }
        }
    }
    class ForAsync
    {
        int sum = 0;
        public event EventHandler<string>? Added;
        public void Put(int sum)
        {
            this.sum += sum;
            Added?.Invoke(this, $"На счетпоступило {sum}");
        }
    }
}
