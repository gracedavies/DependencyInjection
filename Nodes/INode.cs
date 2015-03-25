namespace Nodes
{
    using System.Collections.Generic;

    public interface INode
    {
        IEnumerable<object> Go(string context);
    }
}
