using System.Collections.Generic;

namespace TurkEParaDisEntegrasyonSistemi.Models
{
    public static class Integration
    {
        public class TURKToken
        {
            public string T { get; set; }
            public string U { get; set; }
            public string P { get; set; }
        }

        public class TURKTokenResult
        {
            public string Sonuc { get; set; }
            public string Sonuc_Ack { get; set; }
            public string TKN { get; set; }
        }

        public class TURKHareket
        {
            public string TKN { get; set; }
            public string Kisi_TC { get; set; }
            public string Tutar { get; set; }
            public string Banka_Kodu { get; set; }
            public string Tarih { get; set; } //dd.MM.yyyy  format
        }

        public class TURKHareketResult
        {
            public string Sonuc { get; set; }
            public string Sonuc_Ack { get; set; }
            public List<Hareket> Hareket { get; set; }
        }

        public class Hareket
        {
            public string Durum_Ack { get; set; }
            public string Dekont_ID { get; set; }
            public string Kisi_TC { get; set; }
            public string Aciklama { get; set; }
            public string Tutar { get; set; }
        }

        public class TURKBankList
        {
            public string TKN { get; set; }
        }

        public class TURKBankListResult
        {
            public string Sonuc { get; set; }
            public string Sonuc_Ack { get; set; }
            public List<BankaListesi> BankaListesi { get; set; }
        }

        public class BankaListesi
        {
            public string Banka_Adi { get; set; }
            public string Banka_Kodu { get; set; }
        }
    }
}