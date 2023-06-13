using Bemerkto.Contexts;
using Bemerkto.Models.Entities;

namespace Bemerkto.Helpers.Repositories
{
    public class UserAddressRepository : Repo<UserAddressEntity>
    {
        public UserAddressRepository(DataContext context) : base(context)
        {
        }
    }
}
