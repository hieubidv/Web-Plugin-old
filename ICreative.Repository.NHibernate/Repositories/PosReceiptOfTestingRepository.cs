
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosReceiptOfTestingRepository : Repository<PosReceiptOfTesting, System.Int32>, IPosReceiptOfTestingRepository
    {
        public PosReceiptOfTestingRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
