

namespace Alzapp.Models
{
    using SQLite;
    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string Dia { get; set; }


        public string Manana { get; set; }


        public string Tarde { get; set; }


        public string Noche { get; set; }

        public string Actividad { get; set; }
        public string Actividad2 { get; set; }
    }
}

