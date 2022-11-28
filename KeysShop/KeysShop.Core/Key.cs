using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KeysShop.Core
{
    public class Key
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Назва товару")]
        public string? Name { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        [Display(Name = "Ціна")]
        public double? Price { get; set; }
        public double? Sale { get; set; }
        [Display(Name = "Частота")]
        public int? Frequency { get; set; }
        [Display(Name = "Залишок")]
        public string? Count { get; set; }
        [Display(Name = "Фото")]
        public string? ImgPath { get; set; }
        [Display(Name = "Оригінальний")]
        public bool IsOriginal { get; set; }
        [Display(Name = "Wireless key")]
        public bool IsKeyless { get; set; }
        [Display(Name = "Бренд")]
        public Brand? Brand { get; set; }
        [Display(Name = "Відгуки")]
        public List<Feedback>? feedbacks { get; set; }
    }
}