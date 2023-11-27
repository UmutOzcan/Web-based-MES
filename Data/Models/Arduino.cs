namespace NurusMES.Data.Models
{
    public class Arduino
    {

        public int ArduinoID { get; set; }

        public string ArduinoDurumu { get; set; }

        public string MakineAdi { get; set; }

        public int MakineID { get; set;}

        public virtual Makine Makine { get; set; }

    }
}
