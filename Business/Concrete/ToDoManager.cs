using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        IUserService _userService;
        public ToDoManager(IToDoDal toDoDal,IUserService userService)
        {
            _toDoDal = toDoDal;
            _userService = userService;
        }
        [ValidationAspect(typeof(ToDoValidator))]
        public IResult Add(ToDo toDo)
        {
            //userId angulardan tokendan gelecek ve todo user a kayıtlı olacak
            toDo.StartingDate = DateTime.Now;
            _toDoDal.Add(toDo);
            return new SuccessResult(Messages.ToDoAdded);
        }

        public IResult Delete(ToDo toDo)
        {
            _toDoDal.Delete(toDo);
            return new SuccessResult(Messages.ToDoDeleted);
        }

        public IDataResult<ToDo> Get(int id)
        {
            var result = _toDoDal.Get(t => t.Id == id);
            return new SuccessDataResult<ToDo>(result);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<ToDo>> GetAll()
        {
            var results = _toDoDal.GetAll();
            return new SuccessDataResult<List<ToDo>>(results, Messages.ToDoListed);
        }

        public IDataResult<List<ToDo>> GetAllUserToDo(int userId)
        {
            var userResult = _userService.GetById(userId);
            var userToDoResult = _toDoDal.GetAll(t=>t.UserId == userId);
            var result = this.ToDoControl(userToDoResult.Count);
            return new SuccessDataResult<List<ToDo>>(userToDoResult, userResult.Data.FirstName + " " + result.Message);
        }

        public IResult Update(ToDo toDo)
        {
            toDo.StartingDate = _toDoDal.Get(t => t.Id == toDo.Id).StartingDate;
            if (!toDo.Status)
            {
                toDo.EndingDate = DateTime.Now;
            }
            _toDoDal.Update(toDo);
            return new SuccessResult(Messages.ToDoUpdated);
        }



        //BusinessRules
        public IResult ToDoControl(int toDoCount)
        {
            string message;
            if (toDoCount!=0)
            {
                message = "Yapılacak İşlerin Var :D";
            }
            else
            {
                message = "Hiç İş Yok :(";
            }
            return new SuccessResult(message);
        }
    }
}
