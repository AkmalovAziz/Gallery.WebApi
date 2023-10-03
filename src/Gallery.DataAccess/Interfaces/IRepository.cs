using Gallery.Application.Utils;

namespace Gallery.DataAccess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);
    public Task<int> UpdateAsync(long id, TEntity entity);
    public Task<long> DeleteAsync(long id);
    public Task<IList<TViewModel>> GetAllAsync(Paginationparams @params);
    public Task<TViewModel?> GetByIdAsync(long id);
    public Task<TEntity?> GetIdAsync(long id);
    public Task<long> CountAsync();
}