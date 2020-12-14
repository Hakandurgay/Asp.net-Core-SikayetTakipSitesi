using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.ViewModels
{
    public class BrandDetailModelView
    {
        public List<Complaint> Complaints { get; set; }
        public Brand Brand { get; set; }
    }
}
