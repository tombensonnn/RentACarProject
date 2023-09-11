using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userDal)
        {
            _userRepository = userDal;
        }

        public IResult Add(User user)
        {
            _userRepository.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userRepository.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userRepository.GetClaims(user));
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == id));

        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Email == email));
        }

        public IResult Update(User user)
        {
            _userRepository.Update(user);
            return new SuccessResult();
        }
    }
}
