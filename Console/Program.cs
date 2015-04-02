using StructureMap;

namespace AppConsole
{
    using System;
    using System.Linq;
    using Nodes;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    //Examples using Castle Windsor and Structure Map

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

            //var container = new WindsorContainer();
            //container.Install(new NodeInstaller());
            //var root = container.Resolve<INode>("A1");
            //root.Go(string.Empty).ToList().ForEach(x => Console.WriteLine(x.GetType().Name));

            var container = new Container();

            //container.Configure(r => r.For<INode>().Use<B3>().Named("B3"));
            //container.Configure(r => r.For<INode>().Use<B2>().Named("B2"));
            //container.Configure(r => r.For<INode>().Use<A3>().Named("A3"));
            //container.Configure(r => r.For<INode>().Use<C1>().Named("C1").Ctor<INode>("B3").Is(i => i.GetInstance<INode>("B3")));
            //container.Configure(r => r.For<INode>().Use<B1>().Named("B1").Ctor<INode>("B2").Is(i => i.GetInstance<INode>("B2")));
            //container.Configure(r => r.For<INode>().Use<A2>().Named("A2").Ctor<INode>("A3").Is(i => i.GetInstance<INode>("A3")).Ctor<INode>("B1").Is(i => i.GetInstance<INode>("B1")));
            //container.Configure(r => r.For<INode>().Use<A1>().Named("A1").Ctor<INode>("A2").Is(i => i.GetInstance<INode>("A2")).Ctor<INode>("C1").Is(i => i.GetInstance<INode>("C1")));

            container.Configure(congig =>
            {
                var B3 = congig.For<INode>().Use<B3>();
                var B2 = congig.For<INode>().Use<B2>();
                var A3 = congig.For<INode>().Use<B2>();
                var C1 = congig.For<INode>().Use<C1>().Ctor<INode>().Is(B3);
                var B1 = congig.For<INode>().Use<B1>().Ctor<INode>().Is(B2);
                var A2 = congig.For<INode>().Use<A2>().Named("A2").Ctor<INode>().Is(A3).Ctor<INode>().Is(B1);
                congig.For<INode>().Use<A1>().Named("A1").Ctor<INode>().Is(A2).Ctor<INode>().Is(C1);
            });
            
            //Why does this not work?!?! ;'(
           
            var test = container.GetInstance<INode>("A2");

            test.Go(string.Empty).ToList().ForEach(x => Console.WriteLine(x.GetType().Name));

            Console.ReadKey();
        }
    }
}
