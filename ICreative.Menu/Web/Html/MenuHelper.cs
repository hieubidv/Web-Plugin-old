
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ICreative.Menu.Web.Html.Models;

namespace ICreative.Menu.Web.Html
{
    public static class MenuHelper
    {
        public static MvcHtmlString Menu(this MvcSiteMapHtmlHelper helper)
        {
            MenuHelperModel model = BuildModel(MVCSiteMap.StartingNode);

            //MenuNode node = new MenuNode();
            //node.Title = "tesst1";
            //node.Url = "dsdsd";
            //node.IsClickable = false;
            //SiteMapNodeModel nodemodel = new SiteMapNodeModel(node);


            //MenuNode node2 = new MenuNode();
            //node.Title = "tesst22221";
            //node.Url = "dsdsd2222";
            //node.IsClickable = false;
            //SiteMapNodeModel nodemodel2 = new SiteMapNodeModel(node);


            //MenuNode node3 = new MenuNode();
            //node.Title = "tesst333";
            //node.Url = "dsdsd33";
            //node.IsClickable = true;
            //SiteMapNodeModel nodemodel3 = new SiteMapNodeModel(node);


            //MenuNode node4 = new MenuNode();
            //node.Title = "tesst331";
            //node.Url = "dsdsd333";
            //node.IsClickable = true;
            //SiteMapNodeModel nodemodel4 = new SiteMapNodeModel(node);


            //MenuNode node5 = new MenuNode();
            //node.Title = "tesst335553";
            //node.Url = "dsdsd35553";
            //node.IsClickable = true;
            //SiteMapNodeModel nodemodel5 = new SiteMapNodeModel(node);


            //MenuNode node6 = new MenuNode();
            //node.Title = "tesst366631";
            //node.Url = "dsdsd336663";
            //node.IsClickable = true;
            //SiteMapNodeModel nodemodel6 = new SiteMapNodeModel(node);

            //nodemodel3.Children.Add(nodemodel6);
            //nodemodel3.Children.Add(nodemodel5);

            //nodemodel2.Children.Add(nodemodel3);
            //nodemodel2.Children.Add(nodemodel4);


            //MenuHelperModel menu = new MenuHelperModel();
            //menu.Nodes.Add(nodemodel);
            //menu.Nodes.Add(nodemodel2);


            return helper
                .CreateHtmlHelperForModel(model)
                .DisplayFor(m => model, null);
        }


        internal static MenuHelperModel BuildModel(IMenuNode node)
        {
            var model = new MenuHelperModel();

            if (node == null)
            {
                return model;
            }

            if (node.IsAccessibleToUser())
            {
                var nodeToAdd = new SiteMapNodeModel(node);
                model.Nodes.AddRange(nodeToAdd.Children);
            }
            return model;
        }
    }
}