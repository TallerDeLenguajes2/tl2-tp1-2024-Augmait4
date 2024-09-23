public class Cadeteria
{
    private int id;
    private string nombre;
    private string telefono;
    private List<Cadete> ListadoCadetes;
    private List<Pedidos> listadoPedidos;

    public Cadeteria(int id, string nombre, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.telefono = telefono;
        ListadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedidos>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes1 { get => ListadoCadetes; set => ListadoCadetes = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public int Id { get => id; set => id = value; }
}