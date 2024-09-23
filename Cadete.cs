public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> ListadoPedido;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.ListadoPedido = new List<Pedidos>();
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListadoPedido1 { get => ListadoPedido; set => ListadoPedido = value; }
    public void agregarPedido(Pedidos pedidos)
    {
        ListadoPedido1.Add(pedidos);
    }
        public void removerPedido(Pedidos pedido)
    {
        ListadoPedido1.Remove(pedido);
    }
}