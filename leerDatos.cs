using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
public class leerDatos
{
    public static Cadeteria CargarCadeteria(string filePath)
    {
        var cadeterias = new List<Cadeteria>();
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: El archivo '{filePath}' no existe.");
            return null;
        }
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            var line = reader.ReadLine();
            while (line != null)
            {
                var values = line.Split(',');
                int id = int.Parse(values[0]);
                string nombre = values[1];
                string telefono = values[2];
                return new Cadeteria(nombre, telefono);
            }
            return null;
        }
    }
    public static List<Cadete> CargarCadetes(string filePath)
    {
        var cadetes = new List<Cadete>();
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: El archivo '{filePath}' no existe.");
            return null;
        }
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            var line = reader.ReadLine();
            while (line != null)
            {
                var values = line.Split(',');
                int id = int.Parse(values[0]);
                string nombre = values[1];
                string direccion = values[2];
                string telefono = values[3];
                cadetes.Add(new Cadete(id, nombre, direccion, telefono));
                line = reader.ReadLine();
            }
        }
        return cadetes;
    }
}