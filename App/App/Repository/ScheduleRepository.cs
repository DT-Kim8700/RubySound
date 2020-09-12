using App.Data;
using App.Models;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {

        private readonly ApplicationContext context;

        public ScheduleRepository(ApplicationContext context)
        {
            this.context = context;
        }




        // 스케쥴 전체 조회
        public IEnumerable<ScheduleListViewModel> GetAllSchedules()
        {
            var query = from schedule in context.Schedules
                        from teacher in context.Teachers
                        join student in context.Students
                        on new { teacher.TeacherId, schedule.StudentId} equals new  { student.TeacherId, student.StudentId}
                        select new { student, teacher, schedule };


            List<ScheduleListViewModel> scheduleListViewModel = new List<ScheduleListViewModel>();

            foreach (var i in query)
            {
                scheduleListViewModel.Add(new ScheduleListViewModel
                {
                    Student = i.student,
                    Teacher = i.teacher,
                    Schedule = i.schedule
                });

            }

            return scheduleListViewModel.OrderBy(s => s.Student.Name)
                                        .ThenByDescending(s => s.Schedule.ScheduleTime);
        }




        // 회원 스케쥴 조회

        // 스케쥴 등록
    }
}
