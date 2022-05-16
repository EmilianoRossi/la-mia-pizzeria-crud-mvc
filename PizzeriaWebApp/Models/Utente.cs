using System.ComponentModel.DataAnnotations;

namespace PizzeriaWebApp.Models
{
    public class Utente
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Per favore inserisci un nome utente")]
        [StringLength (18 , ErrorMessage ="Il nome utente deve avere massimo 18 caratteri e minimo 8")]
        public string nomeUtente { get; set; }
        [Required(ErrorMessage = "Per favore inserisci una password")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "Password \"{0}\" must have {2} character")]
        public string password { get; set; }

        public Utente()
        {


        }

        public Utente(string nomeUtente, string password)
        {
            this.nomeUtente = nomeUtente;
            this.password = password;
        }
    }

}
