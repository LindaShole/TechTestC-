using System.ComponentModel;

namespace AnyCompany.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public double VAT { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
