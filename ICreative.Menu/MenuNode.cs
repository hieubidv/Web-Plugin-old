
using System.Collections.Generic;
using ICreative.Menu.Collections;

namespace ICreative.Menu
{
    public class MenuNode : IMenuNode
    {
        public MenuNode()
        {
            ChildNodes = new SiteMapNodeCollection();
        }

        public ISiteMapNodeCollection ChildNodes { get; set; }
        public string Title { get; set; }
        public bool IsClickable { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }

        public bool IsAccessibleToUser()
        {
            return true;
        }

        public void AddNode(IMenuNode node)
        {
            ChildNodes.Add(node);
        }

        public void AddNodeRange(IEnumerable<IMenuNode> nodes)
        {
            ChildNodes.AddRange(nodes);
        }
    }
}