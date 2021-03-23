using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ServerProj.Models
{
    [Table("Polica")]
    public class Polica
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Ime Police")]
        [MaxLength(255)]
        public string ImePolice { get; set; }

        [Column("MaksimalniBrKnjiga")]
        public int MaksBrKnjiga { get; set; }

        [JsonIgnore]
        public Biblioteka Biblioteka { get; set; } //pokazivac na prvu klasu

        public virtual List<Knjiga> Knjige { get; set; }
    }
}