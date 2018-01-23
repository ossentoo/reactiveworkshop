using System;
using System.Collections.Generic;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var s in GetInput())
                Console.WriteLine(s);
        }

        static IEnumerable<string> GetInput()
        {
            while (true)
                yield return Console.ReadLine();
        }
    }
}
