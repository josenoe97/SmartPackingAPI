using System.ComponentModel.DataAnnotations;

namespace SmartPacking.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public double Volume => Height * Width * Length;
    }
}
