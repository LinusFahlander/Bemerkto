using Bemerkto.Contexts;
using Bemerkto.Models.Entities;

namespace Bemerkto.Helpers.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
