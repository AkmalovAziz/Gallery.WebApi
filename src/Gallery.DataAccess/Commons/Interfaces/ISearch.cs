using Gallery.Application.Utils;

namespace Gallery.DataAccess.Commons.Interfaces;

public interface ISearch<TViewModel>
{
    public Task<IList<TViewModel>> SearchAsync(string search, Paginationparams @params);
}