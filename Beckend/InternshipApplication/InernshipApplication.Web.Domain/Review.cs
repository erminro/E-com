using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InernshipApplication.Web.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public float ReviewGrade { get; set; }
    }
}
