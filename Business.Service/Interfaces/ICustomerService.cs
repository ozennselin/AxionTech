using Core.Enums;
using Core.Models.Entities.Customer;

namespace Business.Service.Interfaces;

public interface ICustomerService
{
    public ResponseMessageEnum Create(CreateCustomerRequestModel request);
    ResponseMessageEnum Update(UpdateCustomerRequestModel request);
    ResponseMessageEnum Delete(DeleteCustomerRequestModel request);
    List<CustomerResponseModel> List();
    CustomerResponseModel GetById(int id);
}
