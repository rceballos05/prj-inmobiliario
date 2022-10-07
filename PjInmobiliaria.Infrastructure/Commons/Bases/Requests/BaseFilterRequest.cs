namespace PjInmobiliaria.Infrastructure.Commons.Bases.Requests
{
    public class BaseFilterRequest : BasePaginationRequest
    {
        public int? NumFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
        public int? State { get; set; } = null;
        public string? StartDate { get; set; }=null;
        public string? EndDate { get; set; }=null ;
        
    }
}
