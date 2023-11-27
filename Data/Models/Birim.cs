using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NurusMES.Data.Models
{
    public class Birim
    {
        public int BirimID { get; set; }

        public string BirimAdi { get; set; }

        public List<Makine> Makines { get; set; }

    }
}
