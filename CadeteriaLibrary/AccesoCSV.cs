using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
namespace EspacioCadeteria;
public class AccesoCSV : AccesoDatos
{
    public   Cadeteria LeerCadeteria(string filePath)
    {
        var cadeterias = new List<Cadeteria>();
        if (!File.Exists(filePath))
        {
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
    public  List<Cadete> LeerCadetes(string filePath)
    {
        var cadetes = new List<Cadete>();
        if (!File.Exists(filePath))
        {
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