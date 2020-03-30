
using System.Collections;
using System.Collections.Generic;

namespace ICreative.Menu.Web.Html.Models
{
    public class MenuHelperModel : IEnumerable<SiteMapNodeModel>
    {
        public MenuHelperModel()
        {
            Nodes = new List<SiteMapNodeModel>();
        }

        public List<SiteMapNodeModel> Nodes { get; set; }

        public IEnumerator<SiteMapNodeModel> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }
    }
}