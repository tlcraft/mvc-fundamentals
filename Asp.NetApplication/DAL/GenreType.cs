using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class GenreType
    {
        [Column(nameof(GenreType) + "Id")]
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
