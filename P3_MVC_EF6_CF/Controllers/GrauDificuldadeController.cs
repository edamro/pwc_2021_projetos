using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P3_MVC_EF6_CF.DAL;
using P3_MVC_EF6_CF.Models;

namespace P3_MVC_EF6_CF.Controllers
{
    public class GrauDificuldadeController : Controller
    {
        private ReceitaContext db = new ReceitaContext();

        // GET: GrauDificuldade
        public ActionResult Index()
        {
            return View(db.GrauDificuldades.ToList());
        }

        // GET: GrauDificuldade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrauDificuldade grauDificuldade = db.GrauDificuldades.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrauDificuldade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrauDificuldadeID,GrauDificuldadeNome")] GrauDificuldade grauDificuldade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.GrauDificuldades.Add(grauDificuldade);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrauDificuldade grauDificuldade = db.GrauDificuldades.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // POST: GrauDificuldade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrauDificuldadeID,GrauDificuldadeNome")] GrauDificuldade grauDificuldade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(grauDificuldade).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            GrauDificuldade grauDificuldade = db.GrauDificuldades.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // POST: GrauDificuldade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GrauDificuldade grauDificuldade = db.GrauDificuldades.Find(id);
                db.GrauDificuldades.Remove(grauDificuldade);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
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
