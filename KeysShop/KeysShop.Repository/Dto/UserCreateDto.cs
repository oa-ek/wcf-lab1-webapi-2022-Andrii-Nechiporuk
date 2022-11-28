using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository.Dto
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Введіть ім'я")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FirstName { get; set; }
    }
}
