using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Controllers
{
    public class UtenteController : Controller
    {

        [HttpGet]
        public IActionResult HomePage()
        {

            return View("HomePage");

        }

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
    }
}
