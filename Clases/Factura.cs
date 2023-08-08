namespace EjercicioAutomotriz.Clases;

    public class Factura
    {
        public string Id {get; set;}
        public string IdOrdenServicio {get; set;}
        public float Iva {get; set;}
        public float ValorManoObra {get; set;}
        public DateTime Fecha {get; set;}


        public Factura(string _Id, string _IdOrdenServicio, DateTime _Fecha){
            this.Id = _Id;
            this.IdOrdenServicio = _IdOrdenServicio;
            this.Iva = 19.0F;
            this.ValorManoObra = 10.0F;
            this.Fecha = _Fecha;
        }
        
        public static Factura HacerFactura(List<OrdenServicio> listaOrdenesServicio, string id)
        {
            Console.Clear();
            OrdenServicio.MostrarOrdenServicioGlobal(listaOrdenesServicio);
            Console.WriteLine("Ingrese el ID de la orden de servicio: ");
            string idOrdenServicio = Console.ReadLine();

            OrdenServicio ordenServicio = listaOrdenesServicio.Find(orden => orden.NroOrden.Equals(idOrdenServicio));
            if (ordenServicio != null)
            {
                Factura nuevaFactura = new(id, idOrdenServicio, DateTime.Now);
                return nuevaFactura;
            }
            else
            {
                Console.WriteLine("No se encontró la orden de servicio con el ID proporcionado.");
                return null;
            }
        }
        public static void MostrarFacturasGlobal(List<Factura> listaFacturas)
        {
            Console.WriteLine("Facturas Globales");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Nro Factura\t|\tFecha de Creación");
            Console.WriteLine("-------------------------------------------------------");

            foreach (Factura factura in listaFacturas)
            {
                Console.WriteLine($"{factura.Id}\t\t|\t{factura.Fecha}");
            }

            Console.WriteLine("-------------------------------------------------------");
        }

       
        public static void MostrarFacturaEspecifica(List<OrdenServicio> listaOrdenesServicio,List<Factura> listaFacturas)
        {
            MostrarFacturasGlobal(listaFacturas);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Ingrese el ID de la factura para ver los detalles: ");
            string idFactura = Console.ReadLine();
            Factura facturaSeleccionada = listaFacturas.Find(factura => factura.Id.Equals(idFactura));
            OrdenServicio facturaOrdenServicio = listaOrdenesServicio.Find(ordenservicio => ordenservicio.NroOrden.Equals(facturaSeleccionada.IdOrdenServicio));
            if (facturaSeleccionada != null)
            {
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("                                                    Factura");
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"Nro Orden: {facturaOrdenServicio.NroOrden,-50}Nro Factura: {facturaSeleccionada.Id}");
                Console.WriteLine($"Id Cliente: {facturaOrdenServicio.IdCliente,-67}");
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("                                            Detalle Factura");
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("Item           | Repuesto           | Valor unitario         | Cantidad         | Sub total");
                Console.WriteLine("               |                    |                        |                  |");

                float subtotalRepuestos = 0.0F;
                foreach (Repuesto repuesto in facturaOrdenServicio.ListaRepuestos)
                {
                    if (repuesto.Estado)
                    {
                        float subTotalRepuesto = repuesto.ValorUnitario * repuesto.Cantidad;
                        Console.WriteLine($"{repuesto.Id,-14} |{repuesto.Nombre,-19} | {repuesto.ValorUnitario,-22} | {repuesto.Cantidad,-16} | {subTotalRepuesto,-14}");
                        subtotalRepuestos += subTotalRepuesto;
                    }
                }
                float iva = subtotalRepuestos * (facturaSeleccionada.Iva / 100);
                float totalPagar = subtotalRepuestos + facturaSeleccionada.ValorManoObra + iva;
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"Sub Total: {subtotalRepuestos:C2}");
                Console.WriteLine($"Iva: {facturaSeleccionada.Iva}%");
                Console.WriteLine($"Valor mano de Obra: {facturaSeleccionada.ValorManoObra}");
                Console.WriteLine($"Total Pagar: {totalPagar}");
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No se encontró la factura con el ID proporcionado.");
            }
        }
    }
