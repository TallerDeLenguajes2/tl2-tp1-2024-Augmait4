namespace EspacioCadeteria;
class Program
{
        static void Main()
        {
                Cadeteria cadeteria = null;
                int decision = -1;
                int numeroPedido;
                int numeroCadete;
                var archivoJson = new AccesoJson();
                var archivoCvs = new AccesoCSV();
                Console.WriteLine("elija como cargar los datos\n1:Json\n2:CVS");
                int opcionArchivo = int.Parse(Console.ReadLine());
                if (opcionArchivo == 1)
                {
                        cadeteria = archivoJson.LeerCadeteria(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\cadeteria.json");
                        cadeteria.ListadoCadetes = archivoJson.LeerCadetes(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\cadetes.json");

                }
                if (opcionArchivo == 2)
                {
                        cadeteria = archivoCvs.LeerCadeteria(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\cadeteria.csv");
                        cadeteria.ListadoCadetes = archivoCvs.LeerCadetes(@"C:\Users\augus\OneDrive\Documents\Estudios Facultad\Taller de Lenguajes II\tl2-tp1-2024-Augmait4\cadetes.csv");
                }
                // pedido1.mostrarPedido();
                // Console.WriteLine();
                while (decision != 0)
                {
                        Console.WriteLine($"--------------{cadeteria.Nombre.ToUpper()}---------------");
                        Console.WriteLine("*******************MENU********************");
                        Console.WriteLine("1- Dar De Alta Pedido");
                        Console.WriteLine("2- Asignar Pedido");
                        Console.WriteLine("3- Cambiar estado De Pedido");
                        Console.WriteLine("4- Reasignar Pedido");
                        Console.WriteLine("5- Ver Pago del Dia de Un Cadete");
                        Console.WriteLine("0- Salir");
                        decision = Convert.ToInt32(Console.ReadLine());
                        switch (decision)
                        {
                                case 1: //Dar De Alta Pedido
                                        Pedidos pedido = Pedidos.darDeAltaPedido();
                                        cadeteria.ListadoPedidos.Add(pedido);
                                        break;
                                case 2: //Asignar Pedido
                                        Console.WriteLine("*****PEDIDOS******");
                                        foreach (var pedido1 in cadeteria.ListadoPedidos)
                                        {
                                                pedido1.mostrarPedido();
                                        }
                                        Console.WriteLine("Seleccione el Pedido Introduciendo Su numero: ");
                                        numeroPedido = Convert.ToInt32(Console.ReadLine());
                                        foreach (var cadete in cadeteria.ListadoCadetes)
                                        {
                                                cadete.datosCadete();
                                        }
                                        Console.WriteLine("Seleccione el Cadete que desea asignar al pedido Introduciendo Su Id: ");
                                        numeroCadete = Convert.ToInt32(Console.ReadLine());
                                        cadeteria.AsignarCadeteAPedido(numeroCadete, numeroPedido);
                                        break;
                                case 3: //Cambiar Estado de Pedido
                                        Console.WriteLine("Ingresa el Numero de Pedido: ");
                                        numeroPedido = Convert.ToInt32(Console.ReadLine());
                                        var pedidoSeleccionado = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedido);
                                        if (pedidoSeleccionado != null)
                                        {
                                                Pedidos.cambiarEstado(pedidoSeleccionado);
                                                Console.WriteLine("Estado del pedido cambiado exitosamente.");
                                        }
                                        else
                                        {
                                                Console.WriteLine("No se encontró el pedido con el número especificado en la lista de pedidos del cadete.");
                                        }
                                        break;
                                case 4: //Reasignar Pedido
                                        {
                                                if (cadeteria.ListadoPedidos != null)
                                                {
                                                        foreach (var pedidos1 in cadeteria.ListadoPedidos)
                                                        {
                                                                pedidos1.mostrarPedido();
                                                        }
                                                }
                                        }
                                        Console.WriteLine("Ingresa el Numero de Pedido: ");
                                        numeroPedido = Convert.ToInt32(Console.ReadLine());
                                        Pedidos pedidoSelec = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedido);
                                        if (pedidoSelec != null)
                                        {
                                                Console.WriteLine("Selecciona el Cadete que desea reasignar el pedido: ");
                                                int idCadete = Convert.ToInt32(Console.ReadLine());
                                                var cadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
                                                if (cadete == pedidoSelec.Cadetes)
                                                {
                                                        Console.WriteLine("No se Puede reasigar un Cadete que ya esta Asignado");
                                                }
                                                else
                                                {
                                                        pedidoSelec.Cadetes = cadete;
                                                }
                                        }
                                        else
                                        {
                                                Console.WriteLine("No se encontró el pedido con el número especificado en la lista de pedidos del cadete.");
                                        }
                                        break;
                                case 5: //Ver Pago Del Dia Del Cadete
                                        Console.WriteLine("Introduce el Id del Cadete: ");
                                        int idCadetes = Convert.ToInt32(Console.ReadLine());
                                        float pagoDelDia = cadeteria.jornalACobrar(idCadetes);
                                        Console.WriteLine($"Pago del Dia {pagoDelDia}");
                                        break;
                                default: //Muestra De Informe
                                        float promedio = 0;
                                        int totalPedidosEntregado = cadeteria.ListadoPedidos.Count(p => p.Estado == Pedidos.Estados.Entregado);
                                        foreach (var cadete in cadeteria.ListadoCadetes)
                                        {
                                                int pedidosEntregadosPorCadete = cadeteria.ListadoPedidos.Count(p => p.Estado == Pedidos.Estados.Entregado && p.Cadetes.Id == cadete.Id);
                                                if (pedidosEntregadosPorCadete == 0)
                                                {
                                                        Console.WriteLine("No ha Realizado ninguna Entrega.");
                                                }
                                                else
                                                {
                                                        promedio = totalPedidosEntregado / pedidosEntregadosPorCadete;
                                                }
                                                Console.WriteLine($"Cadete: {cadete.Nombre}");
                                                Console.WriteLine($"Pedidos Entregados: {pedidosEntregadosPorCadete}");
                                                Console.WriteLine($"Promedio De Envios: {promedio}");
                                                Console.WriteLine("-------------------------");
                                        }
                                        break;
                        }
                }
        }
}
