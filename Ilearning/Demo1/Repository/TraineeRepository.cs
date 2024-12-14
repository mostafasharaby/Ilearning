using Demo1.Models;

namespace Demo1.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        StudentDbContext context;    
        public TraineeRepository(StudentDbContext context)
        {
            this.context = context;
        }  

        public void Delete(int id)
        {
            var del = context.Traniees.FirstOrDefault(c => c.Id == id);
            if (del != null)
            {
                context.Traniees.Remove(del);
                context.SaveChanges();
            }
        }

        public List<Traniee> GetAll()
        {
            var all = context.Traniees.ToList();
            return all;
        }

        public List<Departement> GetAllDepartment()
        {
            var v = context.Departes.ToList();
            return v;
        }
        public Traniee GetByid(int id)
        {
            var get = context.Traniees.FirstOrDefault(c => c.Id == id);
            if (get == null)
            {
                throw new Exception($"No Trainee found with Id = {id}");
            }
            return get;
        }

        public void insert(Traniee Traniee)
        {
            if (Traniee != null)
            {
                context.Traniees.Add(Traniee);
                context.SaveChanges();
            }
        }
        public void update(int id, Traniee Traniee)
        {
            var update = context.Traniees.FirstOrDefault(c => c.Id == id);
            if (update != null)
            {
                update.Name = Traniee.Name;
                update.Dep_id = Traniee.Dep_id;
                update.Degree = Traniee.Degree;
                update.Address = Traniee.Address;
                //update.Image = Traniee.Image;  this make ovveride 
                update.Grade = Traniee.Grade;
                context.SaveChanges();
            }
        }
    }
}
