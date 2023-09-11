using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailsDto>> GetCustomerDetails(int id);
        IDataResult<Customer> Get(int id);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
