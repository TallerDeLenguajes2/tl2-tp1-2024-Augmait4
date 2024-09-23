public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string refDir;

    public Cliente(string nombre, string direccion, string telefono, string refDir)
    {
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.RefDir = refDir;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string RefDir { get => refDir; set => refDir = value; }
}