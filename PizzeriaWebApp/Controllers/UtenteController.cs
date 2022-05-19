using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Controllers
{
    public class UtenteController : Controller
    {

        [HttpGet]
        public IActionResult Registrazione()
        {

            return View("Registrazione");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrazione(Utente nuovoUtente)
        {

            if (!ModelState.IsValid)
            {

                return View("HomePage", nuovoUtente);

            }

            using (PizzaContext db = new PizzaContext())
            {

                Utente utenteToInsert = new Utente(nuovoUtente.nomeUtente, nuovoUtente.password);
                db.Add(utenteToInsert);
                db.SaveChanges();

            }

            return RedirectToAction("HomePage" , "Utente");

        }

        [HttpGet]
        public IActionResult HomePage()
        {

            return View("HomePage");

        }

        [HttpPost]

        public IActionResult HomePage(Utente utenteLog)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Utente? result = (from e in db.Utenti where e.nomeUtente == utenteLog.nomeUtente && e.password == utenteLog.password select e).FirstOrDefault();
                if (result != null)
                {
                    
                    return RedirectToAction("Index" , "Pizze");
                }
                else
                {

                    
                    ViewBag.message = string.Format("Nome utente o password errati.");
                    return View("HomePage");

                }
            }

        }
    }
}
