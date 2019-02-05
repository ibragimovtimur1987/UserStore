using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.Models
{
    public class LoginModel
    {
        [Display(Name = "Почтовый ящик")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
