using Microsoft.VisualBasic;

class Program
{
    static void Main(Strings[] args)
    {
        Cliente cliente1 = new Cliente("Jose", "Jose Federico Moreno 943", "3816239129", "Entre Calles Santiago y Catamarca");
        Pedidos pedido1 = new Pedidos(1, "Milanesa");
        pedido1.verDatosCliente(cliente1);
    }

}