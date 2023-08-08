namespace EjercicioAutomotriz.Clases;

    public class OrdenAprobacion
    {
        public string Id {get; set;}
        public string IdOrdenServicio {get; set;}
        public DateTime Fecha {get; set;}
        public List<Repuesto> ListaRepuestos {get; set;}

        public OrdenAprobacion(string _Id, string _IdOrdenServicio, DateTime _Fecha, List<Repuesto> _ListaRepuestos)
        {
            this.Id = _Id;
            this.IdOrdenServicio = _IdOrdenServicio;
            this.Fecha = _Fecha;
            this.ListaRepuestos = _ListaRepuestos;
        }
        public static OrdenAprobacion AgregarOrdenAprobacion(List<OrdenServicio> listaOrdenesServicio, string id)
        {
            Console.Clear();
            OrdenServicio.MostrarOrdenServicioGlobal(listaOrdenesServicio);
            Console.WriteLine("Ingrese el ID de la orden de servicio: ");
            string idOrdenServicio = Console.ReadLine();

            OrdenServicio ordenServicio = listaOrdenesServicio.Find(orden => orden.NroOrden.Equals(idOrdenServicio));
            if (ordenServicio != null)
            {
                OrdenAprobacion nuevaOrdenAprobacion = new(id, idOrdenServicio, DateTime.Now, ordenServicio.ListaRepuestos);
                return nuevaOrdenAprobacion;
            }
            else
            {
                Console.WriteLine("No se encontró la orden de servicio con el ID proporcionado.");
                return null;
            }
        }
        
        public static void AprobarRepuestos(List<OrdenAprobacion> listaAprobacion)
        {
            
                foreach (OrdenAprobacion ordenAprobacion in listaAprobacion)
                {
                    ordenAprobacion.MostrarRepuestosParaAprobacion(); 
                    Console.WriteLine("Aprobación de Repuestos:");
                    foreach (Repuesto repuesto in ordenAprobacion.ListaRepuestos)
                    {
                        Console.WriteLine($"Nombre del Repuesto: {repuesto.Nombre}");
                        Console.Write("¿Desea aprobar este repuesto? (S: sí / N: no): ");
                        string respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() == "S")
                        {
                            repuesto.Estado = true;
                            Console.WriteLine($"Repuesto '{repuesto.Nombre}' aprobado.");
                        }
                        else
                        {
                            repuesto.Estado = false;
                            Console.WriteLine($"Repuesto '{repuesto.Nombre}' rechazado.");
                        }
                    }
                }
            
        }
        public void MostrarRepuestosParaAprobacion()
        {
            Console.WriteLine("Repuestos para Aprobación:");
            for (int i = 0; i < ListaRepuestos.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {ListaRepuestos[i].Nombre}");
            }
        }
        public static void MostrarOrdenServicioGlobal(List<OrdenAprobacion> listaAprobacion)
        {
            Console.Clear();
            Console.WriteLine($"Nro Orden de la aprobacion\tNro Orden de servicio");
            foreach (OrdenAprobacion ordenAprobacion in listaAprobacion)
            {
                Console.WriteLine($"{ordenAprobacion.Id}\t\t\t\t\t\t{ordenAprobacion.IdOrdenServicio}");
            }
            Console.WriteLine();
        }
        public static void MostrarDetalleAprobacion(List<OrdenAprobacion> listaAprobacion, List<Empleado> listaEmpleados)
        {
            MostrarOrdenServicioGlobal(listaAprobacion); 
            Console.Write("Ingrese el número de orden (ID) para ver el detalle: ");
            string idOrden = Console.ReadLine();

            OrdenAprobacion ordenSeleccionada = listaAprobacion.Find(o => o.Id == idOrden);

            if (ordenSeleccionada != null)
            {
                Console.Clear();
                Console.WriteLine($"Detalles de la Orden de Aprobación: {ordenSeleccionada.Id}");
                Console.WriteLine("**********************************************************************************************");
                Console.WriteLine("Nro Orden:\t\tFecha:\t\tid Empleado:");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{ordenSeleccionada.IdOrdenServicio,-16}\t{ordenSeleccionada.Fecha,-16}\t{ordenSeleccionada.Id,-12}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("item\t|       Repuesto\t|    valor unit\t|    valor total\t|    estado");
                Console.WriteLine("    \t|               \t|              \t|               \t|");

                foreach (Repuesto repuesto in ordenSeleccionada.ListaRepuestos)
                {
                    Empleado empleado = listaEmpleados.Find(e => e.Cedula == repuesto.IdEmpleado);

                    float valorTotal = repuesto.ValorUnitario * repuesto.Cantidad;
                    string estado = repuesto.Estado ? "Aprobado" : "Rechazado";

                    Console.WriteLine($"{ordenSeleccionada.ListaRepuestos.IndexOf(repuesto) + 1}\t| {repuesto.Nombre}\t| {repuesto.ValorUnitario}\t| {valorTotal}\t| {estado}");
                }

                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna orden de aprobación con el ID: {idOrden}");
            }
        }




    }