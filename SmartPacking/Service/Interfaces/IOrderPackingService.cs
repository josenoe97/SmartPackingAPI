using SmartPacking.Data.Dto;
using SmartPacking.Model;

namespace SmartPacking.Service.Interfaces
{
    public interface IOrderPackingService
    {
        public List<OrderPackingResultDto> ProcessOrders(List<OrderModel> orders, List<BoxModel> boxList);
    }
}
