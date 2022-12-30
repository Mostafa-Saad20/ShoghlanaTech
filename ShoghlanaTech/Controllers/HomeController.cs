using ShoghlanaTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShoghlanaTech.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // get all categories ..
            return View(db.Categories.ToList());
        }

        // Get: /Category/[ID]
        public ActionResult Category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                // find jobs by category id ..
                var jobs = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE CategoryID = " + id)
                    .ToList();

                if (jobs == null)
                {
                    return View("Error");
                }
                else 
                {
                    // display category name by its ID
                    var catName = db.Categories.Find(id);
                    if(catName != null)
                        ViewData["catName"] = catName.Name;
                    // pass jobs
                    return View(jobs);
                }
            }
        }

        // Get: /JobDetails/[Id]
        public ActionResult JobDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {

                var job = db.Jobs.Find(id);
                if (job == null)
                {
                    return View("Error");
                }
                else {
                    var company = db.Companies
                        .SqlQuery("SELECT * FROM Companies WHERE CompanyID = " + job.CompanyID)
                        .FirstOrDefault();
                    
                    ViewBag.Company = company;
                    return View(job);
                }
            
            }
        }

        // Get: /CompanyDetails/[Id]
        public ActionResult CompanyDetails(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else
            {
                // get company ..
                var comp = db.Companies.Find(id);

                if (comp != null)
                {
                    // get all Jobs of company ..
                    var jobs = db.Jobs
                        .SqlQuery("SELECT * FROM Jobs WHERE CompanyID = " + id)
                        .ToList();
                    ViewBag.Jobs = jobs;
                    return View(comp);
                }
                else
                    return View("Error");
            }
        }

        // GET: /Search?title=[..]
        public ActionResult Search(string title)
        {

            if (title == null || title == "")
            {
                return View("Error");
            }
            else
            {
                var jobs = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE Title LIKE '%" + title + "%' ")
                    .ToList();
                    
                return View(jobs);
            }

        }

        // GET: /Filter/Type=[..]&Salary=[..]
        public ActionResult Filter(string type, string salary)
        {

            if (type == null && salary == null)
            {
                return View("Error");
            }
            else
            {
                List<Jobs> jobs = new List<Jobs>();
                if (type != null || type != "")
                {
                    jobs = db.Jobs
                        .SqlQuery("SELECT * FROM Jobs WHERE Type = '" + type + "'")
                        .ToList();
                }
                else if (salary != null || salary != "")
                {
                    jobs = db.Jobs
                        .SqlQuery("SELECT * FROM Jobs WHERE Salary = '" + salary + "'")
                        .ToList();

                }
                return View(jobs);

            }

        }

        // GET: /BrowseJobs/type=[..]&years=[..]
        public ActionResult BrowseJobs(string type, string years)
        {
            
            if (type != null && type != "" )
            {
                var jobs = db.Jobs
                    .Where(j => j.Type == type )
                    .ToList();
                return View(jobs);
            }
            else if (years != null && years != "")
            {
                var jobs = db.Jobs
                    .Where(j => j.YearsOfExp == years)
                    .ToList();
                return View(jobs);
            }
            else
            {
                var jobs = db.Jobs.ToList();
                return View(jobs);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}