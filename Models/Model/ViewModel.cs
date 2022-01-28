using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Model
{
    public class ViewModel
    {
        public List<Islem> islem { get; set; }
        public List<Hizmet> hizmet { get; set; }
        public List<Musteri> musteri { get; set; }
        public ViewModel()
        {
            hizmet = new List<Hizmet>();
        }
        public List<IslemHizmet> islemhizmet { get; set; }
    }
    
}