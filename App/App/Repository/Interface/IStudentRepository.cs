using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IStudentRepository
    {
        bool Add(StudentViewModel model);
        void Delete(int? studentId);
        List<StudentListViewModel> GetAllStudents();
        StudentViewModel GetOneStudent(int studentId);
        IEnumerable<Teacher> GetTeachers();
        void Save();
        bool Update(StudentViewModel model);
    }
}