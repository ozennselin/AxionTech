using Core.Enums;
using Core.Models.Entities.Customer;

namespace Business.Service.Interfaces;

public interface ICustomerService
{
    ResponseMessageEnum Create(CreateCustomerRequestModel request);
    void Update(UpdateCustomerRequestModel request);
    void Delete(DeleteCustomerRequestModel request);
    List<CustomerResponseModel> List();
    CustomerResponseModel GetById(int id);
}
