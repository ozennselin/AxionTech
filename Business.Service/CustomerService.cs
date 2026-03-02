using Business.Service.Interfaces;
using Core.Models.Entities.Customer;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository=customerRepository;
    }
    public void Create(CreateCustomerRequestModel request)
    {
        var customer = new Customer
        {
            CustomerTypeId = request.CustomerTypeId,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            City = request.City,
            Country = request.Country,
            PostalCode = request.PostalCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            TCKN = request.TCKN,
            CompanyName = request.CompanyName,
            TaxOffice = request.TaxOffice,
            TaxNumber = request.TaxNumber,
            IsActive = true
        };

        _customerRepository.Add(customer);
    }

    public void Delete(DeleteCustomerRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<CustomerResponseModel> List()
    {
        var customers = _customerRepository.GetAll().ToList();

        return customers.Select(x => new CustomerResponseModel
        {
            Id = x.Id,
            CustomerTypeId = x.CustomerTypeId,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            AddressLine1 = x.AddressLine1,
            AddressLine2 = x.AddressLine2,
            City = x.City,
            Country = x.Country,
            PostalCode = x.PostalCode,
            FirstName = x.FirstName,
            LastName = x.LastName,
            TCKN = x.TCKN,
            CompanyName = x.CompanyName,
            TaxOffice = x.TaxOffice,
            TaxNumber = x.TaxNumber,
            IsActive = x.IsActive
        }).ToList();
    }

    public void Update(UpdateCustomerRequestModel request)
    {
        throw new NotImplementedException();
    }
}
