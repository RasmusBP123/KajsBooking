using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ProductContext
{
    public class CategoryRef : ValueObject<CategoryRef>
    {
        public CategoryRef(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
