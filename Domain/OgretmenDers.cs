using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OgretmenDers
    {
        public int OgretmenId { get; set; }

        public Ogretmen Ogretmen { get; set; }
        public int DersId { get; set; }

        public Ders Ders { get; set; }


    }
}
