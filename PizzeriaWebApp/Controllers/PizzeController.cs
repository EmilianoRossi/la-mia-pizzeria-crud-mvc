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
        public IActionResult Create()
        {
            using(PizzaContext db = new PizzaContext())
            {

                List<Categoria> categories = db.Categorie.ToList();
                PizzasCategories model = new PizzasCategories();
                model.pizza = new Pizza();
                model.categorias = categories;
                return View("Create", model);

            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzasCategories data)
        {

            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {

                    List<Categoria> categories = db.Categorie.ToList();
                    data.categorias = categories;

                }
                    return View("Create", data);

            }

            using(PizzaContext db = new PizzaContext())
            {

                Pizza pizzaToCreate = new Pizza();
                pizzaToCreate.Nome = data.pizza.Nome;
                pizzaToCreate.Descrizione = data.pizza.Descrizione;
                pizzaToCreate.Foto = data.pizza.Foto;
                pizzaToCreate.Prezzo = data.pizza.Prezzo;
                pizzaToCreate.CategoriaId = data.pizza.CategoriaId;
                db.Add(pizzaToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("Index" , "Pizze");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Pizza pizzaToEdit = null;
            List<Categoria> categories = new List<Categoria>();
            using (PizzaContext db = new PizzaContext())
            {
                pizzaToEdit = db.Pizzas
                     .Where(pizza => pizza.Id == id)
                     .FirstOrDefault();
                categories = db.Categorie.ToList<Categoria>();

            }

            if (pizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                PizzasCategories model = new PizzasCategories();

                return View("Update", model);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update (int id , PizzasCategories model)
        {

            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {

                    List<Categoria> categories = db.Categorie.ToList();
                    model.categorias = categories;

                }
                return View("Update", model);

            }

            Pizza pizzaToEdit = null;

            using (PizzaContext db = new PizzaContext())
            {

                pizzaToEdit = db.Pizzas
                    .Where(pizza => pizza.Id == id)
                    .FirstOrDefault();

            }

            if (pizzaToEdit != null)
            {

                pizzaToEdit.Nome = model.pizza.Nome;
                pizzaToEdit.Prezzo = model.pizza.Prezzo;
                pizzaToEdit.Descrizione = model.pizza.Descrizione;
                pizzaToEdit.Foto = model.pizza.Foto;
                pizzaToEdit.CategoriaId = model.pizza.CategoriaId;

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
                    .Where(pizza => pizza.Id == id)
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
