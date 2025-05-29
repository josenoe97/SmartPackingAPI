namespace SmartPacking.Data.Dto
{
    public class OrderPackingResultDto
    {
        public int OrderId { get; set; }
        public List<BoxResultDto> Boxes { get; set; }
    }
}
