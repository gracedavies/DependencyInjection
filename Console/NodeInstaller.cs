namespace AppConsole
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Nodes;

    public class NodeInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            
            container.Register(Component.For<INode>().ImplementedBy<B3>().Named("B3"));
            container.Register(Component.For<INode>().ImplementedBy<B2>().Named("B2"));
            container.Register(Component.For<INode>().ImplementedBy<A3>().Named("A3"));
            container.Register(Component.For<INode>().ImplementedBy<C1>().Named("C1").DependsOn(container.Resolve<INode>("B3")));
            container.Register(Component.For<INode>().ImplementedBy<B1>().Named("B1").DependsOn(new { B2 = container.Resolve<INode>("B2") }));
            container.Register(Component.For<INode>().ImplementedBy<A2>().Named("A2").DependsOn(new { A3 = container.Resolve<INode>("A3"), B1 = container.Resolve<INode>("B1") }));
            container.Register(Component.For<INode>().ImplementedBy<A1>().Named("A1").DependsOn(new { A2 = container.Resolve<INode>("A2"), C1 = container.Resolve<INode>("C1") })); 

        }
    }
}
