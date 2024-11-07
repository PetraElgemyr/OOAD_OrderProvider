namespace OrderProvider.Domain.Models;

public abstract class BaseAddress
{
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}
