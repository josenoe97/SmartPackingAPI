using SmartPacking.Data.Dto;
using SmartPacking.Model;
using SmartPacking.Service.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace SmartPacking.Service
{
    public class OrderPackingService : IOrderPackingService
    {
        public List<OrderPackingResultDto> ProcessOrders(List<OrderModel> orders, List<BoxModel> boxList)
        {
            var result = new List<OrderPackingResultDto>();

            foreach (var order in orders)
            {
                var orderPackingResult = new OrderPackingResultDto() { OrderId = order.Id };
                orderPackingResult.Boxes = new List<BoxResultDto>();

                var orderVolumeTotal = OrderVolumeTotalCalculator(order);

                var box = new BoxModel();

                if (orderVolumeTotal <= boxList[0].Volume)
                    box = boxList[0];
                else if (orderVolumeTotal <= boxList[1].Volume)
                    box = boxList[1];
                else if (orderVolumeTotal <= boxList[2].Volume)
                    box = boxList[3];

                var boxResult = new BoxResultDto() { NameBox = box.Name };

                boxResult.Products = new List<ProductBoxResultDto>();

                foreach (var product in order.listProduct)
                {
                    var productBoxResult = new ProductBoxResultDto() { Name = product.Name, ProductId = product.Id };

                    boxResult.Products.Add(productBoxResult);
                }

                orderPackingResult.Boxes.Add(boxResult);

                result.Add(orderPackingResult);
            }

            return result;
        }

        private double OrderVolumeTotalCalculator(OrderModel order)
        {
            return order.listProduct.Sum(x => x.Volume);
        }
    }
}
