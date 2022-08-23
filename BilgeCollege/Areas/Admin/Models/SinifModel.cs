using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Models
{
    public class SinifModel
    {
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }



        public ICollection<Ogrenci> Ogrenci { get; set; }



    }
}
