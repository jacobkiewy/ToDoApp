﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeedBackService
    {
        IResult Add(FeedBack feedBack);
        IResult Delete(FeedBack feedBack);
        IResult Update(FeedBack feedBack);  
        IDataResult<List<FeedBack>> GetAll();
        IDataResult<FeedBack> Get();
    }
}
