﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ToDoContext>, IUserDal
    {
        public List<UserDto> GetAll()
        {
            using (var context = new ToDoContext())
            {
                var result = (from user in context.Users
                              select new UserDto
                              {
                                  UserId = user.Id,
                                  FullName = user.FirstName + ' ' + user.LastName,
                                  Email = user.Email,
                                  Status = user.Status
                              }).ToList();
                return result.ToList();
            }
        }

        public List<OperationClaim> getClaims(User user)
        {
            using (var context = new ToDoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
