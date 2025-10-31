using api_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace api_lab2.Repository
{
    public class DepartmentRepo
    {

        /*applicationDBcontext db;
        public DepartmentRepo(applicationDBcontext db)
        {
            this.db = db;

        }
        public IQueryable<Department> getall()
        {

            var query = db.department
                         .Include(d => d.students)
                         .AsQueryable();


            return query;
        }

        public Department getbyid(int id)
        {
            return db.department.Where(d => d.Dept_Id == id).FirstOrDefault();

        }

        public void Add(Department d)
        {
            //i need to make it as ID is not identity on db 
            var maxId = db.department.Max(d => (int?)d.Dept_Id) ?? 0;
            d.Dept_Id = maxId + 1;
            db.department.Add(d);
        }

        public void Update(Department d)
        {
            db.Update(d);
        }

        public void delete(Department d)
        {
            db.department.Remove(d);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        */
    }
}
