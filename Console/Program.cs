namespace AppConsole
{
    using System;
    using System.Linq;
    using Nodes;

    class Program
    {
        static void Main(string[] args)
        {
            var root =
                new A1(
                    new A2(
                        new A3(),
                        new B1(
                            new B2())),
                    new C1(new B3()));

            root.Go(string.Empty).ToList()
                .ForEach(x => Console.WriteLine(x.GetType().Name));

            Console.ReadKey();
        }
    }
}
