using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IScheduleRepository
    {
        void Add(ChangeScheduleViewModel model);
        void Delete(int? scheduleId);
        IEnumerable<ScheduleListViewModel> GetAllSchedules();
        ChangeScheduleViewModel GetOneSchedules(int? studentId);
        List<ScheduleListViewModel> GetTeacherSchedules(int teacherId);
        ChangeScheduleViewModel MySchedule(string email);
        void Save();
    }
}