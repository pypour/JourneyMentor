using System.Collections.Generic;

namespace Application.Commands.Dto
{
    public class ExternalApiResult<T>
    {
        public PaginationDto Pagination { get; set; }
        public List<T> Data { get; set; }
    }
}