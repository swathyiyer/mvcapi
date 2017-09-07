using Consume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consume.Controllers
{
    public class CRUDController : ApiController
    {[HttpGet]
       public IHttpActionResult Display()
        {
            employeeEntities db = new employeeEntities();
            var result=db.employeedetails.ToList();
            return Ok(result);
        }




        public IHttpActionResult GetById(int id)
        {
            employeeEntities db = new employeeEntities();
            var result = db.employeedetails.Find(id);
            return Ok(result);
        }


        public IHttpActionResult Create(employeedetail emp)
        {
            employeeEntities db = new employeeEntities();
            var result = db.employeedetails.Add(emp);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetEdit(int id)
        {

        }
    }
}
