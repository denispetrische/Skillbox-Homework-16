using System;
using System.Threading;
using System.Threading.Tasks;

namespace mainNamespace
{
    class Skillbox_Homework_16
    {
        static async Task Main()
        {
            var firstThread = new Thread(ConsoleOutputThread);
            var secondThread = new Thread(ConsoleOutputThread);
            var thirdThread = new Thread(ConsoleOutputThread);

            var firstTask = ConsoleOutputTask(6000);
            var secondTask = ConsoleOutputTask(5000);
            var thirdTask = ConsoleOutputTask(4000);

            firstThread.Start(3000);
            secondThread.Start(2000);
            thirdThread.Start(1000);

            await firstTask;
            await secondTask;
            await thirdTask;

            Console.ReadKey();
        }

        private static void ConsoleOutputThread(object? millis)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} с задержкой {millis} начал работу");
            Thread.Sleep(Convert.ToInt32(millis));
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} с задержкой {millis} закончил работу");
        }

        private static async Task ConsoleOutputTask(int millis)
        {
            Console.WriteLine($"Задача с задержкой {millis} начала работу");
            await Task.Delay(millis);
            Console.WriteLine($"Задача с задержкой {millis} закончила работу");
        }
    }
}

