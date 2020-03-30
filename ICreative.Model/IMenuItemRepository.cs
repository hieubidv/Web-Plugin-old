
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
namespace ICreative.Model
{
    public interface IMenuItemRepository : IRepository<MenuItem, System.Int32>
    {
    }

}
