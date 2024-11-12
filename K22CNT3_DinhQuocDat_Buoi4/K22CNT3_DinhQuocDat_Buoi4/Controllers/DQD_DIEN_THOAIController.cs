using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_DinhQuocDat_Buoi4.Models;

namespace K22CNT3_DinhQuocDat_Buoi4.Controllers
{
    public class DQD_DIEN_THOAIController : Controller
    {
        private DQDDbEntities db = new DQDDbEntities();

        // GET: DIEN_THOAI
        public ActionResult Index()
        {
            var dIEN_THOAI = db.DIEN_THOAI.Include(d => d.LOAI_DIEN_THOAI);
            return View(dIEN_THOAI.ToList());
        }

        // GET: DIEN_THOAI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEN_THOAI dIEN_THOAI = db.DIEN_THOAI.Find(id);
            if (dIEN_THOAI == null)
            {
                return HttpNotFound();
            }
            return View(dIEN_THOAI);
        }

        // GET: DIEN_THOAI/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LOAI_DIEN_THOAI, "ID", "MaLoaiDienThoai");
            return View();
        }

        // POST: DIEN_THOAI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaDienThoai,TenDienThoai,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] DIEN_THOAI dIEN_THOAI)
        {
            if (ModelState.IsValid)
            {
                db.DIEN_THOAI.Add(dIEN_THOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LOAI_DIEN_THOAI, "ID", "MaLoaiDienThoai", dIEN_THOAI.MaLoai);
            return View(dIEN_THOAI);
        }

        // GET: DIEN_THOAI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEN_THOAI dIEN_THOAI = db.DIEN_THOAI.Find(id);
            if (dIEN_THOAI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_DIEN_THOAI, "ID", "MaLoaiDienThoai", dIEN_THOAI.MaLoai);
            return View(dIEN_THOAI);
        }

        // POST: DIEN_THOAI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaDienThoai,TenDienThoai,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] DIEN_THOAI dIEN_THOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIEN_THOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_DIEN_THOAI, "ID", "MaLoaiDienThoai", dIEN_THOAI.MaLoai);
            return View(dIEN_THOAI);
        }

        // GET: DIEN_THOAI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEN_THOAI dIEN_THOAI = db.DIEN_THOAI.Find(id);
            if (dIEN_THOAI == null)
            {
                return HttpNotFound();
            }
            return View(dIEN_THOAI);
        }

        // POST: DIEN_THOAI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIEN_THOAI dIEN_THOAI = db.DIEN_THOAI.Find(id);
            db.DIEN_THOAI.Remove(dIEN_THOAI);
            db.SaveChanges();
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
