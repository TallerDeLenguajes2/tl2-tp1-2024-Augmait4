namespace cliente
{
public class Cliente
{
    private string nombre;
    private string cel;
    private string direccion;
    private string refDirecc;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Cel { get => cel; set => cel = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string RefDirecc { get => refDirecc; set => refDirecc = value; }
    }
}