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
    public class ReceitaController : Controller
    {
        private ReceitaContext db = new ReceitaContext();

        // GET: Receita
        public ActionResult Index()
        {
            var receitas = db.Receitas.Include(r => r.Categoria).Include(r => r.GrauDificuldade);
            return View(receitas.ToList());
        }

        // GET: Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome");
            ViewBag.GrauDificuldadeID = new SelectList(db.GrauDificuldades, "GrauDificuldadeID", "GrauDificuldadeNome");
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceitaID,CategoriaID,GrauDificuldadeID,ReceitaNome,ReceitaDescricao,ReceitaDuracao")] Receita receita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Receitas.Add(receita);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.GrauDificuldadeID = new SelectList(db.GrauDificuldades, "GrauDificuldadeID", "GrauDificuldadeNome", receita.GrauDificuldadeID);
            return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.GrauDificuldadeID = new SelectList(db.GrauDificuldades, "GrauDificuldadeID", "GrauDificuldadeNome", receita.GrauDificuldadeID);
            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceitaID,CategoriaID,GrauDificuldadeID,ReceitaNome,ReceitaDescricao,ReceitaDuracao")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(receita).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.GrauDificuldadeID = new SelectList(db.GrauDificuldades, "GrauDificuldadeID", "GrauDificuldadeNome", receita.GrauDificuldadeID);
            return View(receita);
        }

        // GET: Receita/Delete/5
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
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Receita receita = db.Receitas.Find(id);
                db.Receitas.Remove(receita);
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
