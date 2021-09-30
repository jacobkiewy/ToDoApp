using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfToDoDal : EfEntityRepositoryBase<ToDo, ToDoContext>, IToDoDal
    {
        public List<ToDoDto> GetAllDetails()
        {
            using (ToDoContext context = new ToDoContext())
            {
                var result = (from t in context.ToDos
                              join u in context.Users
                              on t.UserId equals u.Id
                              select new ToDoDto
                              {
                                  TodoId = t.Id,
                                  UserId = u.Id,
                                  FullName = u.FirstName + ' ' + u.LastName,
                                  Title = t.Title,
                                  Description = t.Description,
                                  P1 = t.Priority1,
                                  P2 = t.Priority2,
                                  P3 = t.Priority3,
                                  StartingDate = t.StartingDate,
                                  EndingDate = t.EndingDate,
                                  Status = t.Status,
                              }).ToList();
                return result.ToList();
            }
        }
    }
}
