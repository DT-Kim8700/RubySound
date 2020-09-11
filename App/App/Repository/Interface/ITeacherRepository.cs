using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface ITeacherRepository
    {
        TeacherListViewModel GetAllTeachers();
    }
}