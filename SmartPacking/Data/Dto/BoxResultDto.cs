using System.Text.Json.Serialization;

namespace SmartPacking.Data.Dto
{
    public class BoxResultDto
    {
        [JsonIgnore]
        public int OrderId { get; set; }
        public string NameBox { get; set; }
        public List<ProductBoxResultDto> Products { get; set; }
    }
}
