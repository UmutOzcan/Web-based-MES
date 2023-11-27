using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NurusMES.Data.Models
{
    public class Makine
    {
        public int MakineID { get; set; }

        public string MakineAdi { get; set; }

        // varsayilan sure tanımı eklenecek

        public int BirimID { get; set; }

        public virtual Birim Birim { get; set; }

        public List<Personel> Personels { get; set; }

    }
}
