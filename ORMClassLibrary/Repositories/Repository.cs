using Microsoft.EntityFrameworkCore;
using ORM.Domain.Repositories.Interfaces;
using ORMClassLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ORM.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context = null;
        private readonly DbSet<T> table = null;

        public Repository()
        {
            this._context = new ApplicationContext();
            table = _context.Set<T>();
        }
        public Repository(ApplicationContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllUsingProcedure(string procedureName)
        {
            return table.FromSqlRaw(procedureName);
        }

        public IEnumerable<T> GetAllWithFilter(Func<T, bool> filter)
        {
            return table.Where(filter);
        }

        public int DeleteInBulkWithFilter(Func<T, bool> filter)
        {
            var entitiesToDelete = table.Where(filter);
            int count = entitiesToDelete.Count();
            table.RemoveRange(entitiesToDelete);
            return count;
        }
    }
}
