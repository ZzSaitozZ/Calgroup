using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Calgroup.Areas.Admin.Controllers
{
    public class DoiTacsController : Controller
    {
        private  Calgroup_v2DB db = new  Calgroup_v2DB();

        // GET: Admin/DoiTacs
        public async Task<ActionResult> Index()
        {
            return View(await db.DoiTacs.ToListAsync());
        }

        // GET: Admin/DoiTacs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             DoiTac doiTac = await db.DoiTacs.FindAsync(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // GET: Admin/DoiTacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DoiTacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Image")]  DoiTac doiTac)
        {
            if (ModelState.IsValid)
            {
                db.DoiTacs.Add(doiTac);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(doiTac);
        }

        // GET: Admin/DoiTacs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             DoiTac doiTac = await db.DoiTacs.FindAsync(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: Admin/DoiTacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Image")]  DoiTac doiTac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTac).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(doiTac);
        }

        // GET: Admin/DoiTacs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             DoiTac doiTac = await db.DoiTacs.FindAsync(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: Admin/DoiTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
             DoiTac doiTac = await db.DoiTacs.FindAsync(id);
            db.DoiTacs.Remove(doiTac);
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
