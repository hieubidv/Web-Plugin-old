
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosReceiptOfDeliveryRepository : Repository<PosReceiptOfDelivery, System.Int32>, IPosReceiptOfDeliveryRepository
    {
        public PosReceiptOfDeliveryRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
