using System.ComponentModel.DataAnnotations;

namespace PizzeriaWebApp.Models
{
    public class Pizza
    {

        [Required(ErrorMessage="Il campo è obbligatorio")]
        [StringLength(15 , ErrorMessage="Il nome deve essere di massimo 15 caratteri")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double prezzo { get; set; }
        [Required(ErrorMessage = "descrizione è obbligatorio")]
        public string descrizione { get; set; }
        [Required(ErrorMessage = " Il link della foto è obbligatorio")]
        [Url(ErrorMessage ="Devi inserire un Url")]
        public string foto { get; set; }

        public int id { get; set; }



        public Pizza()
        {
             


        }

        public Pizza(int id , string nome , double prezzo , string descrizione , string foto)
        {
            this.id = id;
            this.nome = nome;
            this.prezzo = prezzo;
            this.descrizione = descrizione;
            this.foto = foto;

        }

    }
}
