using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Calgroup.Areas.Admin.Controllers
{
    public class ContactDetailsController : Controller
    {
        private ProductsdbContext db = new ProductsdbContext();

        // GET: Admin/ContactDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactDetails.ToListAsync());
        }

        // GET: Admin/ContactDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // GET: Admin/ContactDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Phone,Email,Website,Address,Other,Lat,Lng,Status")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                db.ContactDetails.Add(contactDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactDetail);
        }

        // GET: Admin/ContactDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: Admin/ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Phone,Email,Website,Address,Other,Lat,Lng,Status")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactDetail);
        }

        // GET: Admin/ContactDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: Admin/ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            db.ContactDetails.Remove(contactDetail);
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
