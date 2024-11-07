namespace OrderProvider.Domain.Models
{
    public abstract class BaseOrder
    {
        public PersonalInformation? CustomerInfo { get; set; }
        public Address? DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
