using Domain.Entities.Security;

namespace Domain.ValueObjects;

public class Address
{
    public int CityId { get; set; }
    public string FullAddress { get; set; }
    
    //navigations
    public int UserId { get; set; }
    public virtual User User { get; set; }
}