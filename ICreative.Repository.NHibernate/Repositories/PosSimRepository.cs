
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosSimRepository : Repository<PosSim, System.Int32>, IPosSimRepository
    {
        public PosSimRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
