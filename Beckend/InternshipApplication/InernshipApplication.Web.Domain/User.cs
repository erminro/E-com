using System;
using System.Collections.Generic;

namespace InernshipApplication.Web.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
