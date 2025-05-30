using SmartPacking.Model;
using System.Text.Json.Serialization;

namespace SmartPacking.Data.Dto
{
    public class BoxResultDto
    {
        [JsonIgnore]
        public int OrderId { get; set; }
        public string NameBox { get; set; }
        public int VolMax { get; set; }
        public int VolRemaining { get; set; }
        public List<ProductBoxResultDto> Products { get; set; } = new();

        public BoxResultDto(string nameBox, int volMax)
        {
            NameBox = nameBox;
            VolMax = volMax;
            VolRemaining = volMax;
        }

        public bool TryAddProduct(ProductBoxResultDto produto)
        {
            if (produto.Volume <= VolRemaining)
            {
                Products.Add(produto);
                VolRemaining -= produto.Volume;
                return true;
            }
            return false;
        }
    }
}
