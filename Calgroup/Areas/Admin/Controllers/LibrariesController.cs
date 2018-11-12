﻿using Calgroup.Models.DAO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Calgroup.Areas.Admin.Controllers
{
    public class LibrariesController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();
        private static string pic;

        // GET: Admin/Libraries
        public async Task<ActionResult> Index()
        {
            IQueryable<Library> libraries = db.Libraries.Include(l => l.LibraryCategory);
            return View(await libraries.ToListAsync());
        }

        // GET: Admin/Libraries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: Admin/Libraries/Create
        public ActionResult Create()
        {
            ViewBag.IDCategory = new SelectList(db.LibraryCategories, "ID", "Name");
            return View();
        }

        // POST: Admin/Libraries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Image,PDF,AliasName,Status,IDCategory")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Libraries.Add(library);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategory = new SelectList(db.LibraryCategories, "ID", "Name", library.IDCategory);
            return View(library);
        }

        // GET: Admin/Libraries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new SelectList(db.LibraryCategories, "ID", "Name", library.IDCategory);
            return View(library);
        }

        // POST: Admin/Libraries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Image,PDF,AliasName,Status,IDCategory")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategory = new SelectList(db.LibraryCategories, "ID", "Name", library.IDCategory);
            return View(library);
        }

        // GET: Admin/Libraries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Admin/Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Library library = await db.Libraries.FindAsync(id);
            db.Libraries.Remove(library);
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
            bool result = new ChangesDAO().LibrariesStatus(id);
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
            Library user = db.Libraries.Find(id);
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
