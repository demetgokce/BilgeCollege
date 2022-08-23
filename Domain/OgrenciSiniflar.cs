using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OgrenciSiniflar
    {
        public int OgrenciId { get; set; }

        public Ogrenci Ogrenci { get; set; }
        public int SiniflarId { get; set; }

        public Siniflar Siniflar { get; set; }

    }
}