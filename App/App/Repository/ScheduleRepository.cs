﻿using App.Data;
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

            if (query.Any())
            {
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

            return scheduleListViewModel;
        }

        // 개인회원 스케쥴 조회
        public ChangeScheduleViewModel GetOneSchedules(int? studentId)
        { 
            var query = from schedule in context.Schedules
                        from teacher in context.Teachers
                        join student in context.Students
                        on new { teacher.TeacherId, schedule.StudentId } equals new { student.TeacherId, student.StudentId }
                        where schedule.StudentId == studentId
                        orderby schedule.ScheduleTime descending
                        select new { student, teacher, schedule };

            ChangeScheduleViewModel changeScheduleViewModel = null;

            if (query.Any())
            {
                changeScheduleViewModel = new ChangeScheduleViewModel()
                {
                    Teacher = query.FirstOrDefault().teacher,
                    Student = query.FirstOrDefault().student,
                    Schedules = new List<Schedule>()
                };

                foreach (var s in query)
                {
                    changeScheduleViewModel.Schedules.Add(s.schedule);
                }
            }
            else
            {
                changeScheduleViewModel = new ChangeScheduleViewModel()
                {
                    Student = context.Students.Where(s => s.StudentId == studentId).FirstOrDefault()
                };
            }
            return changeScheduleViewModel;
        }

        public ChangeScheduleViewModel MySchedule(string email)    // User.Identity.Name => Email
        {
            var query = from schedule in context.Schedules
                        from teacher in context.Teachers
                        join student in context.Students
                        on new { teacher.TeacherId, schedule.StudentId } equals new { student.TeacherId, student.StudentId }
                        where student.Email == email
                        orderby schedule.ScheduleTime descending
                        select new { student, teacher, schedule };

            ChangeScheduleViewModel changeScheduleViewModel = null;

            if (query.Any())
            {
                changeScheduleViewModel = new ChangeScheduleViewModel()
                {
                    Teacher = query.FirstOrDefault().teacher,
                    Student = query.FirstOrDefault().student,
                    Schedules = new List<Schedule>()
                };

                foreach (var s in query)
                {
                    changeScheduleViewModel.Schedules.Add(s.schedule);
                }
            }

            return changeScheduleViewModel;
        }


        // 스케쥴 취소
        public void Delete(int? scheduleId)
        {
            Schedule schedule = context.Schedules.FirstOrDefault(s => s.ScheduleId == scheduleId);

            context.Schedules.Remove(schedule);
        }

        // 스케쥴 추가
        public void Add(ChangeScheduleViewModel model)
        {
            Schedule schedule = new Schedule
            {
                ScheduleTime = new DateTime(model.ScheduleYear, model.ScheduleMonth, model.ScheduleDay, model.ScheduleHour, 0,0),
                StudentId = model.StudentId,
                LessonStatus = Schedule.Status.Waiting
            };

            context.Schedules.Add(schedule);
        }

        // 선생님 전체 스케쥴 가져오기
        public List<ScheduleListViewModel> GetTeacherSchedules(int teacherId)
        {
            var query = from schedule in context.Schedules
                        from teacher in context.Teachers
                        join student in context.Students
                        on new { teacher.TeacherId, schedule.StudentId } equals new { student.TeacherId, student.StudentId }
                        where student.TeacherId == teacherId
                        orderby schedule.ScheduleTime descending
                        select new { student, teacher, schedule };

            List<ScheduleListViewModel> scheduleListViewModels = new List<ScheduleListViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    scheduleListViewModels.Add(new ScheduleListViewModel
                    {
                        Student = i.student,
                        Teacher = i.teacher,
                        Schedule = i.schedule
                    });

                }

                return scheduleListViewModels;
            }

            return scheduleListViewModels;

        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
