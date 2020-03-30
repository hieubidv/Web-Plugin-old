
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class OrderRepository : Repository<Order, System.Int32>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
