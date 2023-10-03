using Gallery.Application.Utils;

namespace Gallery.Service.Interfaces.Commons;

public interface IPaginator
{
    public void Paginate(long itemsCount, Paginationparams @params);
}