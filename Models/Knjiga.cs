using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ServerProj.Models
{
    [Table("Knjiga")]
    public class Knjiga
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ImeKnjige")]
        [MaxLength(255)]
        public string ImeKnjige { get; set; }

        [Column("ImeAutora")]
        [MaxLength(255)]
        public string ImeAutora { get; set; }
        
        [Column("BojaKnjige")]
        public string BojaKnjige { get; set; }

        [JsonIgnore]
        public Polica Polica { get; set; }

    }
}