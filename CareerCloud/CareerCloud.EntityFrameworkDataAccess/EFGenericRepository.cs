using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using System.Data.SqlClient;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T: class

    {
        private CareerCloudContext _context;
        public EFGenericRepository(bool createProxy = true)
        {
            _context = new CareerCloudContext(createProxy);
            
        }
        
        public void Add(params T[] items)
        {
            foreach(T item in items)
            {
                _context.Entry<T>(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetSingle()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
          IQueryable<T> query = _context.Set<T>();
            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
               
                query = query.Include<T, object>(navProp);
            }
            // return query.Where  (a => a != null).ToList();
            return _context.Set<T>().ToList();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach(Expression<Func<T, object>> navProp in navigationProperties)
            {
                query = query.Include<T, object>(navProp);
            }
            return query.FirstOrDefault();
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry<T>(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry<T>(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
