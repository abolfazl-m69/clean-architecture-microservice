namespace HumanResource.Framework.Common.Models.Pagination
{
    public  class PagingRequest
    {
        public int PageNumber { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;
        public int Skip => (PageNumber - 1) * RecordsPerPage;

        public string SearchTerm { get; set; }

        public OrderByRequest OrderBy { get; set; }
    }

    public class OrderByRequest
    {
        public string PropertyName { get; set; }

        public string OrderDirection { get; set; }
    }
}