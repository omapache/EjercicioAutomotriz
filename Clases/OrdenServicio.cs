namespace EjercicioAutomotriz.Clases;

    public class OrdenServicio
    {
        
        public List<string> IdEncargadoDiagnostico {get; set;}
        public string IdCliente {get; set;}
        public List<string> IdEmpleado {get; set;}
        public string Placa {get; set;}
        public string NroOrden {get; set;}
        public DateTime FechaOrden {get; set;}
        public List<string> Diagnostico {get; set;}
        public List<Repuesto> ListaRepuestos {get; set;}

        public OrdenServicio(string _NroOrden, string _IdCliente,List<string> _IdEmpleado,  string _Placa, DateTime _FechaOrden, List<string> _Diagnostico,List<string> _IdEncargadoDiagnostico,List<Repuesto> _ListaRepuestos)
        {
            this.IdEncargadoDiagnostico = _IdEncargadoDiagnostico;
            this.IdCliente = _IdCliente;
            this.IdEmpleado = _IdEmpleado;
            this.Placa = _Placa;
            this.NroOrden = _NroOrden;
            this.FechaOrden = _FechaOrden;
            this.Diagnostico = _Diagnostico;
            this.ListaRepuestos = _ListaRepuestos;
        }
        
        public static  OrdenServicio AgregarOrdenServicio(List<Empleado> listaEmpleados,List<Cliente> listaClientes,string nroOrden){
            List<string> listaCcEmpleado = new();
            List<string> listaDiagnostico = new();
            List<string> ListaRepuestosDiagnostico = new();
            List<string> IdEncargadoDiagnostico = new();
            List<Repuesto> listaRepuestos = new();
            Console.Clear();
            Cliente.MostrarClienteGlobal(listaClientes);
            Console.WriteLine("Ingrese la cedula del Cliente: ");
            string cedulaCliente = Console.ReadLine();
            Cliente cliente = listaClientes.Find(c => c.Cedula == cedulaCliente);
            bool seguir = true;
            do
            {
                Console.WriteLine("Desea agregar un Empleado a la orden de servicio?(S:si/N:no) :");
                string opcionAgregarEmpleado = Console.ReadLine();
                
                if (opcionAgregarEmpleado.ToUpper() == "S"){
                    Empleado.MostrarEmpleadoGlobal(listaEmpleados);
                    Console.WriteLine("Ingrese la cedula del empleado que trabajara en la orden de servicio");
                    string ccEmpleado = Console.ReadLine();
                    Empleado empleadoContratado = listaEmpleados.Find(empleado => empleado.Cedula == ccEmpleado);
                    if (empleadoContratado != null)
                    {
                        listaCcEmpleado.Add(ccEmpleado);
                        Console.WriteLine("El empleado dara su opinion de experto en su area ?(S:si/N:no) :");
                        string opcionAgregarDiagnostico = Console.ReadLine();
                        if (opcionAgregarDiagnostico.ToUpper() == "S"){
                            IdEncargadoDiagnostico.Add(ccEmpleado);
                            Console.WriteLine("Ingrese el diagnostico del Empleado Experto");
                            string diagnostico = Console.ReadLine();
                            listaDiagnostico.Add(diagnostico);
                            bool seguirRepuesto = true;
                            do{
                                Console.WriteLine("Desea agregar un Repuesto del diagnostico anterior a la orden de servicio?(S:si/N:no) :");
                                string opcionAgregarRepuesto = Console.ReadLine();
                                if (opcionAgregarRepuesto.ToUpper() == "S"){
                                    listaRepuestos.Add(Repuesto.AgregarRepuesto(nroOrden, ccEmpleado));
                                }else if(opcionAgregarRepuesto.ToUpper() == "N"){
                                    if (ListaRepuestosDiagnostico == null)
                                    {
                                        Console.WriteLine("tiene que ingresar por lo menos un repuesto, o si no, dañe algo e ingreselo");
                                    }else{
                                        seguirRepuesto = false;
                                    }
                                }
                                else{
                                    Console.WriteLine("Opción no valida");
                                }
                            }while(seguirRepuesto);
                            
                            
                            
                        }else if(opcionAgregarDiagnostico.ToUpper() == "N"){
                            if (listaDiagnostico == null)
                                {
                                    Console.WriteLine("tiene que ingresar por lo menos un Diagnostico, o si no, dañe algo e ingreselo");
                                }else{
                                    seguir = false;
                                }
                        }
                        else{
                            Console.WriteLine("Opción no valida");
                        }
                    }else{
                        Console.WriteLine("El empleado no existe");
                    }
                }else if(opcionAgregarEmpleado.ToUpper() == "N"){
                    seguir = false;
                }
                else{
                    Console.WriteLine("Opción no valida");
                }
            } while (seguir);
            Cliente.MostrarClienteVehiculos(listaClientes,cliente.Cedula);
            Console.WriteLine("Ingrese la Placa del vehiculo del cliente : ");
            string placa = Console.ReadLine();
            DateTime fechaActual = DateTime.Now;
            OrdenServicio nuevaOrdenServicio = new(nroOrden,cedulaCliente, listaCcEmpleado, placa,fechaActual, listaDiagnostico,IdEncargadoDiagnostico, listaRepuestos);
            return nuevaOrdenServicio;
        }
        public static void MostrarOrdenServicio(List<OrdenServicio> listaOrdenServicio,List<Empleado> listaEmpleados, List<Cliente> listaClientes)
        {
            OrdenServicio.MostrarOrdenServicioGlobal(listaOrdenServicio);
            Console.Write("Ingrese el numero de orden de la orden de servicio: ");
            string nroOrden = Console.ReadLine();
            OrdenServicio ordenServicio = listaOrdenServicio.Find(ordendeservicio => ordendeservicio.NroOrden == nroOrden);
            Cliente clienteEspecifico = listaClientes.Find(cliente => cliente.Cedula == ordenServicio.IdCliente);

            Console.WriteLine("************************************************************************************************");
            Console.WriteLine("*                                    Datos de la Orden                                          ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"* Nro Orden: {ordenServicio.NroOrden,-41}Fecha Orden: {ordenServicio.FechaOrden,-8} ");
            Console.WriteLine($"* Id Cliente: {clienteEspecifico.Cedula,-40}Nombre Cliente: {clienteEspecifico.Nombre,-12} ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");
            Console.WriteLine("*                                    Datos Vehiculo                                             ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"* Nro Placa: {ordenServicio.Placa,-42}Km Actual: {clienteEspecifico.Vehiculos.Find(vehiculo => vehiculo.Placa == ordenServicio.Placa)?.Km.LastOrDefault(),-13} ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");
            Console.WriteLine("*                                    Personal a Cargo                                           ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");

            foreach (string idEmpleado in ordenServicio.IdEmpleado)
            {
                Empleado empleadoEspecifico = listaEmpleados.Find(empleado => empleado.Cedula == idEmpleado);
                if (empleadoEspecifico != null)
                {
                    Console.WriteLine($"* Nro CC: {empleadoEspecifico.Cedula,-40}Nombre: {empleadoEspecifico.Nombre,-27} ");
                    Console.WriteLine($"* Especialidad: {empleadoEspecifico.Especialidad,-59} ");
                    Console.WriteLine("*-----------------------------------------------------------------------------------------------");
                }
            }

            Console.WriteLine("*                                    Diagnostico Experto                            ");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------");

            foreach (string idEncargadoDiagnostico in ordenServicio.IdEncargadoDiagnostico)
            {
                Empleado empleadoDiagnostico = listaEmpleados.Find(empleado => empleado.Cedula == idEncargadoDiagnostico);
                if (empleadoDiagnostico != null)
                {
                    Console.WriteLine($"* Nro CC: {empleadoDiagnostico.Cedula,-40}Nombre: {empleadoDiagnostico.Nombre,-27} ");
                    int index = ordenServicio.IdEncargadoDiagnostico.IndexOf(idEncargadoDiagnostico);
                    Console.WriteLine($"* Diagnostico: {ordenServicio.Diagnostico[index],-56} ");                    
                    Console.WriteLine($"* Lista de repuestos:");
                    foreach (Repuesto repuesto in ordenServicio.ListaRepuestos)
                    {
                        if (repuesto.IdEmpleado == idEncargadoDiagnostico)
                        {
                            Console.WriteLine($"*     - {repuesto.Nombre,-57} ");
                        }
                    }
                    
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
            }
            


            Console.WriteLine();
        }


        public static void MostrarOrdenServicioGlobal(List<OrdenServicio> listaOrdenServicio)
        {
            Console.Clear();
            Console.WriteLine($"Nro Orden\tCedula Cliente");
            foreach (OrdenServicio ordenServicio in listaOrdenServicio)
            {
                Console.WriteLine($"{ordenServicio.NroOrden}\t\t{ordenServicio.IdCliente}");
            }
            Console.WriteLine();
        }
    }
