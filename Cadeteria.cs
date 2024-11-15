using System.Reflection.Metadata.Ecma335;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedidos> listadoPedidos;
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
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
    public void agregarCadete(string nombre, string telefono, string direccion, int id)
    {
        Cadete nuevoCadete = new Cadete { Nombre = nombre, Telefono = telefono, Direccion = direccion, Id = id };
        listadoCadetes.Add(nuevoCadete);
    }
    public void agregarPedido(string observacion, string clienteNom, string clienteDir, string clienteTel, string clienteDatRefDir, int posicionCadete)
    {
        Cliente nuevoCliente = null;
        nuevoCliente = Cliente.darDeAltaCliente(clienteNom, clienteDir, clienteTel, clienteDatRefDir);
        Pedidos nuevoPedido = null;
        nuevoPedido = new Pedidos(nuevoPedido.Observacion = observacion);
        nuevoPedido.Cadetes = ListadoCadetes[posicionCadete];
        nuevoPedido.Cliente = nuevoCliente;
        ListadoPedidos.Add(nuevoPedido);
    }
    public int jornalACobrar(int idCadete)
    {
        int pagoDelDia = listadoPedidos.Count(lp => lp.Cadetes.Id == idCadete && lp.Estado == Pedidos.Estados.Entregado) * 500;
        return pagoDelDia;
    }
    public string AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        var cadeteSeleccionado = listadoCadetes.FirstOrDefault(lc => lc.Id == idCadete);
        if (cadeteSeleccionado != null)
        {
            var pedidoSeleccionado = listadoPedidos.FirstOrDefault(lp => lp.Numero == nroPedido);
            if (pedidoSeleccionado != null)
            {
                pedidoSeleccionado.Cadetes = cadeteSeleccionado;
                return "Asignacion Correcta";
            }
            else
            {
                return "No se encontró el pedido con el número especificado.";
            }
        }
        else
        {
            return "No se encontró el cadete con el ID especificado.";
        }
    }
}