using Dapper;
using Gallery.Application.Utils;
using Gallery.DataAccess.Interfaces.Users;
using Gallery.DataAccess.ViewModels;
using Gallery.Domain.Entities.Users;

namespace Gallery.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM users";

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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, email, description, role, password_hash, " +
                "salt, created_at, updated_at) VALUES (@FirstName, @LastName, @Email, @Description, @Role, @PasswordHash, " +
                    "@Salt, @CreatedAt, @UpdatedAt);";

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

            string query = "DELETE FROM users WHERE id = @Id;";

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

    public async Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM users ORDER BY id OFFSET {@params.SkipCount()} LIMIT {@params.PageSize};";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM users WHERE email = @Email;";

            var result = await _connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });

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

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM users WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { Id = id });

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

    public async Task<User?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM users WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });

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

    public async Task<IList<UserViewModel>> SearchAsync(string search, Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM users WHERE first_name ILIKE '{search}%' OR last_name ILIKE '{search}%'";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.users SET first_name=@FirstName, last_name=@LastName, email=@Email, " +
                $"description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";

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