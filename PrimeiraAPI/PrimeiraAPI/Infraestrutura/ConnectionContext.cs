using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Domain.Model.CompanyAggregate;
using PrimeiraAPI.Domain.Model.EmployeeAggredate;

namespace PrimeiraAPI.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
            "Server=localhost;"+
            "Port=5432;Database=csharp;" +
            "User Id=postgres;" +
            "Password=123;");
    }

}
