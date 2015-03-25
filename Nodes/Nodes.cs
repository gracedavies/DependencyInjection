namespace Nodes
{
    using System.Collections.Generic;
    using System.Linq;

    public class A1 : INode
    {
        private readonly INode a2;
        private readonly INode c1;

        public A1(INode a2, INode c1)
        {
            this.a2 = a2;
            this.c1 = c1;
        }

        public IEnumerable<object> Go(string context)
        {
            return a2.Go(context)
                .Concat(c1.Go(context))
                .Concat(new[] { this });
        }
    }

    public class A2 : INode
    {
        private readonly A3 a3;
        private readonly B1 b1;

        public A2(A3 a3, B1 b1)
        {
            this.a3 = a3;
            this.b1 = b1;
        }

        public IEnumerable<object> Go(string context)
        {
            return a3.Go(context)
                .Concat(b1.Go(context))
                .Concat(new[] { this });
        }
    }

    public class A3 : INode
    {
        public IEnumerable<object> Go(string context)
        {
            return new[] { this };
        }
    }

    public class B1 : INode
    {
        private readonly B2 b2;

        public B1(B2 b2)
        {
            this.b2 = b2;
        }

        public IEnumerable<object> Go(string context)
        {
            return b2.Go(context)
                .Concat(new[] { this });
        }
    }

    public class B2 : INode
    {
        public IEnumerable<object> Go(string context)
        {
            return new[] { this };
        }
    }

    public class C1 : INode
    {
        private readonly INode b3;

        public C1(INode b3)
        {
            this.b3 = b3;
        }

        public IEnumerable<object> Go(string context)
        {
            return b3.Go(context)
                .Concat(new[] { this });
        }
    }

    public class B3 : INode
    {
        public IEnumerable<object> Go(string context)
        {
            return new[] { this };
        }
    }
}
