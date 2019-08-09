using MVCProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCProject1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> EmpList;
            HttpResponseMessage Response = GlobalVariables.WebAPIClient.GetAsync("Employees").Result;
            EmpList = Response.Content.ReadAsAsync <IEnumerable<EmployeeModel>>().Result;
            return View(EmpList);
        }
        public ActionResult CreateOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new EmployeeModel());
            }
            else
            {
                HttpResponseMessage Response = GlobalVariables.WebAPIClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(Response.Content.ReadAsAsync<EmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult CreateOrEdit(EmployeeModel emp)
        {
            if (emp.EID == 0)
            {
                HttpResponseMessage Response = GlobalVariables.WebAPIClient.PostAsJsonAsync("Employees", emp).Result;
                
            }
            else
            {
                HttpResponseMessage Response = GlobalVariables.WebAPIClient.PutAsJsonAsync("Employees/"+emp.EID, emp).Result;
                

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage Response = GlobalVariables.WebAPIClient.DeleteAsync("Employees/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}