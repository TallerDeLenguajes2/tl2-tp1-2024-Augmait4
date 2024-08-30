enum Estados
    {
        procesamiento,
        enCamino,
        entregado,
    }
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;

        public Pedido(string nombre, string cel, string direcc, string refdirecc)
        {
            this.cliente = new Cliente(){
                Nombre = nombre, Cel = cel, Direccion = direcc, RefDirecc = refdirecc,
            };
        }

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public string verDireccionCliente(){
            return cliente.Direccion;
        }
        public void verDatoCliente(Cliente cliente){
            Console.WriteLine(cliente.Nombre);
            Console.WriteLine(cliente.Direccion);
            Console.WriteLine(cliente.RefDirecc);
            Console.WriteLine(cliente.Cel);
        }
    }