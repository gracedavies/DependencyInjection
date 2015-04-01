namespace AppConsole
{
    using System;
    using System.Linq;
    using Nodes;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    class Program
    {
        static void Main(string[] args)
        {
            //var root =
            //    new A1(
            //        new A2(
            //            new A3(),
            //            new B1(
            //                new B2())),
            //        new C1(new B3()));

            //root.Go(string.Empty).ToList()
            //    .ForEach(x => Console.WriteLine(x.GetType().Name));

            var container = new WindsorContainer();

            container.Register(Component.For<INode>().ImplementedBy<B3>().Named("B3"));
            container.Register(Component.For<INode>().ImplementedBy<B2>().Named("B2"));
            container.Register(Component.For<INode>().ImplementedBy<A3>().Named("A3"));
            container.Register(Component.For<INode>().ImplementedBy<C1>().Named("C1").DependsOn(container.Resolve<INode>("B3")));
            container.Register(Component.For<INode>().ImplementedBy<B1>().Named("B1").DependsOn( new { B2 = container.Resolve<INode>("B2") }));
            container.Register(Component.For<INode>().ImplementedBy<A2>().Named("A2").DependsOn( new { A3 = container.Resolve<INode>("A3"), B1 = container.Resolve<INode>("B1")} )); 
            container.Register(Component.For<INode>().ImplementedBy<A1>().Named("A1").DependsOn( new { A2 = container.Resolve<INode>("A2"), C1 = container.Resolve<INode>("C1") })); 

            var root = container.Resolve<INode>("A1");

            root.Go(string.Empty).ToList().ForEach(x => Console.WriteLine(x.GetType().Name));

            Console.ReadKey();
        }
    }
}
