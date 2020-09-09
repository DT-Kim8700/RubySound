using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email을 입력하세요."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요.") , DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
