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
    public class LoaiSanPhamsController : Controller
    {
        private ProductsdbContext db = new ProductsdbContext();

        // GET: Admin/LoaiSanPhams
        public async Task<ActionResult> Index()
        {
            var loaiSanPhams = db.LoaiSanPhams.Include(l => l.Linhvuc);
            return View(await loaiSanPhams.ToListAsync());
        }

        // GET: Admin/LoaiSanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.LinhvucID = new SelectList(db.Linhvucs, "LinhvucID", "Linhvuc1");
            return View();
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CatID,LinhvucID,Category,AliasCat")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSanPhams.Add(loaiSanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LinhvucID = new SelectList(db.Linhvucs, "LinhvucID", "Linhvuc1", loaiSanPham.LinhvucID);
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.LinhvucID = new SelectList(db.Linhvucs, "LinhvucID", "Linhvuc1", loaiSanPham.LinhvucID);
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CatID,LinhvucID,Category,AliasCat")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LinhvucID = new SelectList(db.Linhvucs, "LinhvucID", "Linhvuc1", loaiSanPham.LinhvucID);
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            db.LoaiSanPhams.Remove(loaiSanPham);
            
            try
            {
                //code
                await db.SaveChangesAsync();
            }
            catch (Exception Exception)
            {
                //code
                TempData["message"] = "Không thể xóa loại sản phẩm đã có sản phẩm";
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
