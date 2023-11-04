namespace Application.Commands.Dto
{
    public class PaginationDto
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}