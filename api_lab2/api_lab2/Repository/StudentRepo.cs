using api_lab2.DTOs;
using api_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace api_lab2.Repository
{
    public class StudentRepo
    {
     /*   applicationDBcontext db;
        public StudentRepo(applicationDBcontext db)
        {
            this.db = db;
            
        }
        public IQueryable<Student> getall()
        {

            var query = db.student
                          .Include(s => s.department)
                          .Include(s => s.instructor)
                          .AsQueryable();

            return query;
        }

        public Student getbyid(int id)
        {
            return db.student.Where(s => s.St_Id == id).FirstOrDefault();

        }

        public void Add(Student s)
        {
            var maxId = db.student.Max(s => (int?)s.St_Id) ?? 0;
            s.St_Id = maxId + 1;
            db.student.Add(s);
        }

        public void Update(Student std)
        {
            db.Update(std);
        }

        public void delete(Student std)
        {
            db.student.Remove(std);
        }

        public void Save()
        {
            db.SaveChanges();
        }
     */
    }
}
