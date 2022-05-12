using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Utils
{

    //Statica perchè ci serve un metodo che ci restituisca una lista di info
    public static class PizzaData
    {

        private static List<Pizza> pizzas;

        public static List<Pizza> GetPizza()
        {

            if(PizzaData.pizzas != null)
            {

                return PizzaData.pizzas;

            }
            List<Pizza> nuovaPizzas = new List<Pizza>();
            Pizza pizza = new Pizza(1 ,"Pizza Margherita" , 6.00 , "Pizza base rossa con mozzarella e basilico IGP" , "https://www.scattidigusto.it/wp-content/uploads/2020/09/pizza-margherita-Diametro-33-Napoli-1568x1045.jpg");
            Pizza pizza2 = new Pizza(2, "Pizza Marinara", 7.00, "Pizza base rossa con aglio alici e origano", "https://foodandchips.com/wp-content/uploads/2019/02/pizza-Marinara-impasto-46-ore.jpg");
            Pizza pizza3 = new Pizza(3, "Pizza Boscaiola", 8.00, "Pizza base rossa con aglio alici e origano", "https://d2j6dbq0eux0bg.cloudfront.net/images/47695117/2129452902.jpg");
            Pizza pizza4 = new Pizza(4, "Pizza Crostino", 8.00, "Pizza base rossa con aglio alici e origano", "https://www.alfaforni.com/wp-content/uploads/2020/05/pizza-crostino-cotto-e-mozzarella-alfa-forni.jpg");
            Pizza pizza5 = new Pizza(5, "Pizza Diavola", 8.00, "Pizza base rossa con aglio alici e origano", "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/03/d2.jpg");

            nuovaPizzas.Add(pizza);
            nuovaPizzas.Add(pizza2);
            nuovaPizzas.Add(pizza3);
            nuovaPizzas.Add(pizza4);
            nuovaPizzas.Add(pizza5);

            PizzaData.pizzas = nuovaPizzas;


            

            return PizzaData.pizzas;
            
        }




    }


}
