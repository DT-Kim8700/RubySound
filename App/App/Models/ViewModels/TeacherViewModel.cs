using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class TeacherViewModel
    {

        public int TeacherId { get; set; }

        [Required(ErrorMessage = "선생님 성함을 입력하세요.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "생년월일을 입력하세요.")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "성별을 입력하세요.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "E-Mail을 입력하세요."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "핸드폰 번호를 입력하세요.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "주소를 입력하세요.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "전공 악기를 입력하세요.")]
        public Teacher.Instrument Ins { get; set; }
    }
}
