using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NurusMES.Data.Models
{
    public class Vardiya
    {
        [Key]
        public int VardiyaID { get; set; }

        public string VardiyaAdi { get; set; }

        public TimeSpan VardiyaBaslangic { get; set; }

        public TimeSpan VardiyaBitis { get; set; }

        public virtual IsEmri IsEmri { get; set; }
    }
}
