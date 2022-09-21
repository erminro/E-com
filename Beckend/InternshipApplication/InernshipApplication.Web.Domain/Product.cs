using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InernshipApplication.Web.Domain
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}