using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IStudentRepository
    {
        bool AddStudent(StudentAddViewModel model);
        void Delete(int? studentId);
        List<StudentListViewModel> GetAllStudents();
        IEnumerable<Teacher> GetTeachers();
        void Save();
    }
}