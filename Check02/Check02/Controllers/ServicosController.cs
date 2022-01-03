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
    public class ServicosController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Servicos
        public ActionResult Index()
        {
            return View(db.ctServicos.ToList());
        }

        // GET: Servicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdServicos mdServicos = db.ctServicos.Find(id);
            if (mdServicos == null)
            {
                return HttpNotFound();
            }
            return View(mdServicos);
        }

        // GET: Servicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdServico,DescricaoProduto,Preco,Tipo")] MdServicos mdServicos)
        {
            if (ModelState.IsValid)
            {
                db.ctServicos.Add(mdServicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdServicos);
        }

        // GET: Servicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdServicos mdServicos = db.ctServicos.Find(id);
            if (mdServicos == null)
            {
                return HttpNotFound();
            }
            return View(mdServicos);
        }

        // POST: Servicos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdServico,DescricaoProduto,Preco,Tipo")] MdServicos mdServicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdServicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdServicos);
        }

        // GET: Servicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdServicos mdServicos = db.ctServicos.Find(id);
            if (mdServicos == null)
            {
                return HttpNotFound();
            }
            return View(mdServicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdServicos mdServicos = db.ctServicos.Find(id);
            db.ctServicos.Remove(mdServicos);
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
