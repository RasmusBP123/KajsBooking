using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Item.Commands
{
    public class CreateItemCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public class CreateItemRequestHandler : BaseContext, IRequestHandler<CreateItemCommand, bool>
        {
            public CreateItemRequestHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
            {
            }

            public Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
            {
                var item = new Todo()
                {
                    Name = request.Name
                };

                _dbContext.Todos.Add(item);
                var result = _dbContext.SaveChanges();

                return Task.FromResult(result);
            }
        }
    }
}
