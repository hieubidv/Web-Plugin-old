
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class ProductRepository : Repository<Product, System.Int32>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
