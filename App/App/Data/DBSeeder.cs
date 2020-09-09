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
            if (!context.Teachers.Any())    // Teachers 테이블에 데이터가 없을 때 초기 값 설정. 있다면 반영되지 않는다.
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

            // 계정에 운영자 권한 부여
            //var adminAccount = await userManager.FindByNameAsync("Manager");                   // AspNetUsers 안에 해당 UserName의 데이터가 있는지 찾는다.
            //var adminRole = new IdentityRole("Admin");                                      // 만들어낼 Role의 이름을 넣는다.
            //await roleManager.CreateAsync(adminRole);                                       // 만들어낸 Role을 Role 테이블에(AspNetRoles) 추가한다.
            //await userManager.AddToRoleAsync(adminAccount, adminRole.Name);                 // 첫번째 인자의 데이터의 계정, 두번째 인자의 권한이름을 AspNetUesrRoles 테이블에 추가한다.

        }
    }
}

/*
add-migration RubySoundV1
update-database
 */