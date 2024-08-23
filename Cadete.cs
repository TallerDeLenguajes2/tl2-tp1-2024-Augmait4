using pedidos;
namespace cadete
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string tel;
        
        private List<Pedido>listaPedidos;

        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Tel { get => tel; set => tel = value; }
    }
}