
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class ShipperRepository : Repository<Shipper, System.Int32>, IShipperRepository
    {
        public ShipperRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
