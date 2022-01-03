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
    public class OfertaController : Controller
    {
        private Context.Context db = new Context.Context();
        private MdOferta oferta = new MdOferta();

        public static List<MdServicos> ProdutoSelecionado = new List<MdServicos>();
        public static List<MdOferta> ListaOferta = new List<MdOferta>();

        static decimal ValorTotal;
        static int IdDono;

        // GET: Oferta
        public ActionResult Index(int? id)
        {
            

            /*if (db.ctOferta.Find(id) == null)
            {

                Create();
            }*/


            // ########## INFORMAÇÕES DO CLIENTE ##########
            List<MdDono> InformacaoCliente = db.ctDonos.ToList();
            InformacaoCliente = InformacaoCliente.Where(t => t.IdDono == id).ToList();
            ViewBag.Geral = InformacaoCliente;
            IdDono = (int)id;


            // ########## LISTA GERAL DOS PRODUTOS ##########
            List<MdServicos> ListaDosProdutos = db.ctServicos.Where(t => t.Tipo.Equals("Produto")).ToList();
            ViewBag.Servico = ListaDosProdutos;


            // ########## LISTA DOS PRODUTOS DO CARRINHO ##########
            ViewBag.ProdutosSelecionados = ProdutoSelecionado.OrderBy(d => d.DescricaoProduto).ToList();

            // ########## VALOR TOTAL ##########
            ViewBag.ValorTotal = ValorTotal;

            return View(db.ctOferta.ToList());
        }



        
        public ActionResult AddProduto(int IdProduto)
        {
            MdServicos Produtos = new MdServicos();
            Produtos = db.ctServicos.Where(d => d.IdServico == IdProduto).FirstOrDefault();

            ProdutoSelecionado.Add(Produtos);

            // ########## VALOR TOTAL ##########
            ValorTotal += Produtos.Preco;

            return RedirectToAction("Index/" + IdDono);
        }



        public ActionResult RemoverProduto(int IdProduto)
        {

            foreach (MdServicos item in ProdutoSelecionado)
            {
                if (item.IdServico == IdProduto)
                {
                    ProdutoSelecionado.Remove(item);


                    // ########## VALOR TOTAL ##########
                    ValorTotal -= item.Preco;
                    break;
                }
            }

            return RedirectToAction("Index/" + IdDono);
        }













        // GET: Oferta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdOferta mdOferta = db.ctOferta.Find(id);
            if (mdOferta == null)
            {
                return HttpNotFound();
            }
            return View(mdOferta);
        }

        // GET: Oferta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oferta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOferta,IdCliente,ValorOfertaFinal")] MdOferta mdOferta)
        {
            if (ModelState.IsValid)
            {
                mdOferta.IdCliente = IdDono;
                mdOferta.ValorOfertaFinal = ValorTotal;

                db.ctOferta.Add(mdOferta);
                db.SaveChanges();
                return RedirectToAction("Index/" + IdDono);
            }

            return View(mdOferta);
        }

        // GET: Oferta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdOferta mdOferta = db.ctOferta.Find(id);
            if (mdOferta == null)
            {
                return HttpNotFound();
            }
            return View(mdOferta);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOferta,IdCliente,ValorOfertaFinal")] MdOferta mdOferta)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(mdOferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdOferta);
        }

        // GET: Oferta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdOferta mdOferta = db.ctOferta.Find(id);
            if (mdOferta == null)
            {
                return HttpNotFound();
            }
            return View(mdOferta);
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdOferta mdOferta = db.ctOferta.Find(id);
            db.ctOferta.Remove(mdOferta);
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
