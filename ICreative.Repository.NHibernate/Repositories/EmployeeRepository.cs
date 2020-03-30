
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class EmployeeRepository : Repository<Employee, System.Int32>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
