﻿using System.Linq.Expressions;

namespace WarehouseManagmentSystem.Infrastructure;

internal interface IRepository<T>
{
    T Add(T entity);
    T Update(T entity);
    T Get(Guid id);
    IEnumerable<T> All();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    void SaveChanges();
}
