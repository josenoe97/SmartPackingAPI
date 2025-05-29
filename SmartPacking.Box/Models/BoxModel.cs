using System.ComponentModel.DataAnnotations;

namespace SmartPacking.Box.Model
{
    public class BoxModel
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
