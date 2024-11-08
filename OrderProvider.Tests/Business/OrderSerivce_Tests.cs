using Moq;
using OrderProvider.Business.Interfaces;
using OrderProvider.Domain.Models;
using System.Diagnostics;

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
                Email = "tomten@domain.com",
                PhoneNumber = "1234567890",

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


        var expectedResult = new ResponseResultWithData<Order> { Success = true, StatusCode = 200 };
        _mockOrderService.Setup(x => x.Create(request)).Returns(expectedResult);

        var result = _orderService.Create(request);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.True(result.Success);
        //}
    }


    [Fact]
    public void GetAll_ShouldReturnTrueWithData_WhenSuccessIsTrue()
    {
        var request = new Order
        {
            TotalPrice = 1050,
            OrderNumber = Guid.NewGuid().ToString(),
            CustomerInfo = new PersonalInformation
            {
                FirstName = "Tomten",
                LastName = "Tomtefar",
                PhoneNumber = "1234",
                Email = "tomten@domain.com"

            },
            DeliveryAddress = new Address
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetNumber = "1",
                ZipCode = "00000"
            }
        };


        var orders = new List<Order> { request };

        var expectedResult = new ResponseResultWithData<IEnumerable<Order>> { Success = true, StatusCode = 200, Data = orders };
        _mockOrderService.Setup(x => x.GetAll()).Returns(expectedResult);

        var result = _orderService.GetAll();

        Assert.True(result.Success);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.Equal(expectedResult.Data, result.Data);
    }

    [Fact]
    public void GetOne_ShouldReturnOne_WhenSuccessIsTrue()
    {

    }
}