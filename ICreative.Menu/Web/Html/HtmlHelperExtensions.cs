
using System.Web.Mvc;

namespace ICreative.Menu.Web.Html
{
    public static class HtmlHelperExtensions
    {
        public static MvcSiteMapHtmlHelper MvcSiteMap(this HtmlHelper helper)
        {
            return new MvcSiteMapHtmlHelper(helper);
        }
    }
}