using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Model
{
    [Table("IslemHizmet")]
    public class IslemHizmet
    {
        [Key]
        public int islemhizmetid { get; set; }
        public int islem_id { get; set; }
        public int hizmet_id { get; set; }
        public Hizmet Hizmet { get; set; }
        public Islem Islem { get; set; }
    }
}