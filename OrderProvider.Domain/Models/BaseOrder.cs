namespace OrderProvider.Domain.Models
{
    public abstract class BaseOrder
    {
        public required PersonalInformation CustomerInfo { get; set; }
        public required Address DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
