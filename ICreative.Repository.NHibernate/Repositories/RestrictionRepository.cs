
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class RestrictionRepository : Repository<Restriction, System.Int32>, IRestrictionRepository
    {
        public RestrictionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
