using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartPacking.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Length { get; set; }
        public int Volume => Height * Width * Length;

        #region Relacionamentos
        public int OrderModelId { get; set; }
        [JsonIgnore]
        public OrderModel? Order { get; set; }
        #endregion
    }
}
