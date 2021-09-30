using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class FeedBackManager : IFeedBackService
    {
        IFeedBackDal _feedBackDal;

        public FeedBackManager(IFeedBackDal feedBackDal)
        {
            _feedBackDal = feedBackDal;
        }

        public IResult Add(FeedBack feedBack)
        {
            feedBack.Status = true;
            feedBack.Date = DateTime.Now;
            _feedBackDal.Add(feedBack);
            return new SuccessResult(Messages.AddedFeedBack);
        }

        [SecuredOperation("admin")]
        public IResult Delete(FeedBack feedBack)
        {
            _feedBackDal.Delete(feedBack);
            return new SuccessResult(Messages.DeletedFeedBack);
        }
        [SecuredOperation("admin")]
        public IDataResult<FeedBack> Get()
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("admin")]
        public IDataResult<List<FeedBack>> GetAll()
        {
            var result = _feedBackDal.GetAll();
            return new SuccessDataResult<List<FeedBack>>(result,Messages.ListedFeedBack);
        }
    }
}
