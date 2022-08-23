using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Siniflar
    {

        public int SiniflarId { get; set; }
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }




        public ICollection<OgrenciSiniflar> Ogrenci { get; set; }



    }
}
