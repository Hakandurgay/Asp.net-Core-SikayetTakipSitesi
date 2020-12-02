using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class Brand
    {
        [Key]
        public int  PK_BRAND_ID { get; set; }
        public string BrandName { get; set; }

        public bool BrandStatus { get; set; }

        public string BrandPhoto { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Complaint> Complaints { get; set; }

    }
}
