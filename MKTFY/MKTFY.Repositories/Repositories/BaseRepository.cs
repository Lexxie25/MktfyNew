using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Models.Entities.Interfaces;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class BaseRepository<TEntity, TId, TDbContext> : IBaseRepository<TEntity, TId>
        where TEntity : notnull, BaseEntity<TId>
        where TDbContext : notnull, DbContext
        where TId : notnull
    {

        protected DbSet<TEntity> _entityDbSet;

        public BaseRepository(TDbContext context)
        {
            _entityDbSet = context.Set<TEntity>();
        }
        //creating a new listing 
        public void Create(TEntity entity)
        {
            //add the created date
            if (ImplementsInterface<IDated>())
                // ((IDated)entity).Created = DateTime.UtcNow;
                (entity as IDated).Created = DateTime.UtcNow;


            // perform the add in memory
            _entityDbSet.Add(entity);
        }
        // get a single existing listing by Id 

        public async Task<TEntity> GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? queryFunction = null)
        {
            // get the entity 
            TEntity? result;
            if (queryFunction == null)
                result = await _entityDbSet.FirstOrDefaultAsync(items => items.Id.Equals(id));
            else
                result = await queryFunction(_entityDbSet).FirstOrDefaultAsync(items => items.Id.Equals(id));

            if (result == null)
                throw new NotFoundException("The requested item could not be found");

            // return the retrieved entity
            return result;
        }


        public async Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? queryFunction = null)
        {
            List<TEntity> results;
            if (queryFunction == null)
                results = await _entityDbSet.ToListAsync();
            else
                results = await queryFunction(_entityDbSet).ToListAsync();

            // return the retrieved entities
            return results;
        }

        // Update the existing games 
        public void Update(TEntity entity)
        {
            // Update the entity(entity passsed in has changes already applied)
            _entityDbSet.Update(entity);
        }

        // Delete the listing

        public void Delete(TEntity entity)
        {
            // deleting the entitiy 
            _entityDbSet.Remove(entity);
        }


        protected bool ImplementsInterface<TInterface>()
        {
            return (typeof(TEntity).GetInterfaces().Contains(typeof(TInterface)));
        }
    }
}
