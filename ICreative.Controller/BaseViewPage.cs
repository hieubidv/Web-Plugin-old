
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ICreative.Controllers.ViewModels;

namespace ICreative.Controllers.ViewModels
{
    public abstract class BaseViewPage : WebViewPage
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}
