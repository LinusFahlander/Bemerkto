using Bemerkto.Contexts;
using Bemerkto.Models.Entities;

namespace Bemerkto.Helpers.Repositories;

public class ProductTagRepository : Repo<ProductTagEntity>
{
    public ProductTagRepository(DataContext context) : base(context)
    {
    }
}
