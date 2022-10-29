using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    internal class ParallelProgramingTPL
    {
        public static void Classtask()
        {
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            task1.Wait();
            task2.Wait();
            task3.Wait();

            Console.WriteLine("Main start");
            Task task4 = new Task(() =>
            {
                Console.WriteLine("Task start");
                Thread.Sleep(1000);
                Console.WriteLine("Task end");
            });
            task4.RunSynchronously();
            Console.WriteLine("Main end");
            Console.WriteLine();
            Console.WriteLine();
            Task task5 = new Task(() =>
            {
                Console.WriteLine($"Task{Task.CurrentId} start");
                Thread.Sleep(1000);
                Console.WriteLine($"Task{Task.CurrentId} end");
            });
            task5.Start();
            Console.WriteLine($"task5 Id: {task5.Id}");
            Console.WriteLine($"task5 is completed: {task5.IsCompleted}");
            Console.WriteLine($"task5 status: {task5.Status}");
            task5.Wait(); 
        }
        public static void TaskWork()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer start");
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner start");
                    Thread.Sleep(1000);
                    Console.WriteLine("Inner end");
                },TaskCreationOptions.AttachedToParent);
            });
            outer.Wait();
            Console.WriteLine("Main end");

            Task[] task1 = new Task[3]
            {
               new Task(()=>Console.WriteLine("First task")),
               new Task(()=>Console.WriteLine("Second Task")),
               new Task(()=>Console.WriteLine("Third task"))
            };

            foreach (var item in task1)
            {
                item.Start();
            }

            Task[] task2 = new Task[3];
            int j = 1;
            for (int i = 0; i < task2.Length; i++)
            {
                task2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));
            }
            Console.WriteLine();
            Console.WriteLine();
            Task[] task3 = new Task[3];
            for(var i=0;i<task3.Length;i++)
            {
                task3[i] = new Task(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task{i} finished");
                });
                task3[i].Start();
            }
            Console.WriteLine("Main finish");
            Task.WaitAll(task3);

            int n1 = 4, n2 = 5;
            Task<int> sumTask = new Task<int>(() =>Sum(n1,n2));
            sumTask.Start();
            int result = sumTask.Result;
            Console.WriteLine($"{n1}+{n2} = {result}");

            int Sum(int a, int b) => a + b;

            Task<Thr> defaultPers = new Task<Thr>(() => new Thr("Vlad", 18));
            defaultPers.Start();

            var default1 = defaultPers.Result;
            Console.WriteLine($"{default1.Name} - {default1.Age}");
        }
        public static void ContinueTask()
        {
            Task task1 = new Task(() => Console.WriteLine($"Id task: {Task.CurrentId}"));
            Task task2 = task1.ContinueWith(PrintTask);

            task1.Start();

            task2.Wait();
            Console.WriteLine("Main end");

            void PrintTask(Task t)
            {
                Console.WriteLine($"Id task: {Task.CurrentId}");
                Console.WriteLine($"Id task before: {t.Id}");
            }

            int a = 5, b = 6;

            Task<int> task3 = new Task<int>(() => a + b);

            Task print = task3.ContinueWith(task => PrintResult(task.Result));

            task3.Start();

            print.Wait();

            Console.WriteLine("Main end");

            void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");

            Task first = new Task(() => Console.WriteLine($"Task id: {Task.CurrentId}"));

            Task second = first.ContinueWith(task => Console.WriteLine($"Task id: {Task.CurrentId}\tPrevious id: {task.Id}"));

            Task third = second.ContinueWith(task => Console.WriteLine($"Task id: {Task.CurrentId}\tPrevious id: {task.Id}"));

            first.Start();

            third.Wait();
        }
        public static void ClassParalel()
        {
            Parallel.Invoke(
                Print,
                () =>
                {
                    Console.WriteLine(); Console.WriteLine($"Task id: {Task.CurrentId} second");
                    Thread.Sleep(3000);
                },
                ()=>Square(5)

            );
            void Print()
            {
                Console.WriteLine($"Task id: {Task.CurrentId} first");
                Thread.Sleep(3000);
            }
            void Square(int n)
            {
                Console.WriteLine($"Task id: {Task.CurrentId} third");
                
                Console.WriteLine($"Result: {n*n}");
                Thread.Sleep(3000);
            }

            Console.WriteLine();
            Console.WriteLine();

            Parallel.For(1, 5, Square);

            var a = Parallel.ForEach<int>(
                new List <int>(){ 6,7,8,9,10},
                Square
            );

            Thread.Sleep(5000);

            Console.WriteLine();
            Console.WriteLine();

            var tmp = Parallel.For(1, 10, Square1);
            if(!tmp.IsCompleted)
            {
                Console.WriteLine($"Выполнение завершено на итерации {tmp.LowestBreakIteration}");
            }


            void Square1(int n,ParallelLoopState pls)
            {
                if (n == 5) pls.Break();

                Console.WriteLine($"Квадрат числа {n} равен {n*n}");
                Thread.Sleep(2000);
            }
        }
        public static void Cancel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = new Task(() =>
            {
                for(int i = 0; i < 10; i++)
                {
                    if(token.IsCancellationRequested)
                    {
                        Console.WriteLine("Оперция прервана");
                        return;
                    }
                    Console.WriteLine($"Квадрат числа {i} равен {i*i}");
                    Thread.Sleep(200);
                }
            },token);

            task.Start();

            Thread.Sleep(1000);

            cancellationTokenSource.Cancel();

            Thread.Sleep(1000);

            Console.WriteLine($"Status: {task.Status}");

            cancellationTokenSource.Dispose();

            Console.WriteLine();
            Console.WriteLine();

            CancellationTokenSource cancellationTokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = cancellationTokenSource1.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token1.IsCancellationRequested)
                    {
                        token1.ThrowIfCancellationRequested();
                    }
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token1);

            try
            {
                task1.Start();

                Thread.Sleep(1000);
                cancellationTokenSource1.Cancel();
                task1.Wait();

            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    if(item is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(item.Message);
                }
                
            }
            finally
            {
                cancellationTokenSource1.Dispose();
            }

            Console.WriteLine();
            Console.WriteLine();


            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = cancellationTokenSource2.Token;

            Task task2 = new Task(() =>
            {
                int i = 1;
                token2.Register(() =>
                {
                    Console.WriteLine("операция прервана");
                    i = 10;
                });
                for(;i<10;i++)
                {
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(400);
                }
            }, token2);

            task2.Start();

            Thread.Sleep(1000);

            cancellationTokenSource2.Cancel();

            Thread.Sleep(1000);

            Console.WriteLine($"Status: {task2.Status}");

            cancellationTokenSource2.Dispose();
        }

    }
}
