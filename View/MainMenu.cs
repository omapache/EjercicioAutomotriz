namespace EjercicioAutomotriz.View;

    public class MainMenu
    { 
        public MainMenu(){}
        public static int Menu(){
            Console.Clear();
            Console.WriteLine("WENAS, BIENVENIDO A REPARACIONES AUTOMISHIS");
            Console.WriteLine("elija la opcion adecuada:");
            Console.WriteLine("1) Registro");
            Console.WriteLine("2) Consulta de Datos");
            Console.WriteLine("3) Crear Orden de Servicio");
            Console.WriteLine("4) Crear Orden de Aprobacion");
            Console.WriteLine("5) Crear Factura");
            Console.WriteLine("6) Salir");
            return int.Parse(Console.ReadLine());
        }   
    }
