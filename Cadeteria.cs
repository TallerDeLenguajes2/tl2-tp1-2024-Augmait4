public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria (string nom, string tel){
    this.Nombre = nom;
    this.Telefono = tel;
    this.ListadoCadetes = new List<Cadete>();
    }
    
}