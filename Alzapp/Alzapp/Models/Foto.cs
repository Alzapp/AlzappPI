

namespace Alzapp.Models
{
    using SQLite;
    public class Foto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Etapa { get; set; }

        public string ImageUrl { get; set; }
    }
}
