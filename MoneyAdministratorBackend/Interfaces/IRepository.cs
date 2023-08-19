﻿namespace MoneyAdministratorBackend.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>Obtiene todas las entidades</summary>
        IEnumerable<TEntity> GetAll();
        /// <summary>Obtiene una entidad</summary>
        /// <param name="id">Id de la entidad</param>
        TEntity GetById(int id);
        /// <summary>Inserta una entidad en la base de datos</summary>
        /// <param name="entity">Entidad a insertar</param>
        void Add(TEntity entity);
        /// <summary>Actualiza una entidad en la base de datos</summary>
        /// <param name="entity">Entidad a actualizar</param>
        void Update(TEntity entity);
        /// <summary>Elimina una entidad en la base de datos</summary>
        /// <param name="entity">Entidad a eliminar</param>
        void Delete(TEntity entity);
    }
}
