
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class SupplierRepository : Repository<Supplier, System.Int32>, ISupplierRepository
    {
        public SupplierRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
