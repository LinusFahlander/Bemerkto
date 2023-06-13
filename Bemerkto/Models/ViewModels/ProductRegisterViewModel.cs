using Bemerkto.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels;

public class ProductRegisterViewModel
{
    [Required(ErrorMessage = "You need to declare a product name")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;

    [Display(Name = "Product description (optional)")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "You need to declare a product price")]
    [Display(Name = "Product price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }


    public static implicit operator ProductEntity(ProductRegisterViewModel productRegisterViewModel)
    {
        return new ProductEntity
        {
            Title = productRegisterViewModel.Name,
            Description = productRegisterViewModel.Description,
            Price = productRegisterViewModel.Price,
        };
    }
}
