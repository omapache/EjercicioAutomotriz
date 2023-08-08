using EjercicioAutomotriz.View;
using EjercicioAutomotriz.Clases;
internal class Program
{
    private static void Main()
    {   
        List<Cliente> listaClientes = new();
        List<Empleado> listaEmpleados = new();
        List<OrdenServicio> listaOrdenServicio = new();
        List<OrdenAprobacion> listaAprobacion = new();
        List<Factura> listaFactura = new();

        int nextIdOrdenServicio = 0; 
        int nextIdOrdenAprobacion = 0; 
        int nextIdOrdenFactura = 0; 
        int opcion = 0;

        static string GenerateNextId(int id){
            int newIdValue = id + 1;
            string newId = newIdValue.ToString();
            return newId;
        }

        do
        {
            switch(opcion)
            {
                case 1:
                    int opcionRegistro = 0;
                    do
                    {
                        switch (opcionRegistro)
                        {
                            case 1:
                                listaClientes.Add(Cliente.AgregarCliente());
                                Cliente.MostrarClienteGlobal(listaClientes);
                                Console.ReadKey();
                                break;
                            case 2:
                                listaEmpleados.Add(Empleado.AgregarEmpleado());
                                Empleado.MostrarEmpleadoGlobal(listaEmpleados);
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }

                        opcionRegistro = RegistroMenu.MenuRegistrar();

                    } while (opcionRegistro != 3);
                    break;
                case 2:
                    int opcionConsulta = 0;
                    do
                    {
                        switch (opcionConsulta)
                        {
                            case 1:
                                Cliente.MostrarClienteGlobal(listaClientes);
                                Console.ReadKey();
                                break;
                            case 2:
                                Cliente.MostrarClienteGlobal(listaClientes);
                                Cliente.MostrarClienteEspecifico(listaClientes);
                                Console.ReadKey();
                                break;
                            case 3:
                                Empleado.MostrarEmpleadoGlobal(listaEmpleados);
                                Console.ReadKey();
                                break;
                            case 4:
                                Empleado.MostrarEmpleadoGlobal(listaEmpleados);
                                Empleado.MostrarEmpleadoEspecifico(listaEmpleados);
                                Console.ReadKey();
                                break;
                            case 5:
                                OrdenServicio.MostrarOrdenServicio(listaOrdenServicio,listaEmpleados,listaClientes);
                                Console.ReadKey();
                                break;
                            case 6:
                                OrdenAprobacion.MostrarDetalleAprobacion(listaAprobacion,listaEmpleados);
                                Console.ReadKey();
                                break;
                            case 7:
                                Factura.MostrarFacturaEspecifica(listaOrdenServicio,listaFactura);
                                Console.ReadKey();
                                break;
                            
                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }
                        opcionConsulta = ConsultaDatos.MenuConsulta();
                    } while (opcionConsulta != 8);
                    break;
                case 3:
                    listaOrdenServicio.Add(OrdenServicio.AgregarOrdenServicio(listaEmpleados,listaClientes, GenerateNextId(nextIdOrdenServicio)));
                    break;
                case 4:
                    listaAprobacion.Add(OrdenAprobacion.AgregarOrdenAprobacion(listaOrdenServicio,GenerateNextId(nextIdOrdenAprobacion)));
                    OrdenAprobacion.AprobarRepuestos(listaAprobacion);
                    break;
                case 5:
                    listaFactura.Add(Factura.HacerFactura(listaOrdenServicio,GenerateNextId(nextIdOrdenFactura)));
                    break;
                default:
                    Console.WriteLine("opcion invalida");
                    break;
            }
            
            opcion = MainMenu.Menu();
        } while (opcion != 6);
    }
}