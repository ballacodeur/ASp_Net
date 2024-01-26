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
    public class AppartementsController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        // GET: Appartements
        public ActionResult Index()
        {
            var biens = db.biens.Include(a => a.Proprietaire);
            return View(biens.ToList());
        }

        // GET: Appartements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = (Appartement)db.biens.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // GET: Appartements/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser");
            return View();
        }

        // POST: Appartements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,Localite,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbreSalle")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.biens.Add(appartement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", appartement.IdProprio);
            return View(appartement);
        }

        // GET: Appartements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = (Appartement)db.biens.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", appartement.IdProprio);
            return View(appartement);
        }

        // POST: Appartements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,Localite,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbreSalle")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.utilisateurs, "IdUser", "NomUser", appartement.IdProprio);
            return View(appartement);
        }

        // GET: Appartements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = (Appartement)db.biens.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // POST: Appartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appartement appartement = (Appartement)db.biens.Find(id);
            db.biens.Remove(appartement);
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
