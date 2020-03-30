
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ICreative.Controllers
{
    public static class SortExpressionHelper
    {
        public static SortExpression GetSortExpression<TModel>(string sortExpression, ListSortDirection direction = ListSortDirection.Ascending)
        {
            return new SortExpression(sortExpression, direction);

        }
    }
}
