
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class RegionRepository : Repository<Region, System.Int32>, IRegionRepository
    {
        public RegionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
