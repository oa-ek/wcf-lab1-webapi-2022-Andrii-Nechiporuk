using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Shared.Dtos
{
    public class KeyCreateDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(16), MinLength(4)]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public double? Sale { get; set; }
        [Required]
        public int? Frequency { get; set; }
        [Required]
        public string? Count { get; set; }
        [Required]
        public string? ImgPath { get; set; }
        [Required]
        public bool IsOriginal { get; set; }
        [Required]
        public bool IsKeyless { get; set; }
        [Required]
        public string? Brand { get; set; }
    }
}
