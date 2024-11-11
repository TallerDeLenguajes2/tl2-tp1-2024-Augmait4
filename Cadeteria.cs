using System.Reflection.Metadata.Ecma335;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedidos> listadoPedidos;
    public string Nombre { get => nombre;  set => nombre = value; }
    public string Telefono { get => telefono;  set => telefono = value; }
    internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria() { }
    public Cadeteria(string nom, string tel)
    {
        this.Nombre = nom;
        this.Telefono = tel;
        this.ListadoCadetes = new List<Cadete>();
        this.listadoPedidos = new List<Pedidos>();
    }
    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }
    public void agregarPedido(Pedidos pedido)
    {
        ListadoPedidos.Add(pedido);
    }
    public int jornalACobrar(int idCadete)
    {
        int pagoDelDia = listadoPedidos.Count(lp => lp.Cadetes.Id == idCadete && lp.Estado == Pedidos.Estados.Entregado) * 500;
        return pagoDelDia;
    }
    public void AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        var cadeteSeleccionado = listadoCadetes.FirstOrDefault(lc => lc.Id == idCadete);
        if (cadeteSeleccionado != null)
        {
            var pedidoSeleccionado = listadoPedidos.FirstOrDefault(lp => lp.Numero == nroPedido);
            if (pedidoSeleccionado != null)
            {
                pedidoSeleccionado.Cadetes = cadeteSeleccionado;
            }
            else
            {
                Console.WriteLine("No se encontró el pedido con el número especificado.");
            }
        }
        else
        {
            Console.WriteLine("No se encontró el cadete con el ID especificado.");
        }
    }
}