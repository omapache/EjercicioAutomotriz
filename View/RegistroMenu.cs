namespace EjercicioAutomotriz.View;
    public class RegistroMenu
    {
        public RegistroMenu(){}

        public static int MenuRegistrar()
        {
            Console.Clear();
            Console.WriteLine("elija la opcion adecuada:");
            Console.WriteLine("1) registro Cliente");
            Console.WriteLine("2) registro Empleado");
            Console.WriteLine("3) Modificar Kilometraje");
            Console.WriteLine("4) regresar menu principal");

            return int.Parse(Console.ReadLine());
        }
    }
