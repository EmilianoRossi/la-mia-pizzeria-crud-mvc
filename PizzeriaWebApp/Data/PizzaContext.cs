using Microsoft.EntityFrameworkCore;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Data
{
    public class PizzaContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer("Data Source=localhost; Database=blog_pizza; Integrated Security= true");


        }

    }
}
