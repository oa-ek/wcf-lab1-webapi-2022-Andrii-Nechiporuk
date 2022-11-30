using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KeysShop.Repository.Dto
{
    public class OrderDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Adress { get; set; }

        public string? Delivery { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
