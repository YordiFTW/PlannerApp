using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlannerApp.Shared;

namespace PlannerApp.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Plan> Plans { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<PlanModel>()
        //      .HasData(
        //          new Job
        //          {
        //              Id = 1,
        //              Name = "John Doe",
        //              Detail = "Test Job 1",
        //              EndDate = DateTime.ParseExact("02/03/2021", "dd/MM/yyyy", null)
        //          },
        //          new Job
        //          {
        //              Id = 2,
        //              Name = "Jane Doe",
        //              Detail = "Test Job 2",
        //              EndDate = DateTime.ParseExact("03/03/2021", "dd/MM/yyyy", null)
        //          },
        //           new Job
        //           {
        //               Id = 3,
        //               Name = "Jane Doe",
        //               Detail = "Test Job 3",
        //               EndDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null)
        //           },
        //            new Job
        //            {
        //                Id = 4,
        //                Name = "Jane Doe",
        //                Detail = "Test Job 4",
        //                EndDate = DateTime.ParseExact("04/03/2021", "dd/MM/yyyy", null)
        //            },
        //             new Job
        //             {
        //                 Id = 5,
        //                 Name = "Jane Doe",
        //                 Detail = "Test Job 5",
        //                 EndDate = DateTime.ParseExact("05/03/2021", "dd/MM/yyyy", null)
        //             }
        //           );
        //    modelBuilder.Entity<Appointment>()
        //        .HasData(
        //               new Appointment
        //               {
        //                   Id = 1,
        //                   AppointmentType = AppointmentType.Chat,
        //                   Detail = "Test Appointment 1",
        //                   Title = "Appointment 1",
        //                   JobId = 5
        //               },
        //               new Appointment
        //               {
        //                   Id = 2,
        //                   AppointmentType = AppointmentType.Email,
        //                   Detail = "Test Appointment 2",
        //                   Title = "Appointment 2",
        //                   JobId = 4
        //               },
        //               new Appointment
        //               {
        //                   Id = 3,
        //                   AppointmentType = AppointmentType.Persoonlijk,
        //                   Detail = "Test Appointment 3",
        //                   Title = "Appointment 3",
        //                   JobId = 3
        //               },
        //               new Appointment
        //               {
        //                   Id = 4,
        //                   AppointmentType = AppointmentType.Persoonlijk,
        //                   Detail = "Test Appointment 4",
        //                   Title = "Appointment 4",
        //                   JobId = 2
        //               },
        //               new Appointment
        //               {
        //                   Id = 5,
        //                   AppointmentType = AppointmentType.Telefonisch,
        //                   Detail = "Test Appointment 5",
        //                   Title = "Appointment 5",
        //                   JobId = 1
        //               }
        //        );
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
                .HasData(
                       new Plan
                       {
                           Id = 1,
                           Catagory = PlannerApp.Shared.Enums.PlanCatagoryEnum.Event1,
                           Detail = "Test Plan 1",
                           Title = "Plan 1",
                       });
        }
    }


}
  