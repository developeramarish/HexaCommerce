using Hexa.Core.Data;
using Hexa.Core.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hexa.Data
{
    public partial class HexaRepository<T> : IHexaRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly HexaDbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        public HexaRepository(HexaDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Method

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            try
            {
                if(entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public virtual IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        #endregion
    }
}
