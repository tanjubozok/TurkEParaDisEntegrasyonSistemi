using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using static TurkEParaDisEntegrasyonSistemi.Models.Integration;

namespace TurkEParaDisEntegrasyonSistemi.Controllers
{
    public class HomeController : Controller
    {
        public TURKTokenResult GetToken()
        {
            TURKTokenResult turkTokenResult = new TURKTokenResult();

            try
            {
                using (var http = new HttpClient())
                {
                    TURKToken turkToken = new TURKToken
                    {
                        T = "10738",
                        P = "test",
                        U = "test"
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(turkToken));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var request = http.PostAsync("https://test-dmz.param.com.tr:4443/API/HE/TKN", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TURKTokenResult>(response);

                    if (result.Sonuc_Ack == "Success" && result.Sonuc == "1")
                    {
                        turkTokenResult.Sonuc = result.Sonuc;
                        turkTokenResult.Sonuc_Ack = result.Sonuc_Ack;
                        turkTokenResult.TKN = result.TKN;
                        return turkTokenResult;
                    }
                    return turkTokenResult;
                }
            }
            catch (Exception)
            {
                return turkTokenResult;
            }
        }

        public TURKHareketResult AccountTransactions()
        {
            TURKHareketResult turkHareketResult = new TURKHareketResult();
            Hareket hareket = new Hareket();

            var getToken = GetToken();

            try
            {
                using (var http = new HttpClient())
                {
                    TURKHareket turkHareket = new TURKHareket
                    {
                        TKN = getToken.TKN,
                        Kisi_TC = "11111111111",
                        Tutar = "1.15",
                        Banka_Kodu = "10",
                        Tarih = "21.05.2020"
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(turkHareket));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var request = http.PostAsync("https://test-dmz.param.com.tr:4443/API/HE/HAREKET", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TURKHareketResult>(response);

                    if (result.Sonuc_Ack == "Başarılı" && result.Sonuc == "1")
                    {
                        turkHareketResult.Sonuc = result.Sonuc;
                        turkHareketResult.Sonuc_Ack = result.Sonuc_Ack;

                        foreach (var item in result.Hareket)
                        {
                            hareket.Durum_Ack = item.Durum_Ack;
                            hareket.Dekont_ID = item.Dekont_ID;
                            hareket.Kisi_TC = item.Kisi_TC;
                            hareket.Aciklama = item.Aciklama;
                            hareket.Tutar = item.Tutar;
                        }
                        return turkHareketResult;
                    }
                    return turkHareketResult;
                }
            }
            catch (Exception)
            {
                return turkHareketResult;
            }
        }

        public TURKBankListResult BankList()
        {
            TURKBankListResult turkBankListResult = new TURKBankListResult();
            BankaListesi bankList = new BankaListesi();
            var getToken = GetToken();

            try
            {
                using (var http = new HttpClient())
                {
                    TURKBankList turkBankList = new TURKBankList()
                    {
                        TKN = getToken.TKN
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(turkBankList));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var request = http.PostAsync("https://test-dmz.param.com.tr:4443/API/HE/BANKALISTESI", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TURKBankListResult>(response);

                    if (result.Sonuc_Ack == "Başarılı" && result.Sonuc == "1")
                    {
                        turkBankListResult.Sonuc = result.Sonuc;
                        turkBankListResult.Sonuc_Ack = result.Sonuc_Ack;

                        foreach (var item in result.BankaListesi)
                        {
                            bankList.Banka_Kodu = item.Banka_Kodu;
                            bankList.Banka_Adi = item.Banka_Adi;
                        }
                        return turkBankListResult;
                    }
                    return turkBankListResult;
                }
            }
            catch (Exception)
            {
                return turkBankListResult;
            }
        }
    }
}