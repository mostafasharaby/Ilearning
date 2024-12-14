using Demo1.Models;

namespace Demo1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MVCDbContext context;// = new MVCDbContext();
        public DepartmentRepository(MVCDbContext dptcontext) 
        {
            context = dptcontext;
        }
        public Guid Guid { get; set; }
        public DepartmentRepository()
        {
            Guid = Guid.NewGuid();
        }

        public void Delete(int id)
        {
            var deleteDepartment = context.Departments.FirstOrDefault(e => e.DepartmentID == id);
            if (deleteDepartment != null)
            {
                context.Departments.Remove(deleteDepartment);
                context.SaveChanges();
            }
        }
        public List<Department> GetAll()
        {
            List<Department> v = context.Departments.ToList();
            return v;
        }

        public Department GetById(int id)
        {
            var getid = context.Departments.FirstOrDefault(i => i.DepartmentID == id);
            return getid;
        }

        public void Insert(Department d)
        {
            var Insert = context.Departments.Add(d);
            context.SaveChanges();
        }

        public void Update(int id, Department departement)
        {
            departement.DepartmentID = id;
            context.Departments.Update(departement);
            context.SaveChanges();
        }

        public string Greet{ get ;}        
    }    
}
