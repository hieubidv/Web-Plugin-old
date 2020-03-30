
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ICreative.Infrastructure.Menu
{
    public interface IMenuItem
    {

        int MenuItemId { get; set; }

        string MenuItemName { get; set; }

        int ParentId { get; set; }

        string MenuItemUrl { get; set; }   
    }
}
