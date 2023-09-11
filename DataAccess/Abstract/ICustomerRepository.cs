using Entities.Concrete;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<CustomerDetailsDto> GetCustomerDetails(int userId);
    }
}
