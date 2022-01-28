using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Model
{
    [Table("Musteri")]
    public class Musteri
    {
        [Key]
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string telefon { get; set; }
        public string plaka { get; set; }
        public ICollection<Islem> Islem { get; set; }

    }
}