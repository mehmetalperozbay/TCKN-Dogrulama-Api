using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Tc Kimlik Numaran�z� Giriniz\nSecim :  ");
        string tckimlik = Console.ReadLine().ToUpper(); // Upper olmazsa Api yan�t� herzaman false olur.

        Console.Write("Ad�n�z� Giriniz\nSecim :  ");
        string ad = Console.ReadLine().ToUpper();

        Console.Write("Soyad�n�z� Giriniz\nSecim :  ");
        string soyad = Console.ReadLine().ToUpper();

        Console.Write("Do�um y�l�n�z� giriniz\nSecim :  ");
        string dogumyili = Console.ReadLine().ToUpper();


        // XML �ablonunda g�nderilecek veri. "@" olmazsa hata verir. "$" formatlamak i�indir.
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


        var httpclient = new HttpClient(); // http client olu�turma.

        var requestcontent = new StringContent(soapRequest, Encoding.UTF8, "text/xml"); // Xml veri g�nderdi�imiz i�in text/xml ifadezsini kulland�m. Json verilerde application/json ifadesi kullan�l�yor.

        try
        {
            var request = await httpclient.PostAsync("https://tckimlik.nvi.gov.tr/service/kpspublic.asmx", requestcontent); // Pythonda kulland���m�z request.post(url , data=data) kodunun ayn�s�. await methodu g�nderene kadar bekliyor.

            if (request.IsSuccessStatusCode) // 200 ile 206 aras� status code'lar genellikle ba�ar�l� olur.
            {
                string requestokuma = await request.Content.ReadAsStringAsync(); // Request'in response'unu okuyana kadar bekleyen kod.

                if (requestokuma.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>")) // true or false
                {

                    Console.WriteLine("Kimlik bilgileriniz do�ru.");
                    // Konsol hemen kapan�yorsa Console.Read(); kullanabilirsiniz.
                }
                else
                {
                    Console.WriteLine("Kimlik bilgileriniz yanl��");

                }
            }
            else
            {
                Console.WriteLine("Bir Sorun Olu�tu :  " + request.StatusCode); // Status Code ile ilgili daha fazla bilgi almak i�in https://tr.wikipedia.org/wiki/HTTP_durum_kodlar%C4%B1
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir Sorun Olu�tu :  " + ex.Message);
        }



    }
}