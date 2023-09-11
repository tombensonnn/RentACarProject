using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetUserByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
