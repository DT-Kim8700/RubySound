using App.Models;
using System.Collections.Generic;

namespace App.Repository
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
    }
}