using SmartPacking.Data.Dto;
using SmartPacking.Model;
using SmartPacking.Service.Interfaces;

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

                if (orderVolumeTotal <= boxList[0].Volume)
                {
                    var boxResult = new BoxResultDto() { NameBox = boxList[0].Name };

                    boxResult.Products = new List<ProductBoxResultDto>();

                    foreach (var product in order.listProduct)
                    {
                        var productBoxResult = new ProductBoxResultDto() { Name = product.Name, ProductId = product.Id };

                        boxResult.Products.Add(productBoxResult);
                    }

                    orderPackingResult.Boxes.Add(boxResult);
                }
                else if(orderVolumeTotal <= boxList[1].Volume)
                {
                    var boxResult = new BoxResultDto() { NameBox = boxList[0].Name };

                    boxResult.Products = new List<ProductBoxResultDto>();

                    foreach (var product in order.listProduct)
                    {
                        var productBoxResult = new ProductBoxResultDto() { Name = product.Name, ProductId = product.Id };

                        boxResult.Products.Add(productBoxResult);
                    }

                    orderPackingResult.Boxes.Add(boxResult);
                }
                else if(orderVolumeTotal <= boxList[2].Volume)
                {
                    var boxResult = new BoxResultDto() { NameBox = boxList[0].Name };

                    boxResult.Products = new List<ProductBoxResultDto>();

                    foreach (var product in order.listProduct)
                    {
                        var productBoxResult = new ProductBoxResultDto() { Name = product.Name, ProductId = product.Id };

                        boxResult.Products.Add(productBoxResult);
                    }

                    orderPackingResult.Boxes.Add(boxResult);
                }

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
