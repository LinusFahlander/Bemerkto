using Microsoft.AspNetCore.Identity;

namespace Bemerkto.Models.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<UserAddressEntity> UsersAdresses { get; set; } = new HashSet<UserAddressEntity>();
}
