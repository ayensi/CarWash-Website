using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Model
{
    [Table("Islem")]
    public class Islem
    {
        [Key]
        public int islem_id { get; set; }
        public string plaka { get; set; }
        public DateTime giristarihi { get; set; }
        public DateTime? cikistarihi { get; set; }
        public bool onay { get; set; }
        public int toplamfiyat { get; set; }
        public ICollection<IslemHizmet> IslemHizmet { get; set; }
        public Musteri Musteri { get; set; }
    }
}