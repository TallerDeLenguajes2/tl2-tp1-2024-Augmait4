
class Program
{
        static void Main()
        {
                int decision = -1;
                int numeroPedido;
                int numeroCadete;
                List<Pedidos> pedidos = new List<Pedidos>();
                Cadeteria cadeteria = leerDatos.CargarCadeteria(@"C:\Users\augus\Documents\Facultad\Taller-de-Lenguaje-II\tl2-tp1-2024-Augmait4\cadeteria.csv");
                List<Cadete> cadetes = leerDatos.CargarCadetes(@"C:\Users\augus\Documents\Facultad\Taller-de-Lenguaje-II\tl2-tp1-2024-Augmait4\cadetes.csv");
                foreach (var cadete in cadetes)
                {
                        cadeteria.agregarCadete(cadete);
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
                        Console.WriteLine("0- Salir");
                        decision = Convert.ToInt32(Console.ReadLine());
                        switch (decision)
                        {
                                case 1:
                                        Pedidos pedido = Pedidos.darDeAltaPedido();
                                        pedidos.Add(pedido);
                                        break;
                                case 2:
                                        if (pedidos.Count() == 0)
                                        {
                                                Console.WriteLine("No hay pedidos que asignar.");
                                        }
                                        else
                                        {
                                                foreach (var pedido1 in pedidos)
                                                {
                                                        pedido1.mostrarPedido();
                                                }
                                                Console.WriteLine("Seleccione el Pedido Introduciendo Su numero: ");
                                                numeroPedido = Convert.ToInt32(Console.ReadLine());
                                                foreach (var cadete in cadetes)
                                                {
                                                        cadete.datosCadete();
                                                }
                                                Console.WriteLine("Seleccione el Cadete Introduciendo Su Id: ");
                                                numeroCadete = Convert.ToInt32(Console.ReadLine());
                                                var cadeteSeleccionado1 = cadetes.FirstOrDefault(c => c.Id == numeroCadete);
                                                if (cadeteSeleccionado1 != null)
                                                {
                                                        var pedidoSeleccionado = pedidos.FirstOrDefault(p => p.Numero == numeroPedido);
                                                        if (pedidoSeleccionado != null)
                                                        {
                                                                cadeteSeleccionado1.agregarPedido(pedidoSeleccionado);
                                                                Console.WriteLine("Pedido asignado exitosamente al cadete.");
                                                                pedidos.Remove(pedidoSeleccionado);
                                                        }
                                                        else
                                                        {
                                                                Console.WriteLine("No se encontró el pedido con el número especificado.");
                                                        }
                                                }
                                                else
                                                {
                                                        Console.WriteLine("No se encontró el cadete con el ID especificado.");
                                                }
                                        }
                                        break;
                                case 3:
                                        foreach (var cadete in cadetes)
                                        {
                                                cadete.datosCadete();
                                                if (cadete.ListadoPedidos != null)
                                                {
                                                        foreach (var pedidos1 in cadete.ListadoPedidos)
                                                        {
                                                                pedidos1.mostrarPedido();
                                                        }
                                                }
                                                else
                                                {
                                                        Console.WriteLine("El Cadete No tiene pedidos Asignados Aun.");
                                                }
                                        }
                                        Console.WriteLine("Ingresa el Id del Cadete que tiene asignado el pedido: ");
                                        numeroCadete = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Ingresa el Numero de Pedido: ");
                                        numeroPedido = Convert.ToInt32(Console.ReadLine());
                                        var eleccion1 = cadetes.FirstOrDefault(c => c.Id == numeroCadete);
                                        if (eleccion1 != null)
                                        {
                                                var eleccion2 = eleccion1.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedido);
                                                if (eleccion2 != null)
                                                {
                                                        Pedidos.cambiarEstado(eleccion2);
                                                        Console.WriteLine("Estado del pedido cambiado exitosamente.");
                                                }
                                                else
                                                {
                                                        Console.WriteLine("No se encontró el pedido con el número especificado en la lista de pedidos del cadete.");
                                                }
                                        }
                                        else
                                        {
                                                Console.WriteLine("No se encontró el cadete con el ID especificado.");
                                        }
                                        break;
                                case 4:
                                        Pedidos aux = null;
                                        Pedidos pedidoSelec = null;
                                        foreach (var cadete in cadetes)
                                        {
                                                cadete.datosCadete();
                                                if (cadete.ListadoPedidos != null)
                                                {
                                                        foreach (var pedidos1 in cadete.ListadoPedidos)
                                                        {
                                                                pedidos1.mostrarPedido();
                                                        }
                                                }
                                                else
                                                {
                                                        Console.WriteLine("El Cadete No tiene pedidos Asignados Aun.");
                                                }
                                        }
                                        Console.WriteLine("Ingresa el Id del Cadete que tiene asignado el pedido: ");
                                        numeroCadete = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Ingresa el Numero de Pedido: ");
                                        numeroPedido = Convert.ToInt32(Console.ReadLine());
                                        var eleccion = cadetes.FirstOrDefault(c => c.Id == numeroCadete);
                                        if (eleccion != null)
                                        {
                                                pedidoSelec = eleccion.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedido);
                                                if (pedidoSelec != null)
                                                {
                                                        aux = pedidoSelec;
                                                        eleccion.ListadoPedidos.Remove(pedidoSelec);
                                                }
                                                else
                                                {
                                                        Console.WriteLine("No se encontró el pedido con el número especificado en la lista de pedidos del cadete.");
                                                }
                                        }
                                        else
                                        {
                                                Console.WriteLine("No se encontró el cadete con el ID especificado.");
                                        }
                                        Console.WriteLine("Seleccione el Cadete al que quiere reasignar el pedido Introduciendo  Su Id: ");
                                        numeroCadete = Convert.ToInt32(Console.ReadLine());
                                        var cadeteSeleccionado = cadetes.FirstOrDefault(c => c.Id == numeroCadete);
                                        if (cadeteSeleccionado != null)
                                        {
                                                cadeteSeleccionado.agregarPedido(aux);
                                                Console.WriteLine("Pedido reasignado exitosamente al cadete.");
                                        }
                                        else
                                        {
                                                Console.WriteLine("No se encontró el cadete con el ID especificado.");
                                        }

                                        break;
                                default:
                                        int totalPedidosEntregado = cadetes.Sum(c => c.ListadoPedidos.Count(p => p.Estado == Pedidos.Estados.Entregado));
                                        foreach (var cadete in cadetes)
                                        {
                                                int pedidoEntregados = cadete.ListadoPedidos.Where(p => p.Estado == Pedidos.Estados.Entregado).Count();
                                                int pagoDelDia = pedidoEntregados * 500;
                                                if (pedidoEntregados == 0)
                                                {
                                                        Console.WriteLine("No ha Realizado ninguna Entrega.");
                                                }
                                                else
                                                {
                                                        float promedio = totalPedidosEntregado / pedidoEntregados;
                                                }
                                                Console.WriteLine($"Cadete: {cadete.Nombre}");
                                                Console.WriteLine($"Pedidos Entregados: {pedidoEntregados}");
                                                Console.WriteLine($"Pago del día: ${pagoDelDia}");
                                                Console.WriteLine($"Promedio De Envios: ${pagoDelDia}");
                                                Console.WriteLine("-------------------------");
                                        }
                                        break;
                        }
                }
        }
}
