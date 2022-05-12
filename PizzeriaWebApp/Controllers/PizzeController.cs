using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Models;
using PizzeriaWebApp.Utils;

namespace PizzeriaWebApp.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public Microsoft.AspNetCore.Mvc.IActionResult LeMiePizze()
        {
            List<Pizza> pizzas = PizzaData.GetPizza();
            return View(pizzas);
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

            Pizza pizzaConId = new Pizza(nuovaPizza.id , nuovaPizza.nome, nuovaPizza.prezzo, nuovaPizza.descrizione, nuovaPizza.foto);

            PizzaData.GetPizza().Add(pizzaConId);

            return RedirectToAction("Index" , "Pizze");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Pizza pizzaToEdit = GetPizzaById(id);

            if(pizzaToEdit == null)
            {

                return NotFound();

            }
            else
            {

                return View("Update" , pizzaToEdit);

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
            Pizza pizzaOriginal = GetPizzaById(id);

            if(pizzaOriginal != null)
            {

                pizzaOriginal.nome = model.nome;
                pizzaOriginal.prezzo = model.prezzo;
                pizzaOriginal.foto = model.foto;
                pizzaOriginal.descrizione = model.descrizione;

                return RedirectToAction("Index");
            }
            else
            {

                return NotFound();

            }

        }

        //Metodo per ricercare un post, lo puo utilizzare solo questo controller poichè privato
        private Pizza GetPizzaById(int id)
        {

            Pizza pizzaFound = null;

            foreach(Pizza pizza in PizzaData.GetPizza())
            {

                if(pizza.id == id)
                {

                    pizzaFound = pizza;
                    break;

                }

            }

            return pizzaFound;
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {

            int PizzaIndexToRemove = -1;

            List<Pizza> pizzaList = PizzaData.GetPizza();

            for (int i = 0; i < pizzaList.Count; i++)
            {

                if(pizzaList[i].id == id)
                {

                    PizzaIndexToRemove = i;

                }

            }

            if(PizzaIndexToRemove != -1)
            {

                PizzaData.GetPizza().RemoveAt(PizzaIndexToRemove);
                return RedirectToAction("Index");

            }
            else
            {

                return NotFound();

            }
        }        
    }
}
