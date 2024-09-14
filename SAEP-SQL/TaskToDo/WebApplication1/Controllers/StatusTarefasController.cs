using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StatusTarefasController : Controller
    {
        private BdToDoEntities db = new BdToDoEntities();

        // GET: StatusTarefas
        public ActionResult Index()
        {
            return View(db.StatusTarefa.ToList());
        }

        // GET: StatusTarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // GET: StatusTarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusTarefas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descricao")] StatusTarefa statusTarefa)
        {
            if (ModelState.IsValid)
            {
                db.StatusTarefa.Add(statusTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusTarefa);
        }

        // GET: StatusTarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // POST: StatusTarefas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao")] StatusTarefa statusTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusTarefa);
        }

        // GET: StatusTarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // POST: StatusTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            db.StatusTarefa.Remove(statusTarefa);
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
