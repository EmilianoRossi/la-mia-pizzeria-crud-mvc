using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {

                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (search != null && search != "")
                {
                    pizzas = db.Pizzas.Where(pizze => pizze.Nome.Contains(search) || pizze.Descrizione.Contains(search)).ToList<Pizza>();
                }
                else
                {
                    pizzas = db.Pizzas.ToList<Pizza>();
                }
            }

            return Ok(pizzas);
        }

    }
}
