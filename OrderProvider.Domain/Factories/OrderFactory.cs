using OrderProvider.Domain.Models;

namespace OrderProvider.Domain.Factories;

public static class OrderFactory
{
    public static Order Create(OrderRequest orderRequest)
    {
		try
		{
			var order = new Order
			{
				CustomerInfo = orderRequest.CustomerInfo,
				DeliveryAddress = orderRequest.DeliveryAddress,
				TotalPrice = orderRequest.TotalPrice
			};

			return order;
		}
		catch
		{
			return null!;
		}

    } 
}
