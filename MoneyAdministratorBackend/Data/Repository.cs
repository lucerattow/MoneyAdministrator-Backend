﻿using Microsoft.EntityFrameworkCore;
using MoneyAdministratorBackend.Interfaces;

namespace MoneyAdministratorBackend.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entityKey = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties.Select(x => x.PropertyInfo.GetValue(entity)).ToArray();
            var existingEntity = _dbContext.Find<TEntity>(entityKey);

            if (existingEntity != null)
            {
                // Actualiza las propiedades de la entidad existente
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                // Si la entidad no existe en el contexto, la adjuntamos
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

    }
}
