using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "회원님 성함을 입력하세요.")]
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

        [Required(ErrorMessage = "배우고 싶은 악기를 입력하세요.")]
        public Student.Instrument Ins { get; set; }

        [Required(ErrorMessage = "담당 선생님을 입력하세요.")]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
