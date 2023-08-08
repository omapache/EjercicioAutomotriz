namespace EjercicioAutomotriz.Clases;

    public class Empleado : Persona
    {
        public string Especialidad {get; set;}

        public Empleado(string _Cedula, string _Nombre, string _Apellido, string _NroMovil, string _Email, string _Especialidad)
            : base(_Cedula, _Nombre, _Apellido, _NroMovil, _Email)
        {   
            this.Cedula = _Cedula;
            this.Nombre = _Nombre;
            this.Apellido = _Apellido;
            this.NroMovil = _NroMovil;
            this.Email = _Email;
            this.Especialidad = _Especialidad;
        }
        public static Empleado AgregarEmpleado()
        {   
            Console.Clear();
            Console.WriteLine("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el número de móvil: ");
            string nroMovil = Console.ReadLine();
            Console.WriteLine("Ingrese el email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Ingrese la Especialidad: ");
            string especialidad = Console.ReadLine();


            Empleado nuevoEmpleado = new(cedula, nombre, apellido, nroMovil, email, especialidad);

            return nuevoEmpleado;
        }

        public static void MostrarEmpleadoEspecifico(List<Empleado> listaEmpleado)
        {   
            MostrarEmpleadoGlobal(listaEmpleado);
            Console.Clear();
            Console.Write("Ingrese la cédula del Empleado: ");
            string cedulaEmpleado = Console.ReadLine();

            Empleado empleadoEspecifico = listaEmpleado.Find(empleado => empleado.Cedula == cedulaEmpleado);

            if (empleadoEspecifico != null)
            {
                Console.WriteLine($"Cédula: {empleadoEspecifico.Cedula}");
                Console.WriteLine($"Nombre: {empleadoEspecifico.Nombre}");
                Console.WriteLine($"Apellido: {empleadoEspecifico.Apellido}");
                Console.WriteLine($"Número de móvil: {empleadoEspecifico.NroMovil}");
                Console.WriteLine($"Email: {empleadoEspecifico.Email}");
                Console.WriteLine($"Especialidad: {empleadoEspecifico.Especialidad}");
                
            }
            else
            {
                Console.WriteLine($"No se encontró ningún empleado con la cédula: {cedulaEmpleado}");
            }
            Console.WriteLine();
        }

        public static void MostrarEmpleadoGlobal(List<Empleado> listaEmpleado){
            Console.Clear();
            Console.WriteLine($"CEDULA\tNOMBRE\tESPECIALIDAD");
            foreach (Empleado empleado in listaEmpleado)
            {
                Console.WriteLine($"{empleado.Cedula}\t{empleado.Nombre}\t{empleado.Especialidad}");
            }
            Console.WriteLine();
        }
    }
