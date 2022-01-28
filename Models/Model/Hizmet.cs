using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Model
{
    [Table("Hizmet")]
    public class Hizmet
    {
        [Key]
        public int hizmet_id { get; set; }
        public string hizmetisim { get; set; }
        [Required]
        public bool isChecked { get; set; }
        public int fiyat { get; set; }
        public ICollection<IslemHizmet> IslemHizmet { get; set; }
    }
}