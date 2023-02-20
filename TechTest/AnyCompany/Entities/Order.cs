using System;
using System.ComponentModel.DataAnnotations;

namespace AnyCompany.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [Range(0.1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Amount { get; set; }
        [Required]
        public double VAT { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
