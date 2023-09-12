using System.ComponentModel.DataAnnotations;

namespace NurusMES.Data.Models
{
    public class Duruslar
    {
        [Key]
        public int DurusID { get; set; }

        public string DurusAdi { get; set; }

        public string DurusTuru { get; set; }

        public string DurusNedeni { get; set; }

        public string DurusNedeniDetay { get; set; }

        public string VarsayilanSure { get; set; }

        public int PersonelID { get; set; }

        public int MakineID { get; set; }

        public int BirimID { get; set; }

        public virtual Personel Personel { get; set; }

        public List <IsEmri> IsEmris { get; set; }

    }
}
