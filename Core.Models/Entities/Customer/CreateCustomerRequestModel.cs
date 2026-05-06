using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Customer;

public class CreateCustomerRequestModel:BaseCreateModel
{
    public int CustomerType { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;    // Individual alanları (kurumsalda boş kalır)
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? TCKN { get; set; } // Corporate alanları (bireyselde boş kalır)
    public string? CompanyName { get; set; }
    public string? TaxOffice { get; set; }
    public string? TaxNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}
