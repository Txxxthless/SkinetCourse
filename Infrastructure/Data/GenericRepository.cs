using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        public StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecifiation(specification).ToListAsync();
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecifiation(specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecifiation(specification).CountAsync();
        }

        private IQueryable<T> ApplySpecifiation(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(
                _context.Set<T>().AsQueryable(),
                specification
            );
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Deltet(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
