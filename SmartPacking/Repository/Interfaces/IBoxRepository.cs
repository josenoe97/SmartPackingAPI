using SmartPacking.Model;

namespace SmartPacking.Repository.Interfaces
{
    public interface IBoxRepository
    {
        Task<List<BoxModel>> GetAllBoxsAsync();
    }
}
