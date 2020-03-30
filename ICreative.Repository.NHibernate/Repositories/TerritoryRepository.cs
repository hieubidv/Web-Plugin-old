
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class TerritoryRepository : Repository<Territory, System.String>, ITerritoryRepository
    {
        public TerritoryRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
