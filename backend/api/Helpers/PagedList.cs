namespace api.Helpers;

public class PagedList<T> : List<T>
{
    public PagedList()
    { }

    private PagedList(IEnumerable<T> items, int itemsCount, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);
        PageSize = pageSize;
        TotalItems = itemsCount;
        AddRange(items);
    }

    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItems { get; private set; }

    public static async Task<PagedList<T>> CreatePagedListAsync(IQueryable<T>? query, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        int count = await query.CountAsync<T>(cancellationToken);

        IEnumerable<T> items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}