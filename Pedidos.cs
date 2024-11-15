public class Pedidos
{
    public enum Estados
    {
        enCamino,
        Entregado
    }
    private static int contadorPedidos = 0;
    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estados estado;
    private Cadete cadetes;
    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    public Estados Estado { get => estado; set => estado = value; }
    public Cadete Cadetes { get => cadetes; set => cadetes = value; }
    public Pedidos(string obs)
    {
        this.Numero = GenerarNumeroPedido();
        this.Observacion = obs;
        this.Estado = Estados.enCamino;
    }
    private static int GenerarNumeroPedido()
    {
        contadorPedidos++; // Incrementar el contador
        return contadorPedidos; // Retornar el número generado
    }

    private string verDireccionCliente(Cliente cliente)
    {
        return cliente.Direccion;
    }
    public static Pedidos darDeAltaPedido(string obs)
    {
        Pedidos datosPedido = new Pedidos(obs);
        return datosPedido;
    }
    public static void cambiarEstado(Pedidos pedido)
    {
        pedido.Estado = Estados.Entregado;
    }
}