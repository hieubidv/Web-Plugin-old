
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.Querying;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Repository.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Criterion;

namespace ICreative.Repository.NHibernate
{
    public abstract class Repository<T, TEntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public int Remove(TEntityKey id)
        {
            var queryString  = string.Format("delete {0} where id = :id",typeof(T));

            return SessionFactory.GetCurrentSession().CreateQuery(queryString).SetParameter("id", id).ExecuteUpdate();
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }


        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery =
                    SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery =
                      SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)criteriaQuery.SetFetchSize(count)
                                    .SetFirstResult(index).List<T>();
        }

        public T FindBy(TEntityKey id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(id);
        }
        
        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery =
                     SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery =
                     SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }
    }

}
