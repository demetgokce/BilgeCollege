using Domain;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Models.Dtos
{
    public class OgrenciDto
    {

        [Required(ErrorMessage = "Ad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Soyadi { get; set; }


        [Required(ErrorMessage = "TCNo Alani Boş Olamaz")]
        [MaxLength(11)]
        public string TcNo { get; set; }

        [EmailAddress]
        public string EPosta { get; set; }

        [Phone]
        public string Gsm { get; set; }

        [Required]
        [Display(Name = "Okula Giriş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GirisTarih { get; set; }

        [Display(Name = "Okuldan Çıkış Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CikisTarih { get; set; }
        public DateTime DogumTarih { get; set; }



        public int SinifId { get; set; }
        public Siniflar Sinif { get; set; }

    }
}
