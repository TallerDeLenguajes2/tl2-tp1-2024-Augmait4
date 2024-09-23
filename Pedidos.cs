public class Pedidos
{
    public enum estados
    {
        Pendiente,
        Asignado,
        Entregado,
        Cancelado,
    }
    private int nro;
    private string obs;
    private Cliente cliente;
    private estados EstadoPedido;

    public Pedidos(int nro, string obs, Cliente cliente, estados estadoPedido)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        EstadoPedido = estadoPedido;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public estados EstadoPedido1 { get => EstadoPedido; set => EstadoPedido = value; }
    public String VerDireccionCliente()
    {
        return Cliente.Direccion;
    }
    public string VerDatosCliente( Cliente cliente)
    {
        string Datos = "Nombre: "+ cliente.Nombre + " Direccion: " + cliente.Direccion + " Telefono: " + cliente.Telefono;
        return Datos;
    }
}