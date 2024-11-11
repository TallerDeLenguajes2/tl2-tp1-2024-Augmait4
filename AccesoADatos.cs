public abstract class AccesoADatos
{
    public abstract Cadeteria AccesoADatosCSV(string filePath);
    public abstract List<Cadete> cargarCadetes(string filePath);
}