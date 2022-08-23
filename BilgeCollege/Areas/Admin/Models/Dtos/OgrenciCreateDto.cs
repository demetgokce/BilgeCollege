using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace   BilgeCollege.Areas.Admin.Models.Dtos
{
    public class OgrenciCreateDto
    {
        public OgrenciDto OgrenciDto { get; set; }
        public SelectList Sinif { get; set; }

    }
}
