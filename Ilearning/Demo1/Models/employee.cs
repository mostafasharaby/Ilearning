using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo1.Models
{
  
    public class Employee 
    {
        public int ID { get; set; }
        //[Display( Name = "Employee Name")]
        //  [Column("Employee Name")]
        // [DataType(DataType.EmailAddress)]
        [MinLength(3)]
        [Required]
       // [UniqueName]
        public string? Name { get; set; }
      
       // [Range(10,200000)]
        [Remote(action:"CheckSalary",controller: "Employee" ,ErrorMessage ="Salary must be above 10")]
        [Required]
        public int Salary { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }
        //[Required] 

        [ForeignKey("Department")]
        public int? DepartmentID  { get; set; }

        public virtual Department? Department { get; set; }
    }
    public class Department 
    {
        public int DepartmentID { get; set; }
        [MinLength(2)]
    
        public string? Name { get; set; }
     
        public string? Description { get; set; }

        public string? location { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; } = new HashSet<Employee>();
    }
    public class MVCDbContext:IdentityDbContext<AppUser>
    {
        public MVCDbContext():base()
        {
            
        }
        public MVCDbContext(DbContextOptions <MVCDbContext> dbContextOptions) :base(dbContextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set;}

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {    
            optionsBuilder.UseSqlServer("Data Source = . ; Database =  MVCDbContext ;Integrated Security =true ; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
