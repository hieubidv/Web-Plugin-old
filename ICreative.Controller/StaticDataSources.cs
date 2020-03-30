
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ICreative.Controllers
{
    public static class StaticDataSources
    {

       public static List<SelectListItem> YesNoSelectList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
             selectListItems.Add(new SelectListItem() { Text = "Yes", Value = 1.ToString(), Selected = false });
             selectListItems.Add(new SelectListItem() { Text = "No", Value = 0.ToString(), Selected = false });
            return selectListItems;
        }

    }
}
