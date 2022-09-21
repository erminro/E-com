using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InernshipApplication.Web.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products;

    }
}
