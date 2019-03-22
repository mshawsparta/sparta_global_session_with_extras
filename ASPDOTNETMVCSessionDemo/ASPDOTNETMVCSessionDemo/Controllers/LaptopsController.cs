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
    public class LaptopsController : Controller
    {
        private MatSchoolDBEntities db = new MatSchoolDBEntities();

        // GET: Laptops
        public async Task<ActionResult> Index()
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(await db.Laptops.ToListAsync());
        }

        // GET: Laptops/Details/5
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
            Laptop laptop = await db.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: Laptops/Create
        public ActionResult Create()
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,color,make,purchaseDate")] Laptop laptop)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Laptops.Add(laptop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(laptop);
        }

        // GET: Laptops/Edit/5
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
            Laptop laptop = await db.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,color,make,purchaseDate")] Laptop laptop)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(laptop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(laptop);
        }

        // GET: Laptops/Delete/5
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
            Laptop laptop = await db.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (@Session["firstName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            Laptop laptop = await db.Laptops.FindAsync(id);
            db.Laptops.Remove(laptop);
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
