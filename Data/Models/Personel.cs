using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NurusMES.Data.Models
{
    public class Personel
    {

        public int PersonelID { get; set; }

        public string PersonelAdSoyad { get; set; }

        public string Sifre { get; set; }

        public int MakineID { get;set; }

        public int BirimID { get; set; }

        public char Admin { get; set; }

        public virtual Makine Makine { get; set; }

        public virtual Birim Birim { get; set; }

        public List<Duruslar> Duruslars { get; set; }


    }
}
