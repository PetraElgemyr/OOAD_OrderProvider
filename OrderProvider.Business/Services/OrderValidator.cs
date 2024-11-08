using OrderProvider.Business.Interfaces;

namespace OrderProvider.Domain.Models;

public class OrderValidator : IOrderValidator
{
    public OrderValidatorResult Validate(OrderRequest orderRequest)
    {
        if (string.IsNullOrEmpty(orderRequest.TotalPrice.ToString()))
        {
            return new OrderValidatorResult { Success = false, StatusCode = 400, Message = "Total price is required" };
        }

        if (string.IsNullOrEmpty(orderRequest.CustomerInfo!.FirstName)
            || string.IsNullOrEmpty(orderRequest.CustomerInfo!.LastName)
            || string.IsNullOrEmpty(orderRequest.CustomerInfo!.PhoneNumber)
            || string.IsNullOrEmpty(orderRequest.CustomerInfo!.Email)
            )
        {
            return new OrderValidatorResult { Success = false, StatusCode = 400, Message = "All required customer info is not filled out correctly." };
        }

        if (string.IsNullOrEmpty(orderRequest.DeliveryAddress!.City)
            || string.IsNullOrEmpty(orderRequest.DeliveryAddress!.StreetName)
            || string.IsNullOrEmpty(orderRequest.DeliveryAddress!.StreetName)
            || string.IsNullOrEmpty(orderRequest.DeliveryAddress!.StreetNumber)
            || string.IsNullOrEmpty(orderRequest.DeliveryAddress!.ZipCode)
            )
        {
            return new OrderValidatorResult { Success = false, StatusCode = 400, Message = "The delivery address is not filled out correctly." };
        }


        return new OrderValidatorResult { Success = true, StatusCode = 204 };

    }
}
