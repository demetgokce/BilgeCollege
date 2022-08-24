using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Models.Dtos
{
    public class DersDto
    {

        [Required(ErrorMessage = "Lütfen dersin adını yazınız")]
        [Display(Name = "DersAdı")]
        public string DersAd { get; set; }

        public ICollection<OgretmenDers> Ogretmen { get; set; }



    }
}
