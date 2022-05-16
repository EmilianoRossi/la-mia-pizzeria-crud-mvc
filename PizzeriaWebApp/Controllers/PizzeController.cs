using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;
using PizzeriaWebApp.Utils;

namespace PizzeriaWebApp.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public IActionResult LeMiePizze()
        {
            List<Pizza> pizzas = new List<Pizza>();

            using(PizzaContext db = new PizzaContext())
            {

                pizzas = db.Pizzas.ToList<Pizza>();

            }

            return View("LeMiePizze" , pizzas);
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();

        }

        [HttpGet]
        public IActionResult HomePage()
        {

            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View("FormPost");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza nuovaPizza)
        {

            if (!ModelState.IsValid)
            {

                return View("FormPost" , nuovaPizza);

            }

            using(PizzaContext db = new PizzaContext())
            {

                Pizza pizzaToCreate = new Pizza(nuovaPizza.nome , nuovaPizza.prezzo , nuovaPizza.descrizione , nuovaPizza.foto);
                db.Add(pizzaToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("Index" , "Pizze");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Pizza pizzaToEdit = null;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaToEdit = db.Pizzas
                     .Where(post => post.id == id)
                     .FirstOrDefault();

            }

            if (pizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", pizzaToEdit);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update (int id , Pizza model)
        {

            if (!ModelState.IsValid)
            {

                return View("Update", model);

            }

            Pizza pizzaToEdit = null;

            using (PizzaContext db = new PizzaContext())
            {

                pizzaToEdit = db.Pizzas
                    .Where(pizza => pizza.id == id)
                    .FirstOrDefault();

            }

            if (pizzaToEdit != null)
            {

                pizzaToEdit.nome = model.nome;
                pizzaToEdit.prezzo = model.prezzo;
                pizzaToEdit.descrizione = model.descrizione;
                pizzaToEdit.foto = model.foto;

                return RedirectToAction("Index");

            }
            else
            {

                return NotFound();

            }

        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {

                Pizza pizzaToDelete = db.Pizzas
                    .Where(pizza => pizza.id == id)
                    .FirstOrDefault();

                if(pizzaToDelete != null)
                {

                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {

                    return NotFound();

                }

            }

            
        }

        [HttpPost]
        public IActionResult Cart(int id, Pizza model)
        {

            return NotFound();

        }

        /*[HttpGet]
        public IActionResult Cart(int id)
        {


            return View("Cart", pizzaToShop);


        }*/
    }
}
