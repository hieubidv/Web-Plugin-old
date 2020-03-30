
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosTerminalRepository : Repository<PosTerminal, System.Int32>, IPosTerminalRepository
    {
        public PosTerminalRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
