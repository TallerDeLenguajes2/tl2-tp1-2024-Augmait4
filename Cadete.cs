public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    internal List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete(int id, string nom, string dir, string tel)
    {
        this.Id = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
        this.ListadoPedidos = new List<Pedidos>();
    }
    public void agregarPedido(Pedidos pedido)
    {
        listadoPedidos.Add(pedido);
    }
    public void datosCadete()
    {
        Console.WriteLine("*****CADETE*****");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Direccion: {Direccion}");
        Console.WriteLine($"Telefono: {Telefono}");
    }
    public int jornalACobrar(int cantidad)
    {

        int pagoDelDia = cantidad * 500;
        return pagoDelDia;
    }
}