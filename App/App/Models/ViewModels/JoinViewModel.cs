using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class JoinViewModel
    {
        [Required(ErrorMessage = "E-Mail을 입력하세요."), EmailAddress]          // Email 구조만 입력값으로 받는다.
        public string Email { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요."), DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password", ErrorMessage = "비밀번호를 다시 입력하세요.")]     // Compare : 지정한 필드와 값이 같은지 비교한다.
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "이름을 입력하세요.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "성별을 입력하세요.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "주소를 입력하세요.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "핸드폰 번호를 입력하세요.")]
        public string PhoneNumber { get; set; }

    }
}
