using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        public string ProductName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Quantity is a required field")]
        [Range(1.0, int.MaxValue, ErrorMessage = "Quantity can not be less than one")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is a required field")]
        [Range(1.0, int.MaxValue, ErrorMessage = "Price can not be less than one")]
        public double Price { get; set; }
    }
}
