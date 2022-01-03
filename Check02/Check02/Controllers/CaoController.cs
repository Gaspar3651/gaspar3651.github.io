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
    public class CaoController : Controller
    {
        private Context.Context db = new Context.Context();
        private MdCao cao = new MdCao();

        // GET: Cao
        public ActionResult Index()
        {
            List<MdCao> ListCao = db.ctCao.ToList();

            foreach (MdCao item in ListCao)
            {
                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();
                item.NmRaca = BaseRaca.NmRaca;
            }
            return View(ListCao);
        }

        // GET: Cao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao mdCao = db.ctCao.Find(id);
            if (mdCao == null)
            {
                return HttpNotFound();
            }

            List<MdCao> ListCao = db.ctCao.ToList();

            foreach (MdCao item in ListCao)
            {
                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();
                item.NmRaca = BaseRaca.NmRaca;
            }

            return View(mdCao);
        }

        // GET: Cao/Create
        public ActionResult Create()
        {
            List<MdRaca> ListRaca = db.ctRacas.ToList();
            ViewBag.Raca = ListRaca;
            return View();
        }

        // POST: Cao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCao,NmCao,IdRaca,NmRaca")] MdCao mdCao)
        {
            if (ModelState.IsValid)
            {
              
                db.ctCao.Add(mdCao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdCao);
        }

        // GET: Cao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao mdCao = db.ctCao.Find(id);
            if (mdCao == null)
            {
                return HttpNotFound();
            }

            List<MdCao> ListCao = db.ctCao.ToList();

            foreach (MdCao item in ListCao)
            {
                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();
                item.NmRaca = BaseRaca.NmRaca;
            }

            List<MdRaca> ListRaca = db.ctRacas.ToList();
            ViewBag.Raca = ListRaca;

            return View(mdCao);
        }

        // POST: Cao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCao,NmCao,IdRaca,NascimentoCao")] MdCao mdCao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdCao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdCao);
        }

        // GET: Cao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao mdCao = db.ctCao.Find(id);
            if (mdCao == null)
            {
                return HttpNotFound();
            }

            List<MdCao> ListCao = db.ctCao.ToList();

            foreach (MdCao item in ListCao)
            {
                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();
                item.NmRaca = BaseRaca.NmRaca;
            }
            return View(mdCao);
        }

        // POST: Cao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdCao mdCao = db.ctCao.Find(id);
            db.ctCao.Remove(mdCao);
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
