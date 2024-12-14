using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repository
{
    public class CourseRepository : ICourseRepository
    {
         StudentDbContext context  ;//= new StudentDbContext();        
        public CourseRepository(StudentDbContext context  )
        {
            this.context = context;
        }
        public string test { get ; set ; }

        public void Delete(int id)
        {
           var del = context.Courses.FirstOrDefault(c => c.Id == id);
            if(del != null)
            {
                context.Courses.Remove(del);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            var all = context.Courses.ToList(); 
            return all;
        }

        public List<Departement> GetAllDepartment()
        {
            var v =  context.Departes.ToList();
            return v;
        }
        public Course GetByid(int id)
        {
            var get = context.Courses.FirstOrDefault(c => c.Id == id);
            return get;
        }

        public void insert(Course course)
        {
            if (course != null)
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }            
        }

        public void update(int id, Course course)
        {
            var update = context.Courses.FirstOrDefault(c => c.Id == id);
            if (update != null)
            {
                update.Name = course.Name;
                update.Dep_id = course.Dep_id;
                update.Degree = course.Degree;
                update.Mindegree = course.Mindegree;                
                context.SaveChanges();
            }
        }

        
    }
}
