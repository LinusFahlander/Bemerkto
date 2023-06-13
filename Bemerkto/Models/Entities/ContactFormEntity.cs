﻿namespace Bemerkto.Models.Entities;

public class ContactFormEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = null!;
}
