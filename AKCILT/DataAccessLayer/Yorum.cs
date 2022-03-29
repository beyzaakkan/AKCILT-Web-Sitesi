using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public string Uye { get; set; }
        public int YaziID { get; set; }
        public string Yazi { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool OnayDurum { get; set; }
    }
}
