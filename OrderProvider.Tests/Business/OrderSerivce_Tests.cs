using Moq;
using OrderProvider.Business.Interfaces;
using OrderProvider.Domain.Models;

namespace OrderProvider.Tests.Business;

public class OrderSerivce_Tests
{
    private readonly Mock<IOrderService> _mockOrderService;
    private readonly IOrderService _orderService;

    public OrderSerivce_Tests()
    {
        _mockOrderService = new Mock<IOrderService>();
        _orderService = _mockOrderService.Object;
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenOrderIsCreated()
    {
        var request = new OrderRequest
        {
            TotalPrice = 1050,
            CustomerInfo = new PersonalInformation
            {
                FirstName = "Tomten",
                LastName = "Tomtefar",
                Email = "tomten@domain.com"

            },
            DeliveryAddress = new Address
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetName = "Nordpolen",
                StreetNumber = "1",
                ZipCode = "00000"
            }
        };
        var expectedResult = new ResponseResultWithData<Order> { Success  = true, StatusCode = 200};
        _mockOrderService.Setup(x => x.Create(request)).Returns(expectedResult);

        var result = _orderService.Create(request);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.True(result.Success);

    }
}
