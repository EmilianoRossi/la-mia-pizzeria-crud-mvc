using System.ComponentModel.DataAnnotations;

namespace PizzeriaWebApp.Models
{
    public class Categoria
    {
        //attributi
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string Titolo { get; set; }
        //metodo per collegare un entità in relazione 1 n
        public List<Pizza> Pizzas { get; set; }

        public Categoria()
        {



        }
    }

   
        
}
