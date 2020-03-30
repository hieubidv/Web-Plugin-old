
using System;
using System.Web.Mvc;

namespace ICreative.Menu
{
    public class MvcSiteMapHtmlHelper
    {
        public MvcSiteMapHtmlHelper(HtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
                throw new ArgumentNullException("htmlHelper");

            HtmlHelper = htmlHelper;
        }

        public HtmlHelper HtmlHelper { get; protected set; }


        public HtmlHelper<TModel> CreateHtmlHelperForModel<TModel>(TModel model)
        {
            return new HtmlHelper<TModel>(HtmlHelper.ViewContext, new ViewDataContainer<TModel>(model));
        }
    }
}