
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosAddressRepository : Repository<PosAddress, System.Int32>, IPosAddressRepository
    {
        public PosAddressRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
