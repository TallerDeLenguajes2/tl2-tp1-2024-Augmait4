namespace EspacioCadeteria;
class Program
{
        static void Main()
        {
                Cadeteria cadeteria = null;
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
        }
}
