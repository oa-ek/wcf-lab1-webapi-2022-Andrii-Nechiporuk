using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Shared.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Введіть ім'я"), MinLength(4)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введіть пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
