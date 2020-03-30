
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ICreative.Controllers
{
    public class SortExpression
    {
        public SortExpression(string sortBy, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public string SortBy { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}
