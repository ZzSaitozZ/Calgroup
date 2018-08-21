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
using Calgroup.Areas.Admin.Models.BusinessModel;
using Model.DAO;

namespace Calgroup.Areas.Admin.Controllers
{
    [AuthorizeBusiness]
    public class CalibrationsController : Controller
    {
        private ProductsdbContext db = new ProductsdbContext();
        private static string pic;

        // GET: Admin/Calibrations
        public async Task<ActionResult> Index()
        {
            return View(await db.Calibrations.ToListAsync());
        }

        // GET: Admin/Calibrations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calibration calibration = await db.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return HttpNotFound();
            }
            return View(calibration);
        }

        // GET: Admin/Calibrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Calibrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Detail,Status,Category")] Calibration calibration)
        {
            calibration.Detail = HttpUtility.HtmlDecode(calibration.Detail);
            if (ModelState.IsValid)
            {
                db.Calibrations.Add(calibration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(calibration);
        }

        // GET: Admin/Calibrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calibration calibration = await db.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return HttpNotFound();
            }
            return View(calibration);
        }

        // POST: Admin/Calibrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Detail,Status,Category")] Calibration calibration)
        {
            calibration.Detail = HttpUtility.HtmlDecode(calibration.Detail);
            if (ModelState.IsValid)
            {
                db.Entry(calibration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(calibration);
        }

        // GET: Admin/Calibrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calibration calibration = await db.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return HttpNotFound();
            }
            return View(calibration);
        }

        // POST: Admin/Calibrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Calibration calibration = await db.Calibrations.FindAsync(id);
            db.Calibrations.Remove(calibration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //public JsonResult Delete(int id)
        //{
        //    new PostNewsDAO().Delete(id);

        //    return Json(new { redirectUrl = Url.Action("Index", "Posts"), isRedirect = true });

        //}
        public JsonResult ChangeStatus(int id)
        {
            var result = new ChangesDAO().CalibrationsStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public string ChangeImage(int? id, string picture)
        {
            pic = picture;
            if (id == null)
            {
                return "Mã không tồn tại";
            }
            Post user = db.Posts.Find(id);
            if (user == null)
            {
                return "Mã không tồn tại";
            }
            user.Image = picture;
            db.SaveChanges();
            return "";
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
