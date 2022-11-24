using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> ListAllAsync();
        public Task<T> GetEntityWithSpec(ISpecification<T> spec);
        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        public Task<T> AddAsync(T entity);
        public Task<int> DeleteAsync(ISpecification<T> spec);

        public Task<int> CountAsync(ISpecification<T> spec);

    }

}
