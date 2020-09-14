using App.Models;
using App.Models.Account;
using App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class DBSeeder
    {
        private readonly ApplicationContext context;
        private readonly UserManager<AccountUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DBSeeder(ApplicationContext context, 
            UserManager<AccountUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedDatabase()
        {
            if (!context.Teachers.Any())    // Teachers 테이블에 데이터가 없을 때 초기 값 설정. 테이블에 데이터가 있다면 반영되지 않는다.
            {
                // DB 초기 더미 데이터 설정.
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher() {Name = "김해원", Birthday = "1111-11-11", Gender = "여", Email ="Violin@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Teacher.Instrument.Violin},
                    new Teacher() {Name = "한현지", Birthday = "1111-11-11", Gender = "여", Email ="Flute@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Teacher.Instrument.Flute},
                    new Teacher() {Name = "호아영", Birthday = "1111-11-11", Gender = "여", Email ="Piano@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Teacher.Instrument.Piano},
                    new Teacher() {Name = "윤정원", Birthday = "1111-11-11", Gender = "남", Email ="Guitar@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Teacher.Instrument.Guitar},
                };

                await context.AddRangeAsync(teachers);

                await context.SaveChangesAsync();

            }

            if (!context.Students.Any())
            {
                List<Student> students = new List<Student>()
                {
                    new Student() {Name = "김용범", Birthday = "1111-11-11", Gender = "남", Email ="RubySound1@naver.com",
                        PhoneNumber = "01011112222", Address = "두암동", Ins = Student.Instrument.Flute, TeacherId = 1005},
                    new Student() {Name = "홍은채", Birthday = "1111-11-11", Gender = "여", Email ="RubySound2@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Violin, TeacherId = 1000},
                    new Student() {Name = "조은진", Birthday = "1111-11-11", Gender = "여", Email ="RubySound3@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Viola, TeacherId = 1000},
                    new Student() {Name = "이평영", Birthday = "1111-11-11", Gender = "남", Email ="RubySound4@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Violin, TeacherId = 1000},
                    new Student() {Name = "박지원", Birthday = "1111-11-11", Gender = "여", Email ="RubySound5@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010},
                    new Student() {Name = "장혜주", Birthday = "1111-11-11", Gender = "여", Email ="RubySound6@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Guitar, TeacherId = 1015},
                    new Student() {Name = "박지혁", Birthday = "1111-11-11", Gender = "남", Email ="RubySound7@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010},
                    new Student() {Name = "김다혜", Birthday = "1111-11-11", Gender = "여", Email ="RubySound8@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010}
                };

                await context.AddRangeAsync(students);

                await context.SaveChangesAsync();

            }

            if (!context.Communitys.Any())
            {
                List<Community> communities = new List<Community>();

                for (int i = 1; i < 105; i++)
                {
                    communities.Add(
                        new Community()
                        {
                            Title = "글 제목입니다",
                            Description = "글 본문입니다.",
                            EnrollTime = DateTime.Now,
                            Id = "70297927-a8c8-438b-8b0a-cc6df1977bf4"
                        });
                };

                await context.AddRangeAsync(communities);

                await context.SaveChangesAsync();
            }

            if (!context.Schedules.Any())    // Teachers 테이블에 데이터가 없을 때 초기 값 설정. 테이블에 데이터가 있다면 반영되지 않는다.
            {
                // DB 초기 더미 데이터 설정.
                List<Schedule> schedules = new List<Schedule>()
                {
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 3, 20, 0, 0), StudentId = 1005 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 10, 19, 0, 0), StudentId = 1005 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 17, 20, 0, 0), StudentId = 1005 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 24, 18, 0, 0), StudentId = 1005 },

                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 2, 20, 0, 0), StudentId = 1000 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 9, 20, 0, 0), StudentId = 1000 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 17, 21, 0, 0), StudentId = 1000 },
                    new Schedule() {ScheduleTime = new DateTime(2020, 9, 23, 19, 0, 0), StudentId = 1000 }
                };

                await context.AddRangeAsync(schedules);

                await context.SaveChangesAsync();

            }


            // 테이블 데이터 삭제 
            //context.Communitys.RemoveRange(context.Communitys);
            //await context.SaveChangesAsync();

            // 계정에 운영자 권한 부여 : master@naver.com 에 manager 역할을 부여
            var adminAccount = await userManager.FindByNameAsync("master@naver.com");
            var adminRole = new IdentityRole("manager");
            await roleManager.CreateAsync(adminRole);
            await userManager.AddToRoleAsync(adminAccount, adminRole.Name);

        }
    }
}

/*
enable-migrations
EntityFrameworkCore\add-migration RubySoundV10
EntityFrameworkCore\update-database
 */