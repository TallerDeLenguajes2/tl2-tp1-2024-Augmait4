namespace EspacioCadeteria;
using System.Text.Json;


public class AccesoJson : AccesoDatos
{
    public Cadeteria LeerCadeteria(string nombreArchivo)
    {
        string cadenaCadeteria;
        string ruta = nombreArchivo;
        using (var archivoOpnen = new FileStream(ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                cadenaCadeteria = aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var cadeteriaAux = JsonSerializer.Deserialize<Cadeteria>(cadenaCadeteria);
        var cadeteria = new Cadeteria(cadeteriaAux.Nombre, cadeteriaAux.Telefono);
        return cadeteria;
    }
    public List<Cadete> LeerCadetes(string nombreArchivo)
    {
        string cadenaCadetes;
        string ruta = nombreArchivo;
        using (var archivoOpnen = new FileStream(ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                cadenaCadetes = aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }

        Console.WriteLine("Contenido del archivo JSON:");
        Console.WriteLine(cadenaCadetes);

        var cadetes = JsonSerializer.Deserialize<List<Cadete>>(cadenaCadetes);
        return cadetes;
    }
}