//Tabla de Personas Importantes

namespace Alzapp.Models
{
    using SQLite;
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Domicilio { get; set; }
        [MaxLength(50)]
        public string Relacion { get; set; }
        [MaxLength(50)]
        public string Celular { get; set; }

        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
    }

}
