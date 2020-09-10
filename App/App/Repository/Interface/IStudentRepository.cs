using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IStudentRepository
    {
        List<StudentViewModel> GetAllStudents();
    }
}