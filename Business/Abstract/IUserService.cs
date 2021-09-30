﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(int userId);
        IDataResult<List<UserDto>> GetAll();
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
    }
}
