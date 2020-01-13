using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Item.Queries.GetTodos
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
