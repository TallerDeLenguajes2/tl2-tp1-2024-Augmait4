public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;


    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public Cadete() { }
    public Cadete(int id, string nom, string dir, string tel)
    {
        this.Id = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
    }
    public void datosCadete()
    {
        Console.WriteLine("*****CADETE*****");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Direccion: {Direccion}");
        Console.WriteLine($"Telefono: {Telefono}");
    }
}