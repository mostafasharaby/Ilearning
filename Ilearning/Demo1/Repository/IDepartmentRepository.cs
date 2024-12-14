using Demo1.Models;

namespace Demo1.Repository
{
    public interface IDepartmentRepository
    {
        Guid Guid { get; set; }  // create uniqe key
        string Greet { get; }
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department d);
        void Update(int id , Department departement);
        void Delete(int id);

    }
}
