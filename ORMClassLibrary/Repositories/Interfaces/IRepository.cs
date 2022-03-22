﻿using System;
using System.Collections.Generic;

namespace ORM.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        IEnumerable<T> GetAllUsingProcedure(string procedureName);
        IEnumerable<T> GetAllWithFilter(Func<T, bool> filter);
        int DeleteInBulkWithFilter(Func<T, bool> filter);
    }
}
