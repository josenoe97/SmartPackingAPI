using Microsoft.IdentityModel.Tokens;
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
                var productOrder = order.listProduct.OrderByDescending(p => p.Volume).ToList();

                var productBoxList = new List<ProductBoxResultDto>();

                var boxResultList = new List<BoxResultDto>();

                //conversao ProductModel => ProductBoxResultDto
                foreach (var produto in productOrder)
                {
                    productBoxList.Add(new ProductBoxResultDto
                    {
                        Name = produto.Name,
                        ProductId = produto.Id,
                        Volume = produto.Volume

                    });
                }

                //conversao BoxModel => BoxResultDto
                foreach (var box in boxList)
                {
                    boxResultList.Add(new BoxResultDto(box.Name,box.Volume));
                }

                var usedBoxs = new List<BoxResultDto>();

                var volumeTotalProd = OrderVolumeTotalCalculator(order);

                while (volumeTotalProd > 0) 
                {
                    if (boxResultList[0].VolMax >= volumeTotalProd)
                    {
                        usedBoxs.Add(boxResultList[0]);
                        volumeTotalProd = volumeTotalProd - boxResultList[0].VolMax;
                    }
                    else if (boxResultList[1].VolMax >= volumeTotalProd)
                    {
                        usedBoxs.Add(boxResultList[1]);
                        volumeTotalProd = volumeTotalProd - boxResultList[1].VolMax;
                    }
                    else if (boxResultList[2].VolMax <= volumeTotalProd)
                    {
                        usedBoxs.Add(boxResultList[2]);
                        volumeTotalProd = volumeTotalProd - boxResultList[2].VolMax;
                    }
                }

                foreach(var usedBox in usedBoxs)
                {

                    while (!productBoxList.IsNullOrEmpty())
                    {
                        var product = productBoxList.Where(x => x.Volume <= usedBox.VolRemaining).FirstOrDefault();

                        if (product != null)
                        {
                            usedBox.TryAddProduct(product);

                            productBoxList.Remove(product);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                orderPackingResult.Boxes.AddRange(usedBoxs);

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
