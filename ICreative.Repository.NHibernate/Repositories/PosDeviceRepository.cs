
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosDeviceRepository : Repository<PosDevice, System.Int32>, IPosDeviceRepository
    {
        public PosDeviceRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
