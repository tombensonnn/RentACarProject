using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerRepository : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerRepository
    {
        public List<CustomerDetailsDto> GetCustomerDetails(int userId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             where c.Id == userId
                             select new CustomerDetailsDto { 
                                 CustomerId = c.Id, 
                                 UserId = u.Id, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 Email = u.Email
                             };

                return result.ToList();
            }
        }
    }
}
