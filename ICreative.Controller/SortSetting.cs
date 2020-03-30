using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers
{
    public class SortSetting
    {
        public ListSortDirection SortDirection { get; set; }
        public ListSortDirection SortDirectionNew { get; set; }
        public string SortExpression { get; set; }
        public string LastSortExpression { get; set; }
    }
}
