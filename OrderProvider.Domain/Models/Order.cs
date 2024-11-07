namespace OrderProvider.Domain.Models;

public class Order : BaseOrder
{
    public string OrderNumber { get; set; } = null!;
}
