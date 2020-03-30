
using System.Web.Mvc;

namespace ICreative.Menu
{
    public class ViewDataContainer<TModel> : IViewDataContainer
    {
        public ViewDataContainer(TModel model)
        {
            ViewData = new ViewDataDictionary<TModel>(model);
        }

        public ViewDataDictionary ViewData { get; set; }
    }
}