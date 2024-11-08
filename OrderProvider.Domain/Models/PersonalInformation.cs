namespace OrderProvider.Domain.Models;

public class PersonalInformation : BasePersonalInformation
{
    public string Id { get; set; } = null!;
    //public string AccountType { get; set; } = null!;
    // 0 - admin
    // 1 - user
    // 2 - guest
}

