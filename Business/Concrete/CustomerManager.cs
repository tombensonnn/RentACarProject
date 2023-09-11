using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IResult Add(Customer customer)
        {
            _customerRepository.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.Id == id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerRepository.GetAll().ToList());
        }

        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails(int id)
        {
         
           if(id > 0)
            {
                return new SuccessDataResult<List<CustomerDetailsDto>>(_customerRepository.GetCustomerDetails(id), Messages.CustomerDetailsListed);
            }
           else
            {
                return new ErrorDataResult<List<CustomerDetailsDto>>(Messages.SomethingWentWrong);
            }


        }

        public IResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
