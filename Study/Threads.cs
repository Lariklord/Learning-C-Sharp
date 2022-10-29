using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Study
{
    internal class Threads
    {
        public static void ThreadClass()
        {
            Thread current = Thread.CurrentThread;

            Console.WriteLine($"Имя: {current.Name}");
            current.Name = "Main";
            Console.WriteLine($"Имя: {current.Name}");

            Console.WriteLine($"Запущен: {current.IsAlive}");
            Console.WriteLine($"Id: {current.ManagedThreadId}");
            Console.WriteLine($"Приоритет: {current.Priority}");
            Console.WriteLine($"Статус: {current.ThreadState}");
            Console.WriteLine($"Культура: {current.CurrentCulture}");
            Console.WriteLine($"Контекст: {current.ExecutionContext}");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i);
            }
        }
        public static void ThreadStartDel()
        {
            Thread thread1 = new Thread(() => Console.WriteLine("Hello thread"));
            Thread thread2 = new Thread(new ThreadStart(Print));
            Thread thread3 = new Thread(Print);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(200);
            void Print() => Console.WriteLine("Hello thread");

            Thread myThread = new Thread(Print1);

            myThread.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Главный поток: {i}");
                Thread.Sleep(300);
            }

            void Print1()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Второй поток: {i}");
                    Thread.Sleep(500);
                }
            }
        }
        public static void Parameterized()
        {

            Thread thread1 = new Thread(Print);
            Thread thread = new Thread(Print1);

            thread1.Start(4);
            thread.Start(new Thr("Vlad", 18));

            void Print(object? num)
            {
                if (num is int n)
                    Console.WriteLine($"n*n = {n * n}");
            }
            void Print1(object? obj)
            {
                if (obj is Thr pers)
                {
                    Console.WriteLine($"Name: {pers.Name}");
                    Console.WriteLine($"Age: {pers.Age}");
                }
            }
        }
        public static void Synxronized()
        {
            int x = 0;
            object locker = new();
            for (int i = 1; i < 6; i++)
            {
                Thread thread = new(Print);
                thread.Name = $"Поток {i}";
                thread.Start();
            }
            void Print()
            {
                lock (locker)
                {
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }
                }

            }
        }
        public static void MonitorClass()
        {

            int x = 0;
            object locker = new();
            for (int i = 1; i < 6; i++)
            {
                Thread thread = new(Print);
                thread.Name = $"Поток {i}";
                thread.Start();
            }
            void Print()
            {
                bool acquiredLock = false;
                try
                {
                    Monitor.Enter(locker, ref acquiredLock);
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }

                }
                finally
                {
                    if (acquiredLock) Monitor.Exit(locker);
                }
            }
        }
        public static void AutoReset()
        {
            int x = 0;

            AutoResetEvent waitHandler = new AutoResetEvent(true);

            for(int i=1;i<6;i++)
            {
                Thread thread = new Thread(Print);
                thread.Name = $"Поток {i}";
                thread.Start();
            }

            void Print()
            {
                waitHandler.WaitOne();
                x = 1;
                for(int i=1;i<6;i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
                waitHandler.Set();
            }
        }
        public static void Mute()
        {
            int x = 0;
            Mutex mutex = new Mutex();

            for (int i = 1; i < 6; i++)
            {
                Thread thread = new Thread(Print);
                thread.Name = $"Поток {i}";
                thread.Start();
            }

            void Print()
            {
                mutex.WaitOne();
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
                mutex.ReleaseMutex();
            }
        }
        public static void Semafor()
        {
            for(int i=1;i<6;i++)
            {
                Reaader tmp = new Reaader(i);
            }
        }

    }
    record class Thr(string Name, int Age);
    class Reaader
    {
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;
        public Reaader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i}";
            myThread.Start();
        }
        public void Read()
        {
            while(count>0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");

                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} освобождает место");

                sem.Release();

                count--;
                Thread.Sleep(1000);

            }
        }
   
    }

}
