using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IStudentRepository
    {
        void Delete(int? studentId);
        List<StudentListViewModel> GetAllStudents();
        void Save();
    }
}