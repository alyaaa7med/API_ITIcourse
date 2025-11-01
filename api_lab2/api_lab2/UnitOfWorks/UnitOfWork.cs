using api_lab2.DTOs;
using api_lab2.Models;
using api_lab2.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_lab2.UnitOfWorks
{
    public class UnitOfWork : Controller
    {
        //only one application db for all repos 

         GenericRepo<Student>? srepo; //private to control it using prop
         GenericRepo<Department>? drepo; //private to control it using prop 
        public applicationDBcontext db;
        public UnitOfWork( applicationDBcontext db)
        {
            this.db = db;
            /* need to be contorlled not created once calling constructor */
            //srepo = new GenericRepo<Student>(db);
            //drepo = new GenericRepo<Department>(db);
        }

        public GenericRepo<Student> Srepo 
        { get
            { if (srepo == null) //singletone : one db has only one srepo
                {
                    srepo = new GenericRepo<Student>(db);
                }
                return srepo;
            }
        }
        public GenericRepo<Department> Drepo
        {
            get
            {
                if (drepo == null) //singletone : one db has only one drepo
                {
                    drepo = new GenericRepo<Department>(db);
                }
                return drepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
