using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class CategoryBrand
    {
        public int ID { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}
