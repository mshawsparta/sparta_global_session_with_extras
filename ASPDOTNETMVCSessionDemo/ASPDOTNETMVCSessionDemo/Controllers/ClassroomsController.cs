using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPDOTNETMVCSessionDemo.Models;

namespace ASPDOTNETMVCSessionDemo.Controllers
{
    public class ClassroomsController : Controller
    {
        private MatSchoolDBEntities db = new MatSchoolDBEntities();

        // GET: Classrooms
        public async Task<ActionResult> Index()
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(await db.Classrooms.ToListAsync());
        }

        // GET: Classrooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = await db.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: Classrooms/Create
        public ActionResult Create()
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: Classrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "className,capcity,classLocation,ClassroomID")] Classroom classroom)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Classrooms.Add(classroom);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(classroom);
        }

        // GET: Classrooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = await db.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "className,capcity,classLocation,ClassroomID")] Classroom classroom)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(classroom).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(classroom);
        }

        // GET: Classrooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = await db.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            Classroom classroom = await db.Classrooms.FindAsync(id);
            db.Classrooms.Remove(classroom);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
