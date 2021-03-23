using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerProj.Models
{
    [Table("Biblioteka")]
    public class Biblioteka
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv Biblioteke")]
        [MaxLength(255)]
        public string NazivBiblioteke { get; set; }

        public virtual List<Polica> Police { get; set; }
        // public virtual List<Knjiga> Knjige { get; set; }
    }
}