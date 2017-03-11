using System.Collections.Generic;

namespace tarea1
{
    public class Pizza
    {

        public Pizza(int tipo)
        {
            Ingredientes = new LinkedList<Ingrediente>();
            switch (tipo)
            {
                case 1:
                    Ingredientes.AddLast(new Ingrediente("Chile"));
                    Ingredientes.AddLast(new Ingrediente("Cebolla"));
                    Ingredientes.AddLast(new Ingrediente("Hongos"));
                    Ingredientes.AddLast(new Ingrediente("Pepperoni"));
                    Tipo = "Suprema";

                    break;
                case 2:
                    Ingredientes.AddLast(new Ingrediente("Jamón"));
                    Tipo = "Jamón";
                    break;
                case 3:
                    Ingredientes.AddLast(new Ingrediente("Piña"));
                    Ingredientes.AddLast(new Ingrediente("Jamón"));
                    Ingredientes.AddLast(new Ingrediente("Coco"));
                    Tipo = "Hawaiana";
                    break;
                case 4:
                    Ingredientes.AddLast(new Ingrediente("Pepperoni"));
                    Tipo = "Pepperoni";
                    break;

            }
            Ingredientes.AddLast(new Ingrediente("Queso"));
            Ingredientes.AddLast(new Ingrediente("Pasta"));
            Ingredientes.AddLast(new Ingrediente("Salsa de Tomate"));
        }


        public string Tipo { set; get; }
        public LinkedList<Ingrediente> Ingredientes { set; get; }

    }
}
