using App.Models;
using App.Models.Account;
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
                // DB 초기 데이터 설정.
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

            if (!context.Students.Any())    // Students 테이블에 데이터가 없을 때 초기 값 설정. 테이블에 데이터가 있다면 반영되지 않는다.
            {
                // DB 초기 데이터 설정.
                List<Student> students = new List<Student>()
                {
                    new Student() {Name = "김용범", Birthday = "1111-11-11", Gender = "남", Email ="RubySound1@naver.com",
                        PhoneNumber = "01011112222", Address = "두암동", Ins = Student.Instrument.Flute, TeacherId = 1005},
                    new Student() {Name = "홍은채", Birthday = "1111-11-11", Gender = "여", Email ="RubySound2@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Violin, TeacherId = 1000},
                    new Student() {Name = "조은진", Birthday = "1111-11-11", Gender = "여", Email ="RubySound2@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Viola, TeacherId = 1000},
                    new Student() {Name = "이평영", Birthday = "1111-11-11", Gender = "남", Email ="RubySound3@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Violin, TeacherId = 1000},
                    new Student() {Name = "박지원", Birthday = "1111-11-11", Gender = "여", Email ="RubySound4@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010},
                    new Student() {Name = "장혜주", Birthday = "1111-11-11", Gender = "여", Email ="RubySound5@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Guitar, TeacherId = 1015},
                    new Student() {Name = "박지혁", Birthday = "1111-11-11", Gender = "남", Email ="RubySound6@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010},
                    new Student() {Name = "김다혜", Birthday = "1111-11-11", Gender = "여", Email ="RubySound7@naver.com",
                        PhoneNumber = "01011112222", Address = "일곡동", Ins = Student.Instrument.Piano, TeacherId = 1010}
                };

                await context.AddRangeAsync(students);

                await context.SaveChangesAsync();

            }


            // 계정에 운영자 권한 부여 : master@naver.com 에 manager 역할을 부여
            var adminAccount = await userManager.FindByNameAsync("master@naver.com");             
            var adminRole = new IdentityRole("manager");                                   
            await roleManager.CreateAsync(adminRole);                                     
            await userManager.AddToRoleAsync(adminAccount, adminRole.Name);          

        }
    }
}

/*
add-migration RubySoundV2
update-database
 */