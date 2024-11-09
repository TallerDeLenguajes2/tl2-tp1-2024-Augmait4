class Pedidos
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
        verDireccionCliente(cliente);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Datos de Referencia De Direccion: " + cliente.DatosReferenciaDireccion);
    }
    public Pedidos darDeAltaPedido(){
        
    }
}