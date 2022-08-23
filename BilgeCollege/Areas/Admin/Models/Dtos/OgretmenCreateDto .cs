using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Models.Dtos
{
    public class OgretmenCreateDto
    {

        public SelectList Ders { get; set; }
        public OgretmenDto OgretmenDto { get; internal set; }
    }
}
