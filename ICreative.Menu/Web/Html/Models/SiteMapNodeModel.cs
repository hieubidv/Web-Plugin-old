
namespace ICreative.Menu.Web.Html.Models
{
    public class SiteMapNodeModel
    {
        protected readonly IMenuNode node;
        protected SiteMapNodeModelList children;


        public SiteMapNodeModel(IMenuNode node)
        {
            this.node = node;
            Url = node.Url;
            Title = node.Title;
            IsClickable = node.IsClickable;
        }

        public string Url { get; protected set; }
        public string Title { get; protected set; }
        public bool IsClickable { get; protected set; }


        public SiteMapNodeModelList Children
        {
            get
            {
                if (children == null)
                {
                    children = new SiteMapNodeModelList();
                    ISiteMapNodeCollection sortedNodes = node.ChildNodes;
                    foreach (IMenuNode child in sortedNodes)
                    {
                        if (child.IsAccessibleToUser())
                        {
                            children.Add(new SiteMapNodeModel(child));
                        }
                    }
                }
                else
                {
                    return children;
                }
                return children;
            }
        }
    }
}