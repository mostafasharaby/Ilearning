using Demo1.Models;

namespace Demo1.Repository
{
    public interface ITraineeRepository
    {
        List<Traniee> GetAll();
        Traniee GetByid(int id);
        public void Delete(int id);
        public void insert(Traniee Traniee);
        public void update(int id, Traniee Traniee);
        List<Departement> GetAllDepartment();

    }
}
