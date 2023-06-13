using Bemerkto.Contexts;
using Bemerkto.Models.Entities;

namespace Bemerkto.Helpers.Repositories;

public class TagRepository : Repo<TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}
