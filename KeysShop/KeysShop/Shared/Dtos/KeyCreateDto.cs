using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Shared.Dtos
{
    public class KeyCreateDto
    {
        public int? Id { get; set; }

        //[Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public double? Sale { get; set; }

        public int? Frequency { get; set; }

        public string? Count { get; set; }

        public string? ImgPath { get; set; }

        public bool IsOriginal { get; set; }

        public bool IsKeyless { get; set; }

        public string? Brand { get; set; }
    }
}
