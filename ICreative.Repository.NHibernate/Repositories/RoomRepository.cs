
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class RoomRepository : Repository<Room, System.Int32>, IRoomRepository
    {
        public RoomRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
