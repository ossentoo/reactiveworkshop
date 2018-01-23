

using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ReactiveConsole
{
    class Program
    {
        static event Action<int> Changed;

        private static Timer _timer;
        private static int _i;
        static void Main(string[] args)
        {
            _timer = new Timer(3000);
            _timer.Elapsed += TimerOnElapsed;
            Changed += Console.WriteLine;

            _timer.Start();

            Thread.Sleep(20000);
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Changed?.Invoke(_i);
            _i++;
        }
    }
}
