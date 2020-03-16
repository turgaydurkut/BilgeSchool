using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Core.Entity.Enum;
using Ntier.BilgeSchool.Core.Service;
using Ntier.BilgeSchool.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private ProjectContext _db = new ProjectContext();
        public ProjectContext Db
        {

            get
            {
                return _db;
            }
            set
            {
                if (_db == null)
                {
                    _db = new ProjectContext();
                    
                }
            }

        }
        public void Add(T item)
        {
            Db.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            Db.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)=> Db.Set<T>().Any(exp);
       

        public List<T> GetActive()
        {
            return Db.Set<T>().Where(x => x.Status == Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return Db.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Db.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return Db.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = Db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
