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
    public class Cao_DonoController : Controller
    {
        private Context.Context db = new Context.Context();

        private MdCao_Dono cao_dono = new MdCao_Dono();
        private MdCao cao = new MdCao();
        private MdDono dono = new MdDono();
        private MdRaca raca = new MdRaca();

        // GET: Cao_Dono
        public ActionResult Index(int? ItemSelecionado)
        {

            // ########## LISTA PADRÃO DA PÁGINA ###########
            List<MdCao_Dono> Lista = db.ctCao_Dono.ToList();

            foreach  (MdCao_Dono item in Lista)
            {
                var BaseCao = db.ctCao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                var BaseDono = db.ctDonos.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                item.IdRaca = BaseCao.IdRaca;

                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                item.NmDono = BaseDono.NmDono;
                item.NmCao = BaseCao.NmCao;
                item.NmRaca = BaseRaca.NmRaca;
                 
            }


            // ########## LISTA DA RAÇA SELECIONADA ##########
            List<MdRaca> ListarRaca = db.ctRacas.ToList();
            ViewBag.ListarRaca = ListarRaca;


            if (ItemSelecionado != null)
            {
                List<MdCao_Dono> ListRaca = db.ctCao_Dono.ToList();

                ListRaca = ListRaca.Where(t => t.IdRaca == ItemSelecionado).ToList();

                foreach (MdCao_Dono item in ListRaca)
                {
                    var BaseCao = db.ctCao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                    var BaseDono = db.ctDonos.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                    item.IdRaca = BaseCao.IdRaca;

                    var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                    item.NmDono = BaseDono.NmDono;
                    item.NmCao = BaseCao.NmCao;
                    item.NmRaca = BaseRaca.NmRaca;
                }
                return View(ListRaca);
            }
            

            return View(Lista);
        }

            // GET: Cao_Dono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao_Dono mdCao_Dono = db.ctCao_Dono.Find(id);
            if (mdCao_Dono == null)
            {
                return HttpNotFound();
            }

            List<MdCao_Dono> Lista = db.ctCao_Dono.ToList();

            foreach (MdCao_Dono item in Lista)
            {
                var BaseCao = db.ctCao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                var BaseDono = db.ctDonos.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                item.IdRaca = BaseCao.IdRaca;

                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                item.NmDono = BaseDono.NmDono;
                item.NmCao = BaseCao.NmCao;
                item.NmRaca = BaseRaca.NmRaca;

            }

            return View(mdCao_Dono);
        }

        // GET: Cao_Dono/Create
        public ActionResult Create()
        {
            List<MdDono> ListDono = db.ctDonos.ToList();
            ViewBag.Donos = ListDono;

            List<MdCao> ListCao = db.ctCao.ToList();
            ViewBag.Cao = ListCao;

            return View();
        }

        // POST: Cao_Dono/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCao_Dono,IdDono,IdCao,NmCao,NmDono,NmRaca")] MdCao_Dono mdCao_Dono)
        {

            if (ModelState.IsValid)
            {
                db.ctCao_Dono.Add(mdCao_Dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdCao_Dono);
        }

        // GET: Cao_Dono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao_Dono mdCao_Dono = db.ctCao_Dono.Find(id);
            if (mdCao_Dono == null)
            {
                return HttpNotFound();
            }
            List<MdCao_Dono> Lista = db.ctCao_Dono.ToList();

            foreach (MdCao_Dono item in Lista)
            {
                var BaseCao = db.ctCao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                var BaseDono = db.ctDonos.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                item.IdRaca = BaseCao.IdRaca;

                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                item.NmDono = BaseDono.NmDono;
                item.NmCao = BaseCao.NmCao;
                item.NmRaca = BaseRaca.NmRaca;

            }

            List<MdDono> ListDono = db.ctDonos.ToList();
            ViewBag.Donos = ListDono;

            List<MdCao> ListCao = db.ctCao.ToList();
            ViewBag.Cao = ListCao;

            return View(mdCao_Dono);
        }

        // POST: Cao_Dono/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCao_Dono,IdDono,IdCao,NmCao,NmDono,NmRaca")] MdCao_Dono mdCao_Dono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdCao_Dono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdCao_Dono);
        }

        // GET: Cao_Dono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdCao_Dono mdCao_Dono = db.ctCao_Dono.Find(id);
            if (mdCao_Dono == null)
            {
                return HttpNotFound();
            }

            List<MdCao_Dono> Lista = db.ctCao_Dono.ToList();

            foreach (MdCao_Dono item in Lista)
            {
                var BaseCao = db.ctCao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                var BaseDono = db.ctDonos.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                item.IdRaca = BaseCao.IdRaca;

                var BaseRaca = db.ctRacas.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                item.NmDono = BaseDono.NmDono;
                item.NmCao = BaseCao.NmCao;
                item.NmRaca = BaseRaca.NmRaca;

            }

            return View(mdCao_Dono);
        }

        // POST: Cao_Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdCao_Dono mdCao_Dono = db.ctCao_Dono.Find(id);
            db.ctCao_Dono.Remove(mdCao_Dono);
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
