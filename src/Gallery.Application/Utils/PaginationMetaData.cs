namespace Gallery.Application.Utils;

public class PaginationMetaData
{
    public bool HasPrevios { get; set; }
    public bool HasNext { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
}