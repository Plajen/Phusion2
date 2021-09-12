namespace Phusion2.Application.Interfaces
{
    public interface IBaseParams
    {
        int? Id { get; set; }
        int? Skip { get; set; }
        int? Take { get; set; }
        string OrderBy { get; set; }
        string Include { get; set; }
    }
}
