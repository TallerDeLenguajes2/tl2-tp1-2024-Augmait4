
class Program
{
        static void Main()
        {
                int decision = 0;
                List<Pedidos> pedidos = new List<Pedidos>();
                List<Cadeteria> cadeterias = leerDatos.CargarCadeteria(@"C:\Users\augus\Documents\Facultad\Taller-de-Lenguaje-II\tl2-tp1-2024-Augmait4\cadeteria.csv");
                List<Cadete> cadetes = leerDatos.CargarCadetes(@"C:\Users\augus\Documents\Facultad\Taller-de-Lenguaje-II\tl2-tp1-2024-Augmait4\cadetes.csv");

                // pedido1.mostrarPedido();
                // Console.WriteLine();
                while (decision == 0)
                {
                        Console.WriteLine($"--------------{cadeterias[0].Nombre.ToUpper()}---------------");
                        Console.WriteLine("*******************MENU********************");
                        Console.WriteLine("1- Dar De Alta Pedido");
                        Console.WriteLine("2- Asignar Pedido");
                        Console.WriteLine("3 - Cambiar estado De Pedido");
                        Console.WriteLine("4- Reasignar Pedido");
                        Console.WriteLine("0- Salir");
                        decision = Convert.ToInt32(Console.ReadLine());
                        switch (decision)
                        {
                                case 1:
                                        Cliente cliente = Cliente.darDeAltaCliente();
                                        Pedidos pedido = Pedidos.darDeAltaPedido(cliente);
                                        pedidos.Add(pedido);
                                        break;
                                default:
                                        break;
                        }
                }
        }
}
