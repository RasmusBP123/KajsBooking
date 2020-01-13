using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Item.Queries.GetTodos
{
    public class GetAllTodosQuery : IRequest<IEnumerable<TodoDto>>
    {
        public class TodosRequestHandler : BaseContext, IRequestHandler<GetAllTodosQuery, IEnumerable<TodoDto>>
        {
            public TodosRequestHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
            {
            }

            public async Task<IEnumerable<TodoDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
            {
                var todos = await _dbContext.Todos.ProjectTo<TodoDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                return todos;
            }
        }
    }
}
