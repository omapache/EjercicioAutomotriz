namespace EjercicioAutomotriz.Clases;

    public class Cliente : Persona
    {
        public DateTime FechaRegistro {get; set; }
        public List<Vehiculo> Vehiculos {get; set; }

        public Cliente(string _Cedula, string _Nombre, string _Apellido, string _NroMovil, string _Email, DateTime _FechaRegistro,List<Vehiculo> _Vehiculos) : base(_Cedula, _Nombre, _Apellido, _NroMovil, _Email)
        {   
            this.Cedula = _Cedula;
            this.Nombre = _Nombre;
            this.Apellido = _Apellido;
            this.NroMovil = _NroMovil;
            this.Email = _Email;
            this.FechaRegistro = _FechaRegistro;
            this.Vehiculos = _Vehiculos;
        }

        public static Cliente AgregarCliente()
        {   
            List<Vehiculo> listaVehiculos = new();
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
            DateTime fechaActual = DateTime.Now;
            bool seguir = true;
            do
            {
                Console.WriteLine("Desea agregar vehiculos al cliente?(S:si/N:no) :");
                string opcionAgregarVehiculo = Console.ReadLine();
                if (opcionAgregarVehiculo.ToUpper() == "S"){
                    listaVehiculos.Add(Vehiculo.AgregarVehiculo());
                }else if(opcionAgregarVehiculo.ToUpper() == "N"){
                    seguir = false;
                }
                else{
                    Console.WriteLine("Opción no valida");
                }
            } while (seguir);
            Cliente nuevoCliente = new(cedula, nombre, apellido, nroMovil, email, fechaActual, listaVehiculos);
            return nuevoCliente;
        }

        public static void MostrarClienteEspecifico(List<Cliente> listaClientes)
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del cliente: ");
            string cedulaCliente = Console.ReadLine();

            Cliente clienteEspecifico = listaClientes.Find(cliente => cliente.Cedula == cedulaCliente);

            if (clienteEspecifico != null)
            {
                Console.WriteLine($"Cédula: {clienteEspecifico.Cedula}");
                Console.WriteLine($"Nombre: {clienteEspecifico.Nombre}");
                Console.WriteLine($"Apellido: {clienteEspecifico.Apellido}");
                Console.WriteLine($"Número de móvil: {clienteEspecifico.NroMovil}");
                Console.WriteLine($"Email: {clienteEspecifico.Email}");
                Console.WriteLine($"Fecha: {clienteEspecifico.FechaRegistro}");
                
                if (clienteEspecifico.Vehiculos.Count == 0)
                {
                    Console.WriteLine("No tiene vehículos, Agréguelos");
                }
                else
                {
                    Console.WriteLine("Vehículos:");
                    foreach (Vehiculo vehiculo in clienteEspecifico.Vehiculos)
                    {
                        Console.WriteLine($"- Placa: {vehiculo.Placa}");
                        Console.WriteLine($"- Modelo: {vehiculo.Modelo}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con la cédula: {cedulaCliente}");
            }

            Console.WriteLine();
        }

        public static void MostrarClienteGlobal(List<Cliente> listaClientes){
            Console.Clear();
            Console.WriteLine($"CEDULA\tNOMBRE");
            foreach (Cliente cliente in listaClientes)
            {
                Console.WriteLine($"{cliente.Cedula}\t{cliente.Nombre}");
            }
            Console.WriteLine();
        }
        public static void MostrarClienteVehiculos(List<Cliente> listaClientes, string cedulaCliente)
        {
            Cliente cliente = listaClientes.Find(c => c.Cedula == cedulaCliente);

            if (cliente != null)
            {
                Console.WriteLine($"Cliente: {cliente.Nombre} {cliente.Apellido}");
                Console.WriteLine("Vehículos:");
                
                foreach (Vehiculo vehiculo in cliente.Vehiculos)
                {
                    Console.WriteLine($"Placa: {vehiculo.Placa}");
                    Console.WriteLine($"Kilometraje:");
                    
                    foreach (string km in vehiculo.Km)
                    {
                        Console.WriteLine($"- {km} km");
                    }
                    
                    Console.WriteLine("-----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró un cliente con cédula {cedulaCliente}.");
            }
            Console.WriteLine();
        }

    }
