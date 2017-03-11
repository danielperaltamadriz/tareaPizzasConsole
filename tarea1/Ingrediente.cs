namespace tarea1
{
    public class Ingrediente
    {
        public Ingrediente(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { set; get; }
        public string Tipo { set; get; }
        public int Calorias { set; get; }
    }
}
