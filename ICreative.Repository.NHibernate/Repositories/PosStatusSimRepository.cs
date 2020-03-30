
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosStatusSimRepository : Repository<PosStatusSim, System.Int32>, IPosStatusSimRepository
    {
        public PosStatusSimRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
