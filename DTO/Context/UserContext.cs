using BusinessLayer.DTOModel;
using DTO.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace DTO.Context
{
    public class UserContext : DbContext
    {
        public UserContext()
        //: base("name=UserContext")
        {
        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)

        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=ISB-L-0919-083\SQLEXPRESS;Initial Catalog=Doctor_Patient_Portal;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<PatientAppointmentResponse>();
            modelBuilder.Query<MedicineRequestResponse>();
        }

        public virtual DbSet<User> Users { get; set; } //Mapping
        public virtual DbSet<Appointment> Appointments { get; set; } //Mapping
        public virtual DbSet<MedicineRequest> MedicineRequests { get; set; } //Mapping
    }
}
