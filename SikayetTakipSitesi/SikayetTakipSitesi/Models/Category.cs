using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class Category
    {
        [Key]
        public int PK_CATEGORY_ID { get; set; }
        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
