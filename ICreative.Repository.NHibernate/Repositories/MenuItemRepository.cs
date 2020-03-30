
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class MenuItemRepository : Repository<MenuItem, System.Int32>, IMenuItemRepository
    {
        public MenuItemRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
