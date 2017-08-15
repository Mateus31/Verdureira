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
        public ActionResult Index()
        {
            var cliente = new Cliente
            {
                Nome = "José"
            };
            return View(cliente);
        }
	}
}