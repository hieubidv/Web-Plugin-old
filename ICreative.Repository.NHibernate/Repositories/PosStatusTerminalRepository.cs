
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosStatusTerminalRepository : Repository<PosStatusTerminal, System.Int32>, IPosStatusTerminalRepository
    {
        public PosStatusTerminalRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
