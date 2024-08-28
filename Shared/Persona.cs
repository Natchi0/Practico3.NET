namespace Shared
{
    public class Persona
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        public string Apellidos { get; set; } = "";
        public int Telefono { get; set; } = 0;
        public string Direccion { get; set; } = "";
        public DateOnly FechaNacimiento { get; set; }
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        public string GetString()
        {
            return $"Id: {Id}, Documento: {documento}, Nombre: {Nombre} - {Apellidos}, Telefono: {Telefono}, Direccion: {Direccion}, Nacimiento: {FechaNacimiento}";
        }
    }
}
