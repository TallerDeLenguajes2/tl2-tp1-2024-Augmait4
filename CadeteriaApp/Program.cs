using System;
using CadeteriaLibrary;
namespace EspacioCadeteria;
class Program
{
    static void Main(string[] args)
    {
        // Crear una nueva cadetería
        Cadeteria cadeteria = new Cadeteria();
        var archivoJson = new AccesoJson();
        var archivoCvs = new AccesoCSV();
        Console.WriteLine("elija como cargar los datos\n1:Json\n2:CVS");
        int opcionArchivo = int.Parse(Console.ReadLine());
        if (opcionArchivo == 1)
        {
            cadeteria = archivoJson.LeerCadeteria(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\JSOM\cadeteria.json");
            cadeteria.ListadoCadetes = archivoJson.LeerCadetes(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\JSON\cadetes.json");

        }
        if (opcionArchivo == 2)
        {
            cadeteria = archivoCvs.LeerCadeteria(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\CSV\cadeteria.csv");
            cadeteria.ListadoCadetes = archivoCvs.LeerCadetes(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\CSV\cadetes.csv");
        }
        Cliente cliente = new Cliente("Juan Perez", "Calle Falsa 123", "123-456789", "Entre Calle Catamarca");

        cadeteria.agregarPedido("milanesa", "Juan Perez", "Calle Falsa 123", "123-456789", "Entre Calle Catamarca", 0);

        // Mostrar los pedidos
        foreach (var pedido in cadeteria.ListadoPedidos)
        {
            Console.WriteLine($"Pedido N° {pedido.Numero}, Cliente: {pedido.Cliente.Nombre}");
        }

        // Lógica adicional como asignar cadetes, cambiar estado de pedidos, etc.
    }
}
