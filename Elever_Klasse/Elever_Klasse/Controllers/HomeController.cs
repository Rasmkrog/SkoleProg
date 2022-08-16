using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elever_Klasse.Models;

namespace Elever_Klasse.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //List<Elevliste> _elever = new List<Elevliste>();

            //using (EleverEntities entities = new EleverEntities())
            //{
            //    _elever = (from r in entities.Elevliste
            //               where r.Navn == "Daniel"
            //               select r).ToList();
            //}
            return View(/*_elever*/);
        }

        [HttpPost]
        public JsonResult AjaxMethod(string Name)
        {
            if (Name is null)
            {
                throw new ArgumentNullException(nameof(Name));
            }


            Elevliste _elever = new Elevliste();

            using (EleverEntities entities = new EleverEntities())
            {
                _elever = (from r in entities.Elevliste
                           where r.Navn == Name
                           select r).FirstOrDefault();
            }

            return (Json(_elever));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}