using System;
using System.Collections.Generic;
using System.IO;
public class Funciones
{
    private static Cadeteria miCadeteria;

    private List<Pedidos> pedidosDisponibles = new List<Pedidos>();
    private List<Cadeteria> cadeterias = new List<Cadeteria>();

    public void Menu()
    {
        LeerCadeteriasCSV("cadeteria.csv");
        LeerCadetesCSV("cadetes.csv");
        SeleccionarCadeteria();
        MostrarCadeteriasConCadetes();
        int Opcion = 0;
        while (Opcion != 6)
        {
            Console.WriteLine("Menu De Centro De Operaciones");
            Console.WriteLine("1- Dar de Alta Pedidos");
            Console.WriteLine("2- Asignar Cadetes");
            Console.WriteLine("3- Cambiar Estado");
            Console.WriteLine("4- Reasignar el Pedido");
            Console.WriteLine("5- Mostrar Pedido");
            Console.WriteLine("6- Generara Informe De Fin de jornada Y Salir");
            Console.WriteLine("Ingresar Opcion: ");
            Opcion = Convert.ToInt32(Console.ReadLine());
            switch (Opcion)
            {
                case 1:
                    DarDeAlta();
                    break;
                case 2:
                    AsignarCadete();
                    break;
                case 3:
                    cambiarEstado();
                    break;
                case 4:
                    reasignarPedido();
                    break;
                case 5:
                    MostrarPedidos();
                    break;
                case 6:
                    GenerarInformeFinJornada();
                    break;
                default:
                    break;
            }

        }
    }

    private void GenerarInformeFinJornada()
    {
        Console.WriteLine("/-----------INFORME DE PEDIDOS-----------/");

        // Filtrar pedidos entregados y agrupar por cadete
        var enviosPorCadete = miCadeteria.ListadoPedidos
            .Where(p => p.EstadoPedido1 == Pedidos.estados.Entregado)
            .GroupBy(p => miCadeteria.ListadoCadetes1.FirstOrDefault(c => c.ListadoPedido1.Contains(p)))
            .Select(g => new
            {
                Cadete = g.Key,
                CantidadEnvios = g.Count(),
                Ganancia = g.Count() * 500 // $500 por envío
            })
            .ToList();

        int totalEnvios = enviosPorCadete.Sum(e => e.CantidadEnvios);
        decimal totalGanancias = enviosPorCadete.Sum(e => e.Ganancia);
        int totalCadetes = enviosPorCadete.Count;

        // Mostrar información de cada cadete
        foreach (var item in enviosPorCadete)
        {
            Console.WriteLine($"Cadete: {item.Cadete.Nombre}, Envíos: {item.CantidadEnvios}, Ganancia: ${item.Ganancia}");
        }

        // Mostrar totales y promedio
        Console.WriteLine($"\nTotal de envíos: {totalEnvios}");
        Console.WriteLine($"Total ganado: ${totalGanancias}");

        if (totalCadetes > 0)
        {
            decimal promedioEnvios = (decimal)totalEnvios / totalCadetes;
            Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios:F2}");
        }
        else
        {
            Console.WriteLine("No hay cadetes asignados.");
        }

        Console.WriteLine("/-----------------------------------------/");
    }

    private void MostrarPedidos()
    {
        if (miCadeteria.ListadoPedidos.Count == 0)
        {
            Console.WriteLine("No hay pedidos en la lista.");
            return;
        }

        // Recorremos todos los pedidos
        foreach (var pedido in miCadeteria.ListadoPedidos)
        {
            // Mostrar la información básica del pedido
            Console.WriteLine($"\nPedido N°: {pedido.Nro}");
            Console.WriteLine($"Cliente: {pedido.Cliente.Nombre}, Dirección: {pedido.Cliente.Direccion}");
            Console.WriteLine($"Observación: {pedido.Obs}");
            Console.WriteLine($"Estado: {pedido.EstadoPedido1}");

            // Si el pedido está asignado, buscamos el cadete asignado
            if (pedido.EstadoPedido1 == Pedidos.estados.Asignado || pedido.EstadoPedido1 == Pedidos.estados.Entregado)
            {
                // Buscar el cadete que tiene este pedido asignado
                Cadete cadeteAsignado = miCadeteria.ListadoCadetes1
                    .FirstOrDefault(c => c.ListadoPedido1.Contains(pedido));

                if (cadeteAsignado != null)
                {
                    Console.WriteLine($"Cadete Asignado: {cadeteAsignado.Nombre}");
                }
                else
                {
                    Console.WriteLine("Error: Pedido asignado pero no se encontró el cadete.");
                }
            }
            else
            {
                Console.WriteLine("Cadete Asignado: Ninguno (Pedido pendiente)");
            }
        }
    }
    private void reasignarPedido()
    {
        if (miCadeteria.ListadoPedidos.Count == 0)
        {
            Console.WriteLine("No hay pedidos para reasignar.");
            return;
        }

        // Mostrar todos los pedidos que están asignados
        Console.WriteLine("Pedidos asignados:");
        List<Pedidos> pedidosAsignados = miCadeteria.ListadoPedidos
            .Where(p => p.EstadoPedido1 == Pedidos.estados.Asignado).ToList();

        if (pedidosAsignados.Count == 0)
        {
            Console.WriteLine("No hay pedidos asignados para reasignar.");
            return;
        }

        for (int i = 0; i < pedidosAsignados.Count; i++)
        {
            Console.WriteLine($"{i + 1}- Pedido {pedidosAsignados[i].Nro}, Cliente: {pedidosAsignados[i].Cliente.Nombre}, Estado: {pedidosAsignados[i].EstadoPedido1}");
        }

        Console.Write("Seleccione el número del pedido a reasignar: ");
        int indicePedido = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indicePedido < 0 || indicePedido >= pedidosAsignados.Count)
        {
            Console.WriteLine("Pedido no válido.");
            return;
        }

        Pedidos pedido = pedidosAsignados[indicePedido];

        // Buscar al cadete actual que tiene este pedido
        Cadete cadeteActual = miCadeteria.ListadoCadetes1.FirstOrDefault(c => c.ListadoPedido1.Contains(pedido));

        if (cadeteActual != null)
        {
            cadeteActual.removerPedido(pedido);  // Eliminar el pedido del cadete actual
            Console.WriteLine($"Pedido removido del cadete {cadeteActual.Nombre}.");
        }

        // Seleccionar un nuevo cadete para reasignar
        Console.Write("Ingrese el ID del nuevo Cadete al que se le reasignará el pedido: ");
        int nuevoIdCadete = Convert.ToInt32(Console.ReadLine());
        Cadete nuevoCadete = miCadeteria.ListadoCadetes1.FirstOrDefault(c => c.Id == nuevoIdCadete);

        if (nuevoCadete != null)
        {
            // Reasignar el pedido al nuevo cadete
            nuevoCadete.agregarPedido(pedido);
            Console.WriteLine($"Pedido reasignado al cadete {nuevoCadete.Nombre}.");
        }
        else
        {
            Console.WriteLine("Nuevo cadete no encontrado.");
        }
    }

    private void cambiarEstado()
    {
        if (miCadeteria.ListadoPedidos.Count == 0)
        {
            Console.WriteLine("No hay pedidos disponibles para asignar.");
            return;
        }

        // Mostrar lista de pedidos para elegir uno
        Console.WriteLine("Pedidos disponibles:");
        for (int i = 0; i < miCadeteria.ListadoPedidos.Count; i++)
        {
            Console.WriteLine($"{i + 1}- Pedido {miCadeteria.ListadoPedidos[i].Nro}, Estado: {miCadeteria.ListadoPedidos[i].EstadoPedido1}");
        }

        Console.Write("Seleccione el número del pedido para cambiar su estado: ");
        int indicePedido = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indicePedido < 0 || indicePedido >= miCadeteria.ListadoPedidos.Count)
        {
            Console.WriteLine("Pedido no válido.");
            return;
        }

        Pedidos pedido = miCadeteria.ListadoPedidos[indicePedido];
        int opcion = 0;
        while (opcion != 1 && opcion != 2)
        {
            Console.WriteLine("Seleccione el nuevo Estado: ");
            Console.WriteLine("1- Cancelado");
            Console.WriteLine("2- Entregado");
            opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                pedido.EstadoPedido1 = Pedidos.estados.Cancelado;
            }
            else if (opcion == 2)
            {
                pedido.EstadoPedido1 = Pedidos.estados.Entregado;
            }
            else
            {
                Console.WriteLine("Eleccion invalida");
            }
        }
    }
    private void DarDeAlta()
    {
        Console.WriteLine("/-----------PEDIDO-----------/");
        Console.Write("Ingresar numero del Pedido: ");
        int nuevoNro = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingresar Observacion del Pedido: ");
        string nuevaObsPedido = Console.ReadLine();
        Console.Write("Ingresar nombre del Cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.Write("Ingresar Direccion Del Cliente: ");
        string dirCliente = Console.ReadLine();
        Console.Write("Ingresar Telefono del Cliente: ");
        string telCliente = Console.ReadLine();
        Console.Write("Ingresar Referencia de la Direccion del Cliente: ");
        string refDirCliente = Console.ReadLine();

        /*Asignacio De Datos A los Objetos Cliente y Pedidos*/
        Cliente nuevoCliente = new Cliente(nombreCliente, dirCliente, telCliente, refDirCliente);
        Pedidos nuevoPedido = new Pedidos(nuevoNro, nuevaObsPedido, nuevoCliente, Pedidos.estados.Pendiente);

        miCadeteria.ListadoPedidos.Add(nuevoPedido);

        if (nuevoPedido.EstadoPedido1 == Pedidos.estados.Pendiente)
        {
            pedidosDisponibles.Add(nuevoPedido);
        }
    }
    private void AsignarCadete()
    {
        if (pedidosDisponibles.Count == 0)
        {
            Console.WriteLine("No hay pedidos disponibles para asignar.");
            return;
        }

        // Mostrar lista de pedidos para elegir uno
        Console.WriteLine("Pedidos disponibles:");
        for (int i = 0; i < pedidosDisponibles.Count; i++)
        {
            Console.WriteLine($"{i + 1}- Pedido {pedidosDisponibles[i].Nro}, Estado: {pedidosDisponibles[i].EstadoPedido1}");
        }

        Console.Write("Seleccione el número del pedido a asignar: ");
        int indicePedido = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indicePedido < 0 || indicePedido >= pedidosDisponibles.Count)
        {
            Console.WriteLine("Pedido no válido.");
            return;
        }

        Pedidos pedido = pedidosDisponibles[indicePedido];

        // Asignar pedido a un cadete
        Console.Write("Ingrese el ID del Cadete al que se le asignará el pedido: ");
        int idCadete = Convert.ToInt32(Console.ReadLine());
        Cadete cadete = miCadeteria.ListadoCadetes1.FirstOrDefault(c => c.Id == idCadete);

        if (cadete != null)
        {
            cadete.agregarPedido(pedido);
            pedido.EstadoPedido1 = Pedidos.estados.Asignado;
            Console.WriteLine("Pedido asignado al cadete.");
            pedidosDisponibles.RemoveAt(indicePedido);
            Console.WriteLine("Pedido eliminado de la lista de pedidos disponibles.");
        }
        else
        {
            Console.WriteLine("Cadete no encontrado.");
        }
    }
    public void LeerCadeteriasCSV(string archivo)
    {
        try
        {
            using (StreamReader sr = new StreamReader(archivo))
            {
                sr.ReadLine();
                string linea;
                // Leer cada línea del archivo CSV
                while ((linea = sr.ReadLine()) != null)
                {
                    // Separar los campos por la coma
                    string[] campos = linea.Split(',');

                    // Crear un objeto Cadeteria usando los campos
                    int id = Convert.ToInt32(campos[0]);
                    string nombre = campos[1];
                    string telefono = campos[2];

                    miCadeteria = new Cadeteria(id, nombre, telefono);

                    // Añadir la cadetería a la lista
                    cadeterias.Add(miCadeteria);
                }
            }

            Console.WriteLine("Cadeterías leídas correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer el archivo de cadeterías.");
            Console.WriteLine(e.Message);
        }
    }

    public void MostrarCadeteriasConCadetes()
    {
        foreach (var cadeteria in cadeterias)
        {
            Console.WriteLine($"Cadetería: {cadeteria.Nombre}, Teléfono: {cadeteria.Telefono}");
            Console.WriteLine("Cadetes:");

            foreach (var cadete in cadeteria.ListadoCadetes1)
            {
                Console.WriteLine($"- {cadete.Nombre} (ID: {cadete.Id})");
            }
            Console.WriteLine(); // Línea vacía entre cadeterías
        }
    }
    public void LeerCadetesCSV(string archivo)
    {
        try
        {
            using (StreamReader sr = new StreamReader(archivo))
            {
                // Saltar la primera línea (encabezados)
                sr.ReadLine();

                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length < 5)
                    {
                        Console.WriteLine("Línea inválida en el archivo CSV.");
                        continue;
                    }

                    int id = Convert.ToInt32(campos[0]);
                    string nombre = campos[1];
                    string direccion = campos[2];
                    string telefono = campos[3];
                    int idCadeteria = Convert.ToInt32(campos[4]);

                    Cadete nuevoCadete = new Cadete(id, nombre, direccion, telefono);

                    // Buscar la cadetería correspondiente y añadir el cadete a su lista
                    Cadeteria cadeteria = cadeterias.FirstOrDefault(c => c.Id == idCadeteria);
                    if (cadeteria != null)
                    {
                        cadeteria.ListadoCadetes1.Add(nuevoCadete);
                    }
                }
            }

            Console.WriteLine("Cadetes leídos correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer el archivo de cadetes.");
            Console.WriteLine(e.Message);
        }
    }
    private void SeleccionarCadeteria()
    {
        Console.WriteLine("Seleccione una Cadetería:");
        for (int i = 0; i < cadeterias.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {cadeterias[i].Nombre}");
        }

        Console.Write("Ingrese el número de la cadetería que desea seleccionar: ");
        int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;

        if (seleccion >= 0 && seleccion < cadeterias.Count)
        {
            miCadeteria = cadeterias[seleccion];
            Console.WriteLine($"Cadetería seleccionada: {miCadeteria.Nombre}");
        }
        else
        {
            Console.WriteLine("Selección no válida.");
        }
    }
}
