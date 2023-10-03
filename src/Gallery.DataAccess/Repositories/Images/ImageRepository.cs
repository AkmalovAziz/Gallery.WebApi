using Dapper;
using Gallery.Application.Utils;
using Gallery.DataAccess.Interfaces.Images;
using Gallery.DataAccess.ViewModels;
using Gallery.Domain.Entities.Images;

namespace Gallery.DataAccess.Repositories.Images;

public class ImageRepository : BaseRepository, IImageRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM images;";

            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Image entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(name, user_id, created_at, updated_at) " +
                "VALUES (@Name, @UserId, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM images WHERE id = @Id;";

            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<ImageViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM images ORDER BY id OFFSET {@params.SkipCount()} LIMIT {@params.PageSize};";

            var result = (await _connection.QueryAsync<ImageViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<ImageViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<ImageViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM images WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<ImageViewModel>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Image entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.users SET name=@Name, user_id=@UserId, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id = {id}";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}