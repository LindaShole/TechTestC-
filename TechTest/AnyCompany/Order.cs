namespace AnyCompany
{
    public class Order
    {
        public int OrderId { get; private set; }
        public double Amount { get;private set; }
        public double VAT { get;private set; }
    

    // Constructor with required parameters
     public Order(int orderId, double amount, double vat)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            OrderId = orderId;
            Amount = amount;
            VAT = vat;
        }

    // Factory method to create an order with default VAT of 0
     public static Order CreateOrder(int orderId, double amount)
        {
            return new Order(orderId, amount, 0);
        }
    }
}
    
