using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface IScheduleRepository
    {
        void AddSchedule(ChangeScheduleViewModel model);
        void Delete(int? scheduleId);
        IEnumerable<ScheduleListViewModel> GetAllSchedules();
        ChangeScheduleViewModel GetOneSchedules(int? studentId);
        void Save();
    }
}