using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ders
    {

        public int DersId { get; set; }
        [Required(ErrorMessage = "Lütfen dersin adını yazınız")]
        [Display(Name = "DersAdı")]
        public string DersAd { get; set; }








        public ICollection<OgretmenDers> Ogretmen { get; set; }

    }
}
