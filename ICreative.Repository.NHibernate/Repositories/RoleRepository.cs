
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class RoleRepository : Repository<Role, System.Int32>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
