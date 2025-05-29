using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SmartPacking.Model
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public virtual List<ProductModel> listProduct { get; set; }
    }
}
