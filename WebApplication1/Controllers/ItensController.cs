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
        //
        // GET: /Item/
        public List<Item> Itens = new List<Item>
        {
        new Item {Id = 3, Nome = "Cenoura", Tipo = "Legumes"},
        new Item {Id = 4, Nome = "Alface", Tipo = "Verdura"}
    };

        public ActionResult Index()
        {
            return View(Itens);
        }

        public ActionResult Details(int id)
        {
            var item = Itens.SingleOrDefault(c => c.Id == id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }
    }
}

