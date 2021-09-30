using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        IDataResult<List<ToDo>> GetAll();
        IDataResult<List<ToDoDto>> GetAllDetails();
        IDataResult<ToDo> Get(int id);
        IDataResult<List<ToDo>> GetAllUserToDo(int userId);
        IResult Add(ToDo toDo);
        IResult Update(ToDo toDo);
        IResult Delete(ToDo toDo);
    }
}
