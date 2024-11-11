using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria AccesoADatosCSV(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Cadeteria>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            return null;
        }
    }

    public override List<Cadete> cargarCadetes(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Cadete>>(json) ?? new List<Cadete>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            return new List<Cadete>();
        }
    }
}
