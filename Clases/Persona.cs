namespace EjercicioAutomotriz.Clases;
    public class Persona
    {
        public string Cedula {get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroMovil { get; set; }
        public string Email { get; set; }

        public Persona(string _Cedula, string _Nombre, string _Apellido, string _NroMovil, string _Email){
            this.Cedula = _Cedula;
            this.Nombre = _Nombre;
            this.Apellido = _Apellido;
            this.NroMovil = _NroMovil;
            this.Email = _Email;
        }
    }
        