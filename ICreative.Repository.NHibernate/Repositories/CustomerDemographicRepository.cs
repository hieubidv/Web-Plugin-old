
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class CustomerDemographicRepository : Repository<CustomerDemographic, System.String>, ICustomerDemographicRepository
    {
        public CustomerDemographicRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
