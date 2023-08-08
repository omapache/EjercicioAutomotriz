namespace EjercicioAutomotriz.View;

    public class ConsultaDatos
    {
        public ConsultaDatos(){}

       public static int MenuConsulta()
        {
            Console.Clear();
            Console.WriteLine("elija la opcion adecuada:");
            Console.WriteLine("1) Consulta Clientes Globales");
            Console.WriteLine("2) Consulta Clientes Especifico");
            Console.WriteLine("3) Consulta Empleados Globales");
            Console.WriteLine("4) Consulta Empleados Especifico");
            Console.WriteLine("5) Consulta Orden de Servicios");
            Console.WriteLine("6) Consulta Orden de Aprobacion");
            Console.WriteLine("7) Consulta Factura");
            Console.WriteLine("8) regresar menu principal");
            return int.Parse(Console.ReadLine());
        } 
    }
