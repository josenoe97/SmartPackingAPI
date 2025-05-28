using SmartPacking.Model;

namespace SmartPacking.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> SearchAllOrdersAsync();
        Task<OrderModel> SearchForIdAsync(int id);
        Task<List<OrderModel>> AddOrdersAsync(List<OrderModel> orders);
    }
}
