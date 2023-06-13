using Bemerkto.Models.Entities;

namespace Bemerkto.Models.ViewModels;

public class ContactFormViewModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = null!;

    public static implicit operator ContactFormEntity(ContactFormViewModel viewModel)
    {
        return new ContactFormEntity
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            CompanyName = viewModel.CompanyName,
            Message = viewModel.Message,
        };
    }
}
