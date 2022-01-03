using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Windows;
using Check02.Context;
using Check02.Models;

namespace Check02.Controllers
{
    public class DonoController : Controller
    {
        private Context.Context db = new Context.Context();
        private MdDono dono = new MdDono();

        // GET: Dono
        public ActionResult Index()
        {
            return View(db.ctDonos.ToList());
        }

        public static bool ValidarTelefone(string num)
        {
            Regex validation = new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");

            if (!validation.IsMatch(num))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            
            if (cpf.Length != 11)
                return false;

            // ########## VALIDAÇÃO DO PRIMEIRO DIGITO ##########
            // 1º PASSO: Multiplica-se os 9 primeiros dígitos pela sequência decrescente de números de 10 à 2 e soma os resultados.
            // 2º PASSO: Basta multiplicarmos esse resultado por 10 e dividirmos por 11.
            // O resultado que nos interessa na verdade é o RESTO da divisão. Se ele for igual ao primeiro dígito verificador (primeiro dígito depois do '-'), a primeira parte da validação está correta.
            // Se o resto da divisão for igual a 10, nós o consideramos como 0.

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();


            // ########## VALIDAÇÃO DO SEGUNDO DÍGITO ##########
            // 1º PASSO: vamos considerar os 9 primeiros dígitos, mais o primeiro dígito verificador, e vamos multiplicar esses 10 números pela sequencia decrescente de 11 a 2
            // 2º PASSO: Seguindo o mesmo processo da primeira verificação, multiplicamos por 10 e dividimos por 11
            // O resultado que nos interessa na verdade é o RESTO da divisão.

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        // GET: Dono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdDono mdDono = db.ctDonos.Find(id);
            if (mdDono == null)
            {
                return HttpNotFound();
            }
            return View(mdDono);
        }

        // GET: Dono/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Dono/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDono,NmDono,Telefone,Nascimento,Cpf")] MdDono mdDono)
        {
            bool verificationTel = ValidarTelefone(mdDono.Telefone);
            bool verificationCpf = ValidarCpf(mdDono.Cpf);

            if (!verificationTel)
            {
                MessageBox.Show("Telefone inválido");
            }
            else if (!verificationCpf)
            {
                MessageBox.Show("CPF inválido");
            }
            else if(verificationTel && verificationCpf)
            {
                if (ModelState.IsValid)
                {
                    db.ctDonos.Add(mdDono);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(mdDono);
        }

        // GET: Dono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdDono mdDono = db.ctDonos.Find(id);
            if (mdDono == null)
            {
                return HttpNotFound();
            }
            return View(mdDono);
        }

        // POST: Dono/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDono,NmDono,Telefone,Nascimento,Cpf")] MdDono mdDono)
        {
            bool verificationTel = ValidarTelefone(mdDono.Telefone);
            bool verificationCpf = ValidarCpf(mdDono.Cpf);

            if (!verificationTel)
            {
                MessageBox.Show("Telefone inválido");
            }
            else if (!verificationCpf)
            {
                MessageBox.Show("CPF inválido");
            }
            else if (verificationTel && verificationCpf)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(mdDono).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            return View(mdDono);
        }

        // GET: Dono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdDono mdDono = db.ctDonos.Find(id);
            if (mdDono == null)
            {
                return HttpNotFound();
            }
            return View(mdDono);
        }

        // POST: Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdDono mdDono = db.ctDonos.Find(id);
            db.ctDonos.Remove(mdDono);
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
