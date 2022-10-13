//Tabla de Medicamentos/Notificaciones

namespace Alzapp.Models
{
    using SQLite;
    using System;
    public class Medicamentos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        [MaxLength(50)]
        public string Titulo { get; set; }

        [MaxLength(50)]
        public string Mensaje { get; set; }
        [MaxLength(50)]
        public string Unidad { get; set; }
        [MaxLength(50)]
        public string Cantidad { get; set; }

        public string ImageUrl { get; set; }

        //public bool Repeat { get; set; }
        public DateTime DatePicker { get; set; }

        public TimeSpan TimePicker { get; set; }
        public int IdNotificacion { get; set; }
    }
}
