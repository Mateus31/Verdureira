using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ItensController : Controller
    {

        private ApplicationDbContext _context;



        public ItensController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Itens

        public ActionResult Index()
        {

            var itens = _context.Item.ToList();


            return View(itens);
        }

        public ActionResult Details(int id)
        {
            var item = _context.Item.SingleOrDefault(c => c.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);

        }

        public ActionResult New()
        {

            var item = new Item();

            return View("ItemForm", item);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Item item) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                return View("ItemForm", item);
            }

            if (item.Id == 0)
            {
                // armazena o cliente em memória
                _context.Item.Add(item);
            }
            else
            {
                var customerInDb = _context.Item.Single(c => c.Id == item.Id);

                //customerInDb.DataCompra = item.DataCompra;
                //customerInDb.ProdutoVencido = item.ProdutoVencido;


            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Item.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return HttpNotFound();


            return View("ItemForm", item);
        }
        public ActionResult Delete(int id)
        {
            var item = _context.Item.SingleOrDefault(c => c.Id == id);
            if (item == null)
                return HttpNotFound();
            _context.Item.Remove(item);
            _context.SaveChanges();
            return new HttpStatusCodeResult(200);

        }
    }
}

