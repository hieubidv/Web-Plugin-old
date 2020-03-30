
using System;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.UnitOfWork;
using NHibernate;
using ICreative.Repository.NHibernate.SessionStorage;

namespace ICreative.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(IAggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(IAggregateRoot entity,
                                IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction =
                           SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                { transaction.Commit(); }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }

}
