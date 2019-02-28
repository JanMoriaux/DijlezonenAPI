using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class ProductCreateObject
    {
        public int CriticalStock { get; set; }
        public int InStock { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
