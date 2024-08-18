﻿using System.Linq.Expressions;

namespace HRSystem.Server.DataAccess.Repositories.Generic
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(bool trackChanges);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression,
            bool trackChanges);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        

    }
}
