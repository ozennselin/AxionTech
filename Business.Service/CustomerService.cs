using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Customer;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public ResponseMessageEnum Create(CreateCustomerRequestModel request)
    {
        try
        {
            Customer customer = new Customer();

            customer.CustomerType = (Core.Enums.CustomerTypeEnum)request.CustomerType;
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
            customer.IsActive = true;

            _customerRepository.Add(customer);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

    public ResponseMessageEnum Delete(DeleteCustomerRequestModel request)
    {
        try
        {
            var getCustomer = _customerRepository.GetById(request.Id);

            if (getCustomer == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getCustomer.IsActive = false;
            _customerRepository.Update(getCustomer);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public CustomerResponseModel GetById(int Id)
    {
        var getCustomer = _customerRepository.GetById(Id);

        CustomerResponseModel response = new CustomerResponseModel();

        response.Id = getCustomer.Id;
        response.CustomerType = (int)getCustomer.CustomerType;
        response.Email = getCustomer.Email;
        response.PhoneNumber = getCustomer.PhoneNumber;
        response.AddressLine1 = getCustomer.AddressLine1;
        response.AddressLine2 = getCustomer.AddressLine2;
        response.City = getCustomer.City;
        response.Country = getCustomer.Country;
        response.PostalCode = getCustomer.PostalCode;
        response.FirstName = getCustomer.FirstName;
        response.LastName = getCustomer.LastName;
        response.TCKN = getCustomer.TCKN;
        response.CompanyName = getCustomer.CompanyName;
        response.TaxOffice = getCustomer.TaxOffice;
        response.TaxNumber = getCustomer.TaxNumber;
        response.IsActive = getCustomer.IsActive;

        return response;
    }

    public List<CustomerResponseModel> List()
    {
        var customerList = _customerRepository
            .GetAll()
            .Where(x => x.IsActive == true)
            .ToList();

        return customerList.Select(x => new CustomerResponseModel
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

    public ResponseMessageEnum Update(UpdateCustomerRequestModel request)
    {
        try
        {
            var getCustomer = _customerRepository.GetById(request.Id);

            if (getCustomer == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getCustomer.CustomerType = (Core.Enums.CustomerTypeEnum)request.CustomerType;
            getCustomer.Email = request.Email;
            getCustomer.PhoneNumber = request.PhoneNumber;
            getCustomer.AddressLine1 = request.AddressLine1;
            getCustomer.AddressLine2 = request.AddressLine2;
            getCustomer.City = request.City;
            getCustomer.Country = request.Country;
            getCustomer.PostalCode = request.PostalCode;
            getCustomer.FirstName = request.FirstName;
            getCustomer.LastName = request.LastName;
            getCustomer.TCKN = request.TCKN;
            getCustomer.CompanyName = request.CompanyName;
            getCustomer.TaxOffice = request.TaxOffice;
            getCustomer.TaxNumber = request.TaxNumber;

            _customerRepository.Update(getCustomer);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}