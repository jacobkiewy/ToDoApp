using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u=>u.Id==userId);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            var result = _userDal.getClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }
    }
}
