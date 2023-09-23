using BusinessLogic.Employee;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(string connectionString): base(connectionString) { }
        public DbSet<EmployeeDTO> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigEmployee(modelBuilder.Entity<EmployeeDTO>());
        }

        private void ConfigEmployee(EntityTypeConfiguration<EmployeeDTO> configuration)
        {
            configuration.ToTable("Empleados");
            configuration.Property(e => e.Id).HasColumnName("ID");
            configuration.Property(e => e.Name).HasColumnName("Nombre").IsRequired();
            configuration.Property(e => e.Surname).HasColumnName("Apellido").IsRequired();
            configuration.Property(e => e.Email).HasColumnName("Email").IsRequired();
            configuration.Property(e => e.Salary.Amount).HasColumnName("Salario").IsRequired();
        }
    }
}
