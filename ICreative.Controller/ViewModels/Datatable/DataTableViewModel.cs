using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.Datatables
{
    public class DataTableViewModel
    {
        public string draw { get; set; }
        public string recordsTotal { get; set; }
        public string recordsFiltered { get; set; }

        public List<object> data { get; set; }
    }
}
