

using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ReactiveConsole
{
    class Program
    {

        private static Timer _timer;
        private static int _i, _lastValue;
        private static Subject<int> Changed2;
        static void Main(string[] args)
        {
            Changed2 = new Subject<int>();
            var observable = Changed2.Subscribe(x=>
            {
                _lastValue = x;

                Console.WriteLine(x);
            });

            _timer = new Timer(3000);
            _timer.Elapsed += TimerOnElapsed;

            _timer.Start();

            Thread.Sleep(10000);

            observable.Dispose();

            Thread.Sleep(6000);

        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Changed2.OnNext(_i);

            if (_lastValue < _i)
            {
                Console.WriteLine($"{_i} not changed");
            }

            _i++;
        }
    }
}
