namespace Espacio.Personaje{
    public class Personaje{
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        private string? tipo;
        private string? nombre;
        private string? apodo;
        private DateTime fecha_nacimiento;
        public int Destreza { get => destreza; set => destreza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime Fecha_Nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
    }
}