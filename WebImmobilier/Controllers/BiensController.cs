using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebImmobilier.Models;

namespace WebImmobilier.Controllers
{
    public class BiensController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        // GET: Biens
        public ActionResult Index()
        {
            var biens = db.biens.Include(b => b.Proprietaire);
            return View(biens.ToList());
        }

        // GET: Biens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // GET: Biens/Create
        

        // POST: Biens/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,Localite,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.biens.Add(bien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", bien.IdProprio);
            return View(bien);
        }

        // GET: Biens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", bien.IdProprio);
            return View(bien);
        }

        // POST: Biens/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,Localite,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", bien.IdProprio);
            return View(bien);
        }

        // GET: Biens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bien bien = db.biens.Find(id);
            db.biens.Remove(bien);
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
