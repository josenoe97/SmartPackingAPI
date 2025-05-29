



using SmartPacking.Box.Model;

namespace SmartPacking.Box.Repository.Interfaces
{
    public interface IBoxRepository
    {
        Task<List<BoxModel>> GetAllBoxsAsync();
    }
}
