using Demo1.Models;

namespace Demo1.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetByid(int id);
        public void Delete(int id);
        public void insert(Course course);
        public void update(int id ,Course course);
        List<Departement> GetAllDepartment();

        public string test {  get; set; }

    }
}
