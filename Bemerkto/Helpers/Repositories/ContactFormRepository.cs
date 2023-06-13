using Bemerkto.Contexts;
using Bemerkto.Models.Entities;

namespace Bemerkto.Helpers.Repositories;

public class ContactFormRepository : Repo<ContactFormEntity>
{
    public ContactFormRepository(DataContext context) : base(context)
    {
    }
}
