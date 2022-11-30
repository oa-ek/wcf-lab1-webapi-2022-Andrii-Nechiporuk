using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KeysShop.Core
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Ім'я")]
        //[MinLength(3)]
        //[Required(ErrorMessage = "Довжина поля має бути більшою 3 символів")]
        public string? Name { get; set; }

        //[MinLength(3)]
        //[Required(ErrorMessage = "Довжина поля має бути більшою 3 символів")]
        [Display(Name = "Прізвище")]
        public string? Surname { get; set; }

        //[MinLength(10)]
        //[Required(ErrorMessage = "Довжина поля має бути не меншою 10 символів")]
        [Display(Name = "Адреса доставки")]
        public string? Adress { get; set; }

        [Display(Name = "Спосіб оплати")]
        public string? Delivery { get; set; }

        [Display(Name = "Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Електронна скринька")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [BindNever]
        //[ScaffoldColumn(false)]
        public DateTime DateTime { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
