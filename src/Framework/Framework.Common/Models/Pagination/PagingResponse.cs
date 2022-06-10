using System.Collections.Generic;

namespace HumanResource.Framework.Common.Models.Pagination
{
    public class PagingResponse<T> : PagingRequest where T : class
    {
        public int TotalCount { get; set; }

        public List<T> Data { get; set; }

        //public double PageCount => Math.Ceiling(Convert.ToDouble(TotalCount) / RecordsPerPage);

        public PagingResponse()
        {
        }
        public PagingResponse(List<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}