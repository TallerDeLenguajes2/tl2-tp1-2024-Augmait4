
    public class Cadeteria
    {
        private string nombre;
        private string tel;
        private List<Cadete>listaCadetes;

        public Cadeteria()
        {
            this.listaCadetes = new List<Cadete>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tel { get => tel; set => tel = value; }
        public float JornalACobrar(int idCadete){
            float jornalCobrar=0;
            return jornalCobrar;
        }        
    }