namespace EvolentContact.Data.Pagination
{
    public static class PaginationExtension
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();

            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            var skip = (page - 1) * pageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
