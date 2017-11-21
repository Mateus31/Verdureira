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
       
            private ApplicationDbContext _context;



            public ClientesController()
            {
                _context = new ApplicationDbContext();
            }

            protected override void Dispose(bool disposing)
            {
                _context.Dispose();
            }
            // GET: Cliente

            public ActionResult Index()
            {

                var clientes = _context.Clientes.ToList();


                return View(clientes);
            }

            public ActionResult Details(int id)
            {
                var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

                if (cliente == null)
                {
                    return HttpNotFound();
                }

                return View(cliente);

            }


            public ActionResult New()
            {

                var cliente = new Cliente();

                return View("ClienteForm", cliente);
            }

            [HttpPost] // só será acessada com POST
            public ActionResult Save(Cliente cliente) // recebemos um cliente
            {
                if (cliente.Id == 0)
                {
                    // armazena o cliente em memória
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    var customerInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                customerInDb.Nome = cliente.Nome;
                customerInDb.Telefone = cliente.Telefone;
                customerInDb.CPF = cliente.CPF;
                    

                }

                // faz a persistência
                _context.SaveChanges();
                // Voltamos para a lista de clientes
                return RedirectToAction("Index");
            }

            public ActionResult Edit(int id)
            {
                var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

                if (cliente == null)
                    return HttpNotFound();


                return View("ClienteForm", cliente);
            }
        }
    }
