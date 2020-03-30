
using System.Collections.Generic;

namespace ICreative.Menu
{
    public interface ISiteMapNodeCollection
        : IList<IMenuNode>, ICollection<IMenuNode>, IEnumerable<IMenuNode>
    {
        void AddRange(IEnumerable<IMenuNode> collection);
        void RemoveRange(int index, int count);
    }
}