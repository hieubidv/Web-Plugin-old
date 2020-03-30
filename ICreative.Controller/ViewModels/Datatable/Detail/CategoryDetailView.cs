using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class CategoryDetailView
    {
        public System.Int32 CategoryID { get; set; }
        public System.String CategoryName { get; set; }
        public System.String Description { get; set; }
        public System.Byte[] Picture { get; set; }
    }
}
