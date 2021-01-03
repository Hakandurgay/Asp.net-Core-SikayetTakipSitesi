using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.ViewModels
{
    public class HomeViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Complaint> Complaint { get; set; }
        public List<String> BrandNames { get; set; }
    }
}
