using App.Models;
using App.Models.Account;
using App.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class ApplicationContext : IdentityDbContext<AccountUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Community> Communitys { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 시퀀스 설정
            // Teacher
            builder.HasSequence<int>("TeacherIdSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);

            builder.Entity<Teacher>()
                    .Property(t => t.TeacherId)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.TeacherIdSequence");

            // Student
            builder.HasSequence<int>("StudentIdSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);

            builder.Entity<Student>()
                    .Property(s => s.StudentId)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.StudentIdSequence");

            // Schedule
            builder.HasSequence<int>("ScheduleIdSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);

            builder.Entity<Schedule>()
                    .Property(s => s.ScheduleId)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.ScheduleIdSequence");

            // AccountUser
            builder.HasSequence<int>("AccountUserIdSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);

            builder.Entity<AccountUser>()
                    .Property(a => a.Id)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.AccountUserIdSequence");

            // Community
            builder.HasSequence<int>("CommunityIdSequence", schema: "shared")
                    .StartsAt(1)
                    .IncrementsBy(1);

            builder.Entity<Community>()
                    .Property(c => c.CommunityId)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.CommunityIdSequence");
        }



    }
}
