﻿using Calgroup.Models.DAO;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Calgroup.Areas.Admin.Controllers
{
    public class LinhvucsController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        // GET: Admin/Linhvucs
        public async Task<ActionResult> Index()
        {
            return View(await db.Linhvucs.ToListAsync());
        }

        // GET: Admin/Linhvucs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhvuc linhvuc = await db.Linhvucs.FindAsync(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // GET: Admin/Linhvucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Linhvucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Linhvuc1,DisplayOrder")] Linhvuc linhvuc)
        {
            linhvuc.DisplayOrder = new ProductDao().maxDisplayOrder() + 1;
            if (ModelState.IsValid)
            {
                db.Linhvucs.Add(linhvuc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(linhvuc);
        }

        // GET: Admin/Linhvucs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhvuc linhvuc = await db.Linhvucs.FindAsync(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // POST: Admin/Linhvucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Linhvuc1,DisplayOrder")] Linhvuc linhvuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhvuc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(linhvuc);
        }

        // GET: Admin/Linhvucs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhvuc linhvuc = await db.Linhvucs.FindAsync(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // POST: Admin/Linhvucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Linhvuc linhvuc = await db.Linhvucs.FindAsync(id);
            db.Linhvucs.Remove(linhvuc);
            try
            {
                //code
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                //code
                TempData["message"] = "Không thể xóa lĩnh vực đang có loại sản phẩm";
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
