﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoviesAPI.Repositories.RepositoryInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate); //Method that gets lambda expression

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);




    }
}
