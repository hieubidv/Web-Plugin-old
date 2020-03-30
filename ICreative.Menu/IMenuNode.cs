
using System.Collections.Generic;

namespace ICreative.Menu
{
    public interface IMenuNode
    {
        ISiteMapNodeCollection ChildNodes { get; }
        string Title { get; set; }
        bool IsClickable { get; set; }
        string Url { get; set; }
        int Order { get; set; }

        bool IsAccessibleToUser();
        void AddNode(IMenuNode node);
        void AddNodeRange(IEnumerable<IMenuNode> nodes);
    }
}