using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoghlanaTech.Models;

namespace ShoghlanaTech.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // GET: Companies/index
        public ActionResult Index()
        {
            if (Session["CompanyID"] == null)
            {

                return RedirectToAction("Login");
            }
            else
            {
                var company = db.Companies.Find(Session["CompanyID"]);
                return View(company);
            }
        }

        // GET: /Companies/CreateJob
        public ActionResult CreateJob()
        {
            if (Session["CompanyID"] == null)
            {

                return RedirectToAction("Login");
            }
            else { 
                ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
        }

        // POST: /Companies/CreateJob
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJob(Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                // get company image ..
                var company = db.Companies.Find(Session["CompanyID"]);

                // save image for job
                jobs.Image = company.Image;
                // save company ID for job ..
                jobs.CompanyID = (int?)Session["CompanyID"];
                // save publish date ..
                jobs.PublishDate = DateTime.Now;
                // save in DB
                db.Jobs.Add(jobs);
                db.SaveChanges();
                return RedirectToAction("Jobs");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", jobs.CategoryID);
            return View(jobs);
        }

        // GET: Companies/Jobs => display all jobs of Company
        public ActionResult Jobs()
        {
            if (Session["CompanyID"] != null)
            {
                var jobs = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE CompanyID = " + Session["CompanyID"])
                    .ToList();

                return View(jobs);
            }
            else {
                return RedirectToAction("Login");
            }
        }

        // Get: /Companies/JobDetails/4
        public ActionResult JobDetails(int? id) 
        {
            
            if (id != null && Session["CompanyID"] != null)
            {
                // check job ID
                var job = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE ID = " + id + " AND CompanyID = " + Session["CompanyID"])
                    .FirstOrDefault();

                if(job == null)
                {
                    return HttpNotFound();
                }
                else {
                    // get category name ..
                    var cateory = db.Categories
                        .SqlQuery("SELECT * FROM Categories WHERE Id = " + job.CategoryID)
                        .FirstOrDefault();
                    ViewBag.CatName = cateory.Name;
                    return View(job);
                }

            }
            else { return HttpNotFound(); }
        }


        // GET: Jobs/Edit/5
        public ActionResult EditJob(int? id)
        {
            // check ID
            if (id != null && Session["CompanyID"] != null)
            {
                var job = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE ID = " + id + " AND CompanyID = " + Session["CompanyID"])
                    .FirstOrDefault();

                if (job == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", job.CategoryID);
                    return View(job);
                }
            }
            else {
                return HttpNotFound();
            }
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJob(Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                // keep CompanyID & image 
                db.Jobs.Attach(jobs);
                db.Entry(jobs).Property(j => j.CompanyID).IsModified = false;
                db.Entry(jobs).Property(j => j.Image).IsModified = false;
                db.Entry(jobs).Property(j => j.PublishDate).IsModified = false;
                // update rest ..
                db.Entry(jobs).Property(j => j.Title).IsModified = true;
                db.Entry(jobs).Property(j => j.Description).IsModified = true;
                db.Entry(jobs).Property(j => j.Type).IsModified = true;
                db.Entry(jobs).Property(j => j.Salary).IsModified = true;
                db.Entry(jobs).Property(j => j.YearsOfExp).IsModified = true;
                db.Entry(jobs).Property(j => j.CategoryID).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Jobs");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", jobs.CategoryID);
            return View(jobs);
        }

        // GET: Companies/DeleteJob/5
        public ActionResult DeleteJob(int? id)
        {
            // check ID
            if (id != null && Session["CompanyID"] != null)
            {
                var job = db.Jobs
                    .SqlQuery("SELECT * FROM Jobs WHERE ID = " + id + " AND CompanyID = " + Session["CompanyID"])
                    .FirstOrDefault();

                if (job == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    // get category name ..
                    var cateory = db.Categories
                        .SqlQuery("SELECT * FROM Categories WHERE Id = " + job.CategoryID)
                        .FirstOrDefault();
                    ViewBag.CatName = cateory.Name;
                    return View(job);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Companies/DeleteJob/5
        [HttpPost, ActionName("DeleteJob")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Jobs jobs = db.Jobs.Find(id);
            db.Jobs.Remove(jobs);
            db.SaveChanges();
            return RedirectToAction("Jobs");
        }

        
        // -------- Company Actions  ------- //
        
        // GET: Companies/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                // save image in folder ..
                var path = Path.Combine(Server.MapPath("~/Uploads"), Image.FileName);
                Image.SaveAs(path);
                
                // save data in DB
                company.Image = Image.FileName;
                db.Companies.Add(company);
                db.SaveChanges();
                // save Company ID in session ..
                Session["CompanyID"] = company.CompanyID;
                Session["CompanyEmail"] = company.Email;
                return RedirectToAction("Index");
            }

            return View(company);
        }


        // GET: Companies/Edit
        public ActionResult Edit()
        {
            var id = (int?)Session["CompanyID"];
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }


        // POST: Companies/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {   
                db.Entry(company).State = EntityState.Modified;

                bool saveFailed;
                do
                {
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);
            }
            return View(company);
        }

        // GET: /Companies/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Companies/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Company company)
        {
            // check email & password ..
            var registeredCompany = db.Companies
                .Where(c => c.Email.Equals(company.Email) && c.Password.Equals(company.Password))
                .FirstOrDefault();

            if (registeredCompany != null)
            {
                // save in Session 
                Session["CompanyID"] = registeredCompany.CompanyID;
                Session["CompanyEmail"] = company.Email;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorLogin = "Error Email or Password";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            // clear session
            Session.Contents.Clear();
            return RedirectToAction("Login");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
