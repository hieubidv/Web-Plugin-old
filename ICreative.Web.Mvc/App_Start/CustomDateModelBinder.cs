
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Globalization;
namespace ICreative.Web.Mvc
{
    public class CustomDateModelBinder : DefaultModelBinder
    {
        public override object BindModel
        (ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //  var displayFormat = bindingContext.ModelMetadata.DisplayFormatString;
            var displayFormat = "MM/dd/yyyy";
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (!string.IsNullOrEmpty(displayFormat) && value != null)
            {
                DateTime date;
                displayFormat = displayFormat.Replace
                ("{0:", string.Empty).Replace("}", string.Empty);
                if (DateTime.TryParseExact(value.AttemptedValue, displayFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    bindingContext.ModelState.AddModelError(
                        bindingContext.ModelName,
                        string.Format("{0} is an invalid date format", value.AttemptedValue)
                    );
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}