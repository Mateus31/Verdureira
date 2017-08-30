using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        //
        // GET: /Cliente/
        public List<Cliente> Clientes = new List<Cliente>
        {
        new Cliente {Id = 1, Nome = "Mateus Machado", CPF = "087.967.379-64", Telefone = "99622-8070" },
        new Cliente {Id = 2, Nome = "Luis Tripa Seca", CPF = "542.320.023-23", Telefone = "852552-2200" }
    };

        public ActionResult Index()
        {
            return View(Clientes);
        }

        public ActionResult Details(int id)
        {
            var cliente = Clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }
    }
}

