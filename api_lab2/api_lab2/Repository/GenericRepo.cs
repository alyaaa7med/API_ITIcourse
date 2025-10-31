using api_lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OpenApi.Models;
using api_lab2.Repository;
using System.Linq.Expressions;

namespace api_lab2.Repository
{
    public class GenericRepo<Tentity> where Tentity : class, IentityId
    {
        applicationDBcontext db;
        public GenericRepo(applicationDBcontext db)
        {
            this.db = db;

        }
        //student    need : db.student.Include(s => s.department).Include(s => s.instructor).AsQueryable();
        //department need : db.department.Include(d => d.students).AsQueryable();
        /* i need both in single one getall () so i need to pass the include as params of func delegate each one takes class type
           and returns object */

        /*
       
        params Func<Tentity, object>[ ] includes
        query = query.Include(include);  // ❌ won't compile if include is Func<>
        must add Expression< > so that efcore works 
        
         */
        public IQueryable<Tentity> getall(params Expression<Func<Tentity, object>>[] includes)
        {
            //IQueryable<Tentity> query; compile error need to be initialized before using it query.Include
            //var ✅ — but only if you initialize the variable in the same line.
            var  query = db.Set<Tentity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public Tentity getbyid(int id)
        {
           var entity =  db.Set<Tentity>().Find(id);
            return entity;
            
        }


        public void Add(Tentity t)
        {

            //var maxId = db.student.Max(s => (int?)s.St_Id) ?? 0;
            var maxId = db.Set<Tentity>().Max(t=>(int?)t.Id)??0;
            t.Id = maxId + 1;

            db.Set<Tentity>().Add(t);
        }

        public void Update(Tentity t)
        {
            db.Set<Tentity>().Update(t);
        }

        public void delete(Tentity t)
        {
            db.Set<Tentity>().Remove(t);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
