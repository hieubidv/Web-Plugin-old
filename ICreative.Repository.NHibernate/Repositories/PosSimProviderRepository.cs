
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosSimProviderRepository : Repository<PosSimProvider, System.Int32>, IPosSimProviderRepository
    {
        public PosSimProviderRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
