using System;

namespace tarea1
{
    class Program
    {
        private static bool fin;
        private static int[] inventario = { 100, 100, 100, 50, 50, 30, 30, 30, 5, 5, 5 };
        private static Pizza[] pizzas;
        private static int cantidadPizzasVendidas;
        static void Main(string[] args)
        {
            fin = false;
            pizzas = new Pizza[40];
            cantidadPizzasVendidas = 0;
            Menu();
        }

        private static void Menu()
        {
            while (!fin)
            {
                Console.WriteLine("¿Qué desea hacer?:");
                Console.WriteLine("1. Solicitar Pizza");
                Console.WriteLine("2. Mostrar inventario de Ingredientes");
                Console.WriteLine("3. Reiniciar cantidad de inventario");
                Console.WriteLine("4. Mostrar pizzas vendidas");
                Console.WriteLine("5. Salir");

                string inputString = Console.ReadLine();
                Console.WriteLine("\n");

                int inputInt = 0;
                if (int.TryParse(inputString, out inputInt))
                {
                    switch (inputInt)
                    {
                        case 1:
                            SolicitarPizza();
                            break;
                        case 2:
                            MostrarInventario();
                            break;
                        case 3:
                            ReiniciarInventario();
                            break;
                        case 4:
                            MostrarPizzas();
                            break;
                        case 5:
                            Salir();
                            break;
                        default:
                            Error();
                            break;
                    }
                }
                else
                {
                    Error();
                }
            }
        }

        private static void Error()
        {
            Console.WriteLine("ERROR, Por favor digite una opción valida\n");

        }

        private static void Salir()
        {
            Console.WriteLine("Finalizando...");
            System.Threading.Thread.Sleep(1000);
            fin = true;
        }

        private static void MostrarPizzas()
        {
            Console.WriteLine("Mostrando Pizzas vendidas:");

            for (int i = 0; i < pizzas.Length; i++)
            {
                if (pizzas[i] == null)
                    break;
                Console.WriteLine((i + 1).ToString() + ". " + pizzas[i].Tipo);
            }
            Console.WriteLine("\n");
        }

        private static void ReiniciarInventario()
        {
            Console.WriteLine("Reiniciando el inventario...");
            inventario[0] = 100;
            inventario[1] = 100;
            inventario[2] = 100;
            inventario[3] = 50;
            inventario[4] = 50;
            inventario[5] = 30;
            inventario[6] = 30;
            inventario[7] = 30;
            inventario[8] = 5;
            inventario[9] = 5;
            inventario[10] = 5;
            Console.WriteLine("\n");
        }

        private static void MostrarInventario()
        {
            Console.WriteLine("Mostrando Cantidad del inventario:");
            Console.WriteLine("1. Pasta:" + inventario[0]);
            Console.WriteLine("2. queso:" + inventario[1]);
            Console.WriteLine("3. Salsa de Tomate:" + inventario[2]);
            Console.WriteLine("4. Chile:" + inventario[3]);
            Console.WriteLine("5. Cebolla:" + inventario[4]);
            Console.WriteLine("6. Carne Molida:" + inventario[5]);
            Console.WriteLine("7. Jamón:" + inventario[6]);
            Console.WriteLine("8. Pepperoni:" + inventario[7]);
            Console.WriteLine("9. Piña:" + inventario[8]);
            Console.WriteLine("10. Coco:" + inventario[9]);
            Console.WriteLine("11. Aceitunas:" + inventario[10] + "\n");
        }


        static void SolicitarPizza()
        {
            Console.WriteLine("¿Qué pizza desea comprar?");
            Console.WriteLine("1. Suprema");
            Console.WriteLine("2. Jamón");
            Console.WriteLine("3. hawaiana");
            Console.WriteLine("4. Pepperoni");

            string inputString = Console.ReadLine();
            int inputInt = 0;

            if (int.TryParse(inputString, out inputInt))
            {
                if (cantidadPizzasVendidas < 40)
                {
                    Console.WriteLine("¿Desea agregarle aceitunas?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No");
                    string aceitunasString = Console.ReadLine();
                    int deseaAceitunas = 0;
                    if (int.TryParse(aceitunasString, out deseaAceitunas) && PreguntaSiNO(deseaAceitunas))
                    {
                        if (HaySuficientesIngredientes(inputInt, deseaAceitunas))
                        {
                            switch (inputInt)
                            {
                                case 1:
                                    inventario[3]--; //Chile
                                    inventario[4]--; //Cebolla
                                    //No hay posición para los hongos
                                    inventario[7]--; //Pepperoni
                                    break;
                                case 2:
                                    inventario[6]--; //Jamón
                                    break;
                                case 3:
                                    inventario[6]--; //Jamón
                                    inventario[8]--; //Piña
                                    inventario[9]--; //Coco
                                    break;
                                case 4:
                                    inventario[7]--; //Pepperoni
                                    break;

                            }

                            inventario[0]--; //Pasta
                            inventario[1]--; //Queso
                            inventario[2]--; //Salsa de tomate
                            if (deseaAceitunas == 1)
                                inventario[10]--;
                            pizzas[cantidadPizzasVendidas] = new Pizza(inputInt);
                            cantidadPizzasVendidas++;
                        }
                        else
                        {
                            Console.WriteLine(
                                "No es posible despachar su pizza por falta de ingredientes, disculpe el inconveniente");
                        }
                    }
                    else
                    {
                        Error();
                    }
                }
                else
                {
                    Console.WriteLine("Ya no puede vender más pizzas por hoy");
                }
            }
            else
            {
                Error();
            }
            Console.WriteLine("\n");
        }

        private static bool PreguntaSiNO(int input)
        {
            return (input > 0 && input < 3);
        }

        private static bool HaySuficientesIngredientes(int tipo, int aceitunas)
        {
            if (inventario[0] < 1 || inventario[1] < 1 || inventario[2] < 1)
                return false;

            switch (tipo)
            {
                case 1:
                    if (inventario[3] < 1 || inventario[4] < 1 || inventario[7] < 1)
                        return false;
                    break;
                case 2:
                    if (inventario[0] < 6)
                        return false;
                    break;
                case 3:
                    if (inventario[6] < 1 || inventario[8] < 1 || inventario[9] < 1)
                        return false;
                    break;
                case 4:
                    if (inventario[7] < 1)
                        return false;
                    break;
            }

            if (aceitunas == 1)
                if (inventario[10] < 1)
                    return false;

            return true;
        }
    }
}