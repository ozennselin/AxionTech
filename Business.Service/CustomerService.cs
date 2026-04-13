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
            CustomerType = (Core.Enums.CustomerTypeEnum)request.CustomerType,
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
        var customer = _customerRepository.GetById(request.Id);

        if (customer == null) return;

        _customerRepository.Delete(customer);
    }

    public List<CustomerResponseModel> List()
    {
        var customers = _customerRepository.GetAll().ToList();

        return customers.Select(x => new CustomerResponseModel
        {
            Id = x.Id,
            CustomerType = (int)x.CustomerType,
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
        var customer = _customerRepository.GetById(request.Id);

        if (customer == null) return;

        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;
        customer.AddressLine1 = request.AddressLine1;
        customer.AddressLine2 = request.AddressLine2;
        customer.City = request.City;
        customer.Country = request.Country;
        customer.PostalCode = request.PostalCode;
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.TCKN = request.TCKN;
        customer.CompanyName = request.CompanyName;
        customer.TaxOffice = request.TaxOffice;
        customer.TaxNumber = request.TaxNumber;
        customer.IsActive = request.IsActive;

        _customerRepository.Update(customer);
    }

    public CustomerResponseModel GetById(int id)
    {
        var customer = _customerRepository.GetById(id);

        if (customer == null)
            return null;

        return new CustomerResponseModel
        {
            Id = customer.Id,
            CustomerType = (int)customer.CustomerType,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            AddressLine1 = customer.AddressLine1,
            AddressLine2 = customer.AddressLine2,
            City = customer.City,
            Country = customer.Country,
            PostalCode = customer.PostalCode,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            TCKN = customer.TCKN,
            CompanyName = customer.CompanyName,
            TaxOffice = customer.TaxOffice,
            TaxNumber = customer.TaxNumber,
            IsActive = customer.IsActive
        };
    }
}
