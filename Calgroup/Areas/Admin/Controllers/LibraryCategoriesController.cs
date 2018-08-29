﻿using System;
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
    public class LibraryCategoriesController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        // GET: Admin/LibraryCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.LibraryCategories.ToListAsync());
        }

        // GET: Admin/LibraryCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             LibraryCategory libraryCategory = await db.LibraryCategories.FindAsync(id);
            if (libraryCategory == null)
            {
                return HttpNotFound();
            }
            return View(libraryCategory);
        }

        // GET: Admin/LibraryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LibraryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create([Bind(Include = "ID,Name")]  LibraryCategory libraryCategory)
        {
            if (ModelState.IsValid)
            {
                db.LibraryCategories.Add(libraryCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(libraryCategory);
        }

        // GET: Admin/LibraryCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             LibraryCategory libraryCategory = await db.LibraryCategories.FindAsync(id);
            if (libraryCategory == null)
            {
                return HttpNotFound();
            }
            return View(libraryCategory);
        }

        // POST: Admin/LibraryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")]  LibraryCategory libraryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(libraryCategory);
        }

        // GET: Admin/LibraryCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             LibraryCategory libraryCategory = await db.LibraryCategories.FindAsync(id);
            if (libraryCategory == null)
            {
                return HttpNotFound();
            }
            return View(libraryCategory);
        }

        // POST: Admin/LibraryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
             LibraryCategory libraryCategory = await db.LibraryCategories.FindAsync(id);
            db.LibraryCategories.Remove(libraryCategory);
            try
            {
                //code
                await db.SaveChangesAsync();
            }
            catch (Exception Exception)
            {
                //code
                TempData["message"] = "Không thể xóa Loại thư viện có thư viện ";
            }
            finally
            {
                //Close connection

            }
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
