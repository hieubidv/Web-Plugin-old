
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PermissionRepository : Repository<Permission, System.Int32>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
