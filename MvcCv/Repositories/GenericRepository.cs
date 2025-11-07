using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities2 db = new DbCvEntities2();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }
        public void TDelete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }
        public void TUpdate(T t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        } public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
    }
   