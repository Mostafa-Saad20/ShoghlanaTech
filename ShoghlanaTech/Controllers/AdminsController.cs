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
    public class AdminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // ****************************** //
        // ****** Admin section ****** //
        // ****************************** //
        // Get: /Admins/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Admins/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            if (ModelState.IsValid) 
            {
                // check admin 
                var registeredAdmin = db.Admins
                    .Where(a => a.Email.Equals(admin.Email) && a.Password.Equals(admin.Password))
                    .FirstOrDefault();

                if (registeredAdmin != null)
                {
                    // save session 
                    Session["AdminRegister"] = true;
                    Session["AdminEmail"] = registeredAdmin.Email;
                    return RedirectToAction("Index");
                }
                else { ViewBag.AdminError = "Unauthorized Access!"; }
            
            }
            return View();
        }

        // Get: /Admins/Register
        public ActionResult AddNewAdmin()
        {
            if (Session["AdminRegister"] == null)
                return View("Login");
            else
                return View();
        }

        // POST: /Admins/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                // check if admin exists ..
                var adminEmail = db.Admins.Where(a => a.Email == admin.Email).FirstOrDefault();
                if (adminEmail != null)
                    ViewBag.AdminError = "This Admin is already exist !";
                else
                {
                    // save admin in databse ..
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    ViewBag.AdminAdded = "New Admin has been Added successfully .";
                }
            }
            return View();
        }

        // GET: /AllAdmins
        public ActionResult AllAdmins()
        {
            // check admin register 
            if (Session["AdminRegister"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var admins = db.Admins.ToList();
                return View(admins);
            }
        }

        // GET: /AllJobs
        public ActionResult AllJobs()
        {
            // check admin register 
            if (Session["AdminRegister"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var jobs = db.Jobs.Include(j => j.Category).Include(j => j.Company);
                return View(jobs.ToList());
            }
        }

        // GET: /AllCompanies
        public ActionResult AllCompanies()
        {
            // check admin register 
            if (Session["AdminRegister"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var companies = db.Companies.ToList();
                return View(companies);
            }
        }


        // GET: Admins/Index
        public ActionResult Index()
        {
            // check admin register 
            if (Session["AdminRegister"] == null)
            {
                return RedirectToAction("Login");
            }
            else {
                // get counts ..
                var compCount  = db.Companies.ToList().Count();
                var usersCount = db.Users.ToList().Count();
                var jobsCount  = db.Jobs.ToList().Count();
                int[] counts   = { compCount, usersCount, jobsCount };

                ViewBag.Counts = counts;
                return View(); 
            }
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else {
                // check admin register 
                if (Session["AdminRegister"] == null)
                    return RedirectToAction("Login");
                else { 
                    Admin admin = db.Admins.Find(id);
                    if (admin == null)
                    {
                        return HttpNotFound();
                    }
                    return View(admin);
                }
            }
        }

        // POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AllAdmins");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else
            {
                // check admin register 
                if (Session["AdminRegister"] == null)
                    return RedirectToAction("Login");
                else
                {
                    Admin admin = db.Admins.Find(id);
                    if (admin == null)
                    {
                        return HttpNotFound();
                    }
                    return View(admin);
                }
            }
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            // Don't delete current admin ..
            if (admin.Email.Equals(Session["AdminEmail"]))
            {
                ViewBag.ErrorDelete = "Can't remove this Admin !";
                return View();
            }
            else
            {
                db.Admins.Remove(admin);
                db.SaveChanges();
                return RedirectToAction("AllAdmins");
            }
        }

        // GET: /Logout
        public ActionResult Logout() 
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        // ****************************** //
        // ****** Category section ****** //
        // ****************************** //

        // GET: /AllCategories
        public ActionResult AllCategories()
        {
            if (Session["AdminRegister"] == null)
                return RedirectToAction("Login");
            else
                return View(db.Categories.ToList());
        }

        // GET: /CategoryDetails/5
        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else {
                if (Session["AdminRegister"] == null)
                    return RedirectToAction("Login");
                else { 
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
                
                }
            }
        }

        // GET: /CreateCategory
        public ActionResult CreateCategory()
        {
            if (Session["AdminRegister"] == null)
                return RedirectToAction("Login");
            else 
                return View();
        }

        // POST: /CreateCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                // upload category image ..
                var path = Path.Combine(Server.MapPath("~/Uploads"), Image.FileName);
                Image.SaveAs(path);

                // save category in DB
                category.Image = Image.FileName;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("AllCategories");
            }

            return View(category);
        }

        // GET: /EditCategory/5
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else {
                if (Session["AdminRegister"] == null)
                    return RedirectToAction("Login");
                else
                {
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
                }
            }
        }

        // POST: /EditCategory/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                bool saveFailed;
                do
                {
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("AllCategories");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);
            }
            return View(category);
        }

        // GET: /DeleteCategory/5
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            else
            {
                if (Session["AdminRegister"] == null)
                    return RedirectToAction("Login");
                else
                {
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
                }
            }
        }

        // POST: /DeleteCategory/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("AllCategories");
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
