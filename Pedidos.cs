public class Pedidos
{
    enum Estados
    {
        enCamino,
        Entregado
    }
    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estados estado;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    private Estados Estado { get => estado; set => estado = value; }

    public Pedidos(int nro, string obs)
    {
        this.Numero = nro;
        this.Observacion = obs;
        this.Estado = Estados.enCamino;
    }
    private void verDireccionCliente(Cliente cliente)
    {
        Console.WriteLine(cliente.Direccion);
    }
    public void verDatosCliente(Cliente cliente){
        Console.WriteLine("Nombre: " + cliente.Nombre);
        Console.Write("Direccion: ");
        verDireccionCliente(cliente);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Datos de Referencia De Direccion: " + cliente.DatosReferenciaDireccion);
    }
    public void mostrarPedido(){
        Console.WriteLine($"Nro: {Numero}");
        Console.WriteLine($"Observacion: {Observacion}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Cliente: ");
        verDatosCliente(Cliente);
    }
    public static Pedidos darDeAltaPedido(Cliente cliente){
        Pedidos datosPedido = new Pedidos(0, "");
        Console.WriteLine("Ingresar Numero De Pedido: ");
        datosPedido.Numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingresar Observacion Del Pedido: ");
        datosPedido.Observacion = Console.ReadLine();
        datosPedido.Cliente = cliente;
        return datosPedido;
    }
    public static void cambiarEstado(Pedidos pedido){
        pedido.Estado = Estados.Entregado;
    }
}