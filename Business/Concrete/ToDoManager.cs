using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public ToDoManager(IToDoDal toDoDal, IUserService userService)
        {
            _toDoDal = toDoDal;
            _userService = userService;
        }
        [ValidationAspect(typeof(ToDoValidator))]
        public IResult Add(ToDo toDo)
        {
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
            var userToDoResult = _toDoDal.GetAll(t => t.UserId == userId).OrderByDescending(t => t.Id).ToList();
            var result = this.ToDoControl(userToDoResult);
            return new SuccessDataResult<List<ToDo>>(userToDoResult, userResult.Data.FirstName + " " + result.Message);
        }

        [ValidationAspect(typeof(ToDoValidator))]
        public IResult Update(ToDo toDo)
        {
            toDo.StartingDate = _toDoDal.Get(t => t.Id == toDo.Id).StartingDate;
            var endDate = _toDoDal.Get(t => t.Id == toDo.Id).EndingDate;
            if (!toDo.Status && endDate == null)
            {
                toDo.EndingDate = DateTime.Now;
            }
            _toDoDal.Update(toDo);
            return new SuccessResult(Messages.ToDoUpdated);
        }



        //BusinessRules
        public IResult ToDoControl(List<ToDo> toDos)
        {
            string message = "Hiç İş Yok :(";
            foreach (var toDo in toDos)
            {
                if (toDo.Status != false)
                {
                    message = "Yapılacak İşlerin Var :D";
                    return new SuccessResult(message);
                }
                else
                {
                    message = "Hiç İş Yok :(";
                }

            }
            return new SuccessResult(message);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<ToDoDto>> GetAllDetails()
        {
            var result = _toDoDal.GetAllDetails().OrderByDescending(t=>t.TodoId).ToList();
            return new SuccessDataResult<List<ToDoDto>>(result,Messages.GetAllDetails);
        }
    }
}
