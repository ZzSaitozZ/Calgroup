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
    public class FAQController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        // GET: Admin/FAQ
        public async Task<ActionResult> Index()
        {
            return View(await db.Questions.ToListAsync());
        }

        // GET: Admin/FAQ/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question faq = await db.Questions.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Title,AliasName,Details,Status")] Question FAQ)
        {
            FAQ.Details = HttpUtility.HtmlDecode(FAQ.Details);
            if (ModelState.IsValid)
            {
                db.Questions.Add(FAQ);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(FAQ);
        }


        // GET: Admin/Calibrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question faq = await db.Questions.FindAsync(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // POST: Admin/Calibrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,AliasName,Details,Status")] Question faq)
        {
            faq.Details = HttpUtility.HtmlDecode(faq.Details);
            if (ModelState.IsValid)
            {
                db.Entry(faq).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(faq);
        }

        // GET: Admin/Calibrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question faq = await db.Questions.FindAsync(id);
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
            Question faq = await db.Questions.FindAsync(id);
            db.Questions.Remove(faq);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
