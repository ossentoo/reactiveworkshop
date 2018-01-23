using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = GetInput().ToObservable(Scheduler.NewThread);

            var res = from s in src
                group s by s.Length;

            res.ForEach(g =>
            {
                Console.WriteLine($"New group with length {g.Key}");
                g.Subscribe(x=> Console.WriteLine($"  {x} member of {g.Key}"));
            });
        }

        static IEnumerable<string> GetInput()
        {
            while (true)
                yield return Console.ReadLine();
        }
    }
}
