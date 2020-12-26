using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Database.Entity
{
    public class Product
    {
        [Key]
        public Guid id  { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int averageRating { get; set; }
        public int numberOfRaters { get; set; }
    }
}
