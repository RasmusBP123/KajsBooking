using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Base
{
    public abstract class BaseContext
    {
        protected readonly IApplicationDBContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseContext(IApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
