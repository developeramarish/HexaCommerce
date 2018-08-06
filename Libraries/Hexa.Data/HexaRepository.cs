using Hexa.Core.Data;
using Hexa.Core.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public virtual async Task<T> GetById(int id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);
                await _context.SaveChangesAsync();
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
        public virtual async Task Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Update(entity);
                await _context.SaveChangesAsync();
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
        public virtual async Task Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                await _context.SaveChangesAsync();
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
            get { return Entities; }
        }

        #endregion
    }
}
