using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Tc Kimlik Numaranýzý Giriniz\nSecim :  ");
        string tckimlik = Console.ReadLine().ToUpper(); // Upper olmazsa Api yanýtý herzaman false olur.

        Console.Write("Adýnýzý Giriniz\nSecim :  ");
        string ad = Console.ReadLine().ToUpper();

        Console.Write("Soyadýnýzý Giriniz\nSecim :  ");
        string soyad = Console.ReadLine().ToUpper();

        Console.Write("Doðum yýlýnýzý giriniz\nSecim :  ");
        string dogumyili = Console.ReadLine().ToUpper();


        // XML þablonunda gönderilecek veri. "@" olmazsa hata verir. "$" formatlamak içindir.
        string soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
      <TCKimlikNo>{tckimlik}</TCKimlikNo>
      <Ad>{ad}</Ad>
      <Soyad>{soyad}</Soyad>
      <DogumYili>{dogumyili}</DogumYili>
    </TCKimlikNoDogrula>
  </soap:Body>
</soap:Envelope>";


        var httpclient = new HttpClient(); // http client oluþturma.

        var requestcontent = new StringContent(soapRequest, Encoding.UTF8, "text/xml"); // Xml veri gönderdiðimiz için text/xml ifadezsini kullandým. Json verilerde application/json ifadesi kullanýlýyor.

        try
        {
            var request = await httpclient.PostAsync("https://tckimlik.nvi.gov.tr/service/kpspublic.asmx", requestcontent); // Pythonda kullandýðýmýz request.post(url , data=data) kodunun aynýsý. await methodu gönderene kadar bekliyor.

            if (request.IsSuccessStatusCode) // 200 ile 206 arasý status code'lar genellikle baþarýlý olur.
            {
                string requestokuma = await request.Content.ReadAsStringAsync(); // Request'in response'unu okuyana kadar bekleyen kod.

                if (requestokuma.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>")) // true or false
                {

                    Console.WriteLine("Kimlik bilgileriniz doðru.");
                    // Konsol hemen kapanýyorsa Console.Read(); kullanabilirsiniz.
                }
                else
                {
                    Console.WriteLine("Kimlik bilgileriniz yanlýþ");

                }
            }
            else
            {
                Console.WriteLine("Bir Sorun Oluþtu :  " + request.StatusCode); // Status Code ile ilgili daha fazla bilgi almak için https://tr.wikipedia.org/wiki/HTTP_durum_kodlar%C4%B1
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir Sorun Oluþtu :  " + ex.Message);
        }



    }
}