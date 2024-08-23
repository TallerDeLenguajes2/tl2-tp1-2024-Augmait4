
using cadete;

namespace cadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string tel;
        private List<Cadete>listaCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tel { get => tel; set => tel = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        
    }
}