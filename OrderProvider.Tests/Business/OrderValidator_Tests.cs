using Moq;
using OrderProvider.Business.Interfaces;
using OrderProvider.Domain.Models;

namespace OrderProvider.Tests.Business;

public class OrderValidator_Tests
{

    private readonly Mock<IOrderValidator> _mockOrderValidator;
    private readonly IOrderValidator _orderValidator;


    public OrderValidator_Tests()
    {
        _mockOrderValidator = new Mock<IOrderValidator>();
        _orderValidator = _mockOrderValidator.Object;
    }

    [Fact]
    public void Validate_ShouldReturnValidationFailed_WhenOrderIsMissingInformation()
    {
        var request = new OrderRequest
        {
            TotalPrice = 1050,
            CustomerInfo = new PersonalInformation
            {
                LastName = "Tomtefar",
                PhoneNumber = ""
            },
            DeliveryAddress = new Address
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetNumber = "1",
                ZipCode = "00000"
            }
        };

        var expectedResult = new OrderValidatorResult { Success = false, StatusCode = 400 };
        _mockOrderValidator.Setup(x => x.Validate(request)).Returns(expectedResult);
        var result = _orderValidator.Validate(request);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.False(result.Success);
    }
}
