using System.ComponentModel.DataAnnotations;

namespace NurusMES.Data.Models
{
    public class IsEmri
    {
        [Key]
        public int IsEmriID { get; set; }

        public string SiparisAdi { get; set; }

        public int BirimID { get; set; }

        public int MakineID { get; set; }

        public int PersonelID { get; set; }

        public int SiparisMiktari { get; set; }

        public int TahminToplamSure { get; set; }

        public string Aciklama { get; set; }

       


        //Geçen süre hesabı yapmak için
        public DateTime IsEmriBaslangic { get; set; }

        public DateTime IsEmriBitis { get; set; }

        public virtual Duruslar Duruslar { get; set; }

        public List<Vardiya> Vardiyas { get; set; }



    }
}
