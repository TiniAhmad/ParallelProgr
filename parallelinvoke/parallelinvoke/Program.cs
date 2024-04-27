using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace parallelinvoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };

            int intResult = 0;
            string strResult = string.Empty;

            //Calling Three methods Parallely
            Parallel.Invoke(
                () => intResult = MethodA(),
                () => strResult = MethodB("Pranaya"),
                () => MethodC(100)
            );
            Console.WriteLine($"Method1 Result: {intResult}");
            Console.WriteLine($"Method2 Result: {strResult}");
            Console.WriteLine($"Parallel Execution Completed");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Calling Three methods Parallely
            Parallel.Invoke(
                 Method1, Method2, Method3
            );
            stopWatch.Stop();
            Console.WriteLine($"Parallel Execution Took {stopWatch.ElapsedMilliseconds} Milliseconds");

            Parallel.Invoke(parallelOptions,
                    () => DoSomeTask(1),
                    () => DoSomeTask(2),
                    () => DoSomeTask(3),
                    () => DoSomeTask(4),
                    () => DoSomeTask(5),
                    () => DoSomeTask(6),
                    () => DoSomeTask(7)
                );


            
            Console.ReadKey();
        }
        static void Method1()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method2()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method3()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }

        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            //Sleep for 5000 milliseconds
            Thread.Sleep(5000);
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static int MethodA()
        {
            Task.Delay(200);
            Console.WriteLine($"Method A Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return 100;
        }
        static string MethodB(string name)
        {
            Task.Delay(200);
            Console.WriteLine($"Method B Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return "Hello:" + name;
        }
        static void MethodC(int number)
        {
            Task.Delay(200);
            Console.WriteLine($"Method C Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
    }
    
}
