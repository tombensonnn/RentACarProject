using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : EfEntityRepositoryBase<User, ReCapContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims
                             on operationClaims.Id equals userOperationClaims.ClaimId
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name, };

                return result.ToList();
            }
        }
    }
}
