
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class UserRepository : Repository<User, System.Guid>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
