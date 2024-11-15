public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;
    public Cliente(string nom, string dir, string tel, string datRefDir)
    {
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
        this.DatosReferenciaDireccion = datRefDir;
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    public static Cliente darDeAltaCliente(string nom, string dir, string tel, string refDir)
    {
        Cliente cliente1 = new Cliente(nom, dir, tel, refDir);
        return cliente1;
    }
}