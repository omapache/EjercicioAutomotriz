using EjercicioAutomotriz.Clases;
namespace EjercicioAutomotriz.Clases;

    public class Vehiculo
    {
        public string Placa {get; set;}
        public string Modelo {get; set;}
        public string Marca {get; set;}
        public string Color {get; set;}
        public List<string> Km {get; set;}

        public Vehiculo( string _Marca, string _Modelo, string _Color, string _Placa, List<string> _Km)
        {
            this.Marca = _Marca;
            this.Modelo = _Modelo;
            this.Color = _Color;
            this.Placa = _Placa;
            this.Km = _Km;
        }
        public static Vehiculo AgregarVehiculo()
        {   
            Console.Clear();
            Console.WriteLine("Ingrese la placa del vehiculo: ");
            string placa = Console.ReadLine();
            Console.WriteLine("Ingrese la marca del vehiculo: ");
            string marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehiculo: ");
            string modelo = Console.ReadLine();
            Console.WriteLine("Ingrese el color del vehiculo: ");
            string color = Console.ReadLine();
            List<string> km = new();
            Console.WriteLine("Ingrese el kilometraje:");
            string input = Console.ReadLine();
            km.Add(input); 
            Vehiculo nuevoVehiculo = new(marca,modelo,color,placa,km);
            return nuevoVehiculo;
        }

        public static void ModificarKilometrajeVehiculo(List<Cliente> clientes)
        {
            Cliente.MostrarClienteGlobal(clientes);
            Console.WriteLine("Ingrese la cédula del cliente:");
            string cedulaCliente = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Cedula == cedulaCliente);

            if (cliente != null)
            {
                foreach (Vehiculo vehiculoss in cliente.Vehiculos)
                {
                    Console.WriteLine($"Placa: {vehiculoss.Placa}");
                    Console.WriteLine($"Kilometraje:");
                    foreach (string km in vehiculoss.Km)
                    {
                        Console.WriteLine($"- {km} km");
                    }
                    Console.WriteLine("-----------------------------------------------------");
                }
                Console.WriteLine("Ingrese la placa del vehículo:");
                string placaVehiculo = Console.ReadLine();

                Vehiculo vehiculo = cliente.Vehiculos.Find(v => v.Placa == placaVehiculo);
                if (vehiculo != null)
                {   
                    List<string> kilometrajeAnterior = vehiculo.Km;
                    Console.WriteLine($"Kilometraje anterior: {cliente.Vehiculos.Find(vehiculo => vehiculo.Placa == vehiculo.Placa)?.Km.LastOrDefault(),-13} km");
                    
                    Console.WriteLine($"Ingrese el nuevo kilometraje para el vehículo con placa {placaVehiculo}:");
                    string nuevoKm = Console.ReadLine();
                    vehiculo.Km.Add(nuevoKm); 
                    Console.WriteLine($"Kilometraje actualizado para el vehículo con placa {placaVehiculo}:");
                    Console.WriteLine($"Kilometraje anterior: {kilometrajeAnterior} km");
                    Console.WriteLine($"Nuevo kilometraje: {nuevoKm} km");
                }
                else
                {
                    Console.WriteLine($"No se encontró un vehículo con placa {placaVehiculo} para el cliente con cédula {cedulaCliente}.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró un cliente con cédula {cedulaCliente}.");
            }
        }
    }
        
