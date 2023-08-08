namespace EjercicioAutomotriz.Clases; 

    public class Repuesto
    {
        private static int nextId = 1; 
        public string Id {get; set;}
        public string IdOrdenServicio {get; set;}
        public string IdEmpleado {get; set;}
        public string Nombre {get; set;}
        public float ValorUnitario {get; set;}
        public int Cantidad {get; set;}
        public bool Estado {get; set;}
        public DateTime FechaAgregado {get; set;}

        public Repuesto(string _IdOrdenServicio, string _IdEmpleado, string _Nombre, float _ValorUnitario, int _Cantidad,DateTime _FechaAgregado){
            this.Id = GenerateNextId();
            this.IdOrdenServicio = _IdOrdenServicio;
            this.IdEmpleado = _IdEmpleado;
            this.Nombre = _Nombre;
            this.ValorUnitario = _ValorUnitario;
            this.Cantidad = _Cantidad;
            this.Estado = false;
            this.FechaAgregado = _FechaAgregado;
        }
        public static Repuesto AgregarRepuesto(string idOrdenServicio, string idEmpleado)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Repuesto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el valor unitario del Repuesto: ");
            float valorUnitario = float.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de Repuesto a pedir: ");
            int cantidad = int.Parse(Console.ReadLine());
            DateTime fechaActual = DateTime.Now;

            Repuesto nuevoRepuesto = new(idOrdenServicio, idEmpleado, nombre, valorUnitario, cantidad, fechaActual);
            return nuevoRepuesto;
        }
        static string GenerateNextId()
        {
            string newId = nextId.ToString();
            nextId++;
            return newId;
        }

        
    }

