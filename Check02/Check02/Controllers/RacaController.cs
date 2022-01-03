using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Check02.Context;
using Check02.Models;

namespace Check02.Controllers
{
    public class RacaController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Raca
        public ActionResult Index()
        {
            return View(db.ctRacas.ToList());
        }

        // GET: Raca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdRaca mdRaca = db.ctRacas.Find(id);
            if (mdRaca == null)
            {
                return HttpNotFound();
            }
            return View(mdRaca);
        }

        // GET: Raca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raca/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRaca,NmRaca")] MdRaca mdRaca)
        {
            if (ModelState.IsValid)
            {
                db.ctRacas.Add(mdRaca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdRaca);
        }

        // GET: Raca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdRaca mdRaca = db.ctRacas.Find(id);
            if (mdRaca == null)
            {
                return HttpNotFound();
            }
            return View(mdRaca);
        }

        // POST: Raca/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRaca,NmRaca")] MdRaca mdRaca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdRaca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdRaca);
        }

        // GET: Raca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdRaca mdRaca = db.ctRacas.Find(id);
            if (mdRaca == null)
            {
                return HttpNotFound();
            }
            return View(mdRaca);
        }

        // POST: Raca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdRaca mdRaca = db.ctRacas.Find(id);
            db.ctRacas.Remove(mdRaca);
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



        public void GetImagemSol()
        {
            WebImage wbImage = new WebImage("~/Views/Shared/imagens/sol.png");
            wbImage.Resize(20, 20);
            wbImage.FileName = "quati.jpg";
            wbImage.Write();
        }

        public void GetImagemLua()
        {
            WebImage wbImage = new WebImage("~/Views/Shared/imagens/lua.png");
            wbImage.Resize(20, 20);
            wbImage.FileName = "quati.jpg";
            wbImage.Write();
        }
    }
}
