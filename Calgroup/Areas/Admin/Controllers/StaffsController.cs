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
    public class StaffsController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        // GET: Admin/FAQ
        public async Task<ActionResult> Index()
        {
            return View(await db.Staffs.ToListAsync());
        }

        // GET: Admin/FAQ/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff faq = await db.Staffs.FindAsync(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // GET: Admin/FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Calibrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Role,Skype,Zalo,Phone,Image,Status,Email")] Staff NV)
        {
            //FAQ.Details = HttpUtility.HtmlDecode(FAQ.Details);
            if (ModelState.IsValid)
            {
                db.Staffs.Add(NV);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(NV);
        }


        // GET: Admin/Calibrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff NV = await db.Staffs.FindAsync(id);
            if (NV == null)
            {
                return HttpNotFound();
            }
            return View(NV);
        }

        // POST: Admin/Calibrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Role,Skype,Zalo,Phone,Image,Status,Email")] Staff NV)
        {
            //faq.Details = HttpUtility.HtmlDecode(faq.Details);
            if (ModelState.IsValid)
            {
                db.Entry(NV).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(NV);
        }

        // GET: Admin/Calibrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff faq = await db.Staffs.FindAsync(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // POST: Admin/Calibrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Staff faq = await db.Staffs.FindAsync(id);
            db.Staffs.Remove(faq);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
