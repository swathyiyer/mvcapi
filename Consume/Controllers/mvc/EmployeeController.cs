using Consume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Consume.Controllers.mvc
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<employeedetail> emp = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53076/api/");
                //HTTP GET
                var responseTask = client.GetAsync("CRUD");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<employeedetail>>();
                    readTask.Wait();

                    emp = readTask.Result;
                }
                //else //web api sent error response 
                //{
                //    //log response status here..

                //    emp = Enumerable.Empty<employeedetail>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }
            return View(emp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(employeedetail emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53076/api/");
                var responseTask = client.PostAsJsonAsync("CRUD", emp);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
                return View(emp);
        }

        public ActionResult GetById(int id)
        {
            string i = id.ToString();
            employeedetail emp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress= new Uri("http://localhost:53076/api/");
                var response = client.GetAsync("CRUD?id=" + i);
                
                response.Wait();


                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<employeedetail>();
                    readTask.Wait();

                    emp = readTask.Result;
                }
            }
            return View(emp);
        }



    }
}
