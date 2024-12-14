using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Departement
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Manager { get; set; }
        [Required]
        public List<Traniee>? traniees { get; set; }= new List<Traniee>();
        [Required]
        public List<Course>? Course { get; set; } = new List<Course>();
        [Required]
        public List<Instractor>? Instractor { get; set; } = new List<Instractor>();


    }
    public class Instractor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(10,100000)]
        public int? Salary { get; set; }
        [ForeignKey("Departement")]
        public int Dep_id { get; set; }
        [ForeignKey("Course")]
        public int crs_id { get; set; }
    }
    public class Traniee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public int? Degree { get; set; }
        [ForeignKey("Departement")]
        public int Dep_id { get; set; }
        public int? Grade { get; set; }
        public List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();

       
    }

    public class Course
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "this Felid is required")]
        //  [MinLength(3)]
        //[RegularExpression(@"[a-z]",ErrorMessage ="this Felid is required")]
      //  [UniqueName]
        public string? Name { get; set; }
        [Range(5,1000)]
        [Required]
        public int? Degree { get; set; }
        //  [Remote("CheckMindegree", "Course",ErrorMessage ="Min cant be  <=0")]
        [Remote(action:"CheckMindegree", controller:"Course", AdditionalFields = "Degree", ErrorMessage = "Min cant be  > Degree")]
        public int? Mindegree { get; set; }
        [ForeignKey("Departement")]
        public int Dep_id { get; set; }
        public List<Instractor>? Instractor { get; set; } = new List<Instractor>();
        public List<CrsResult>? CrsResult { get; set; } = new List<CrsResult>();


    }
    //public class CrsResult
    //{
    //    public int Id { get; set; }
    //    public int? Degree { get; set; }
    //    [ForeignKey("Traniee")]
    //    public int? Traniee_id { get; set; }


    //    [ForeignKey("Course")]
    //    public int? crs_id { get; set; }

    //}
    public class CrsResult
    {
        public int Id { get; set; }
        public int? Degree { get; set; }

        [ForeignKey("Trainee")]
        public int? Traniee_id { get; set; }
        public Traniee Trainee { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public Course Course { get; set; }
    }


    public class StudentDbContext : IdentityDbContext<StudentUser>
    {
        public StudentDbContext():base()
        {
            
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> dbContextOptions):base(dbContextOptions) 
        {
            
        }
        public DbSet<Departement> Departes { get; set; }
        public DbSet<Instractor> Instractors { get; set; }  
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Traniee> Traniees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = . ; Database =  MVCstudent ;Integrated Security =true ; TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
