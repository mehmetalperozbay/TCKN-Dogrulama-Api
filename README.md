# TC Kimlik No Doğrulama API C# Uygulaması

Bu C# uygulaması, Türkiye Cumhuriyeti (TC) kimlik numarasının doğruluğunu sorgulamak için e-Devlet'in sağladığı TC Kimlik No Doğrulama web servisinden faydalanır. Uygulama, kullanıcının TC kimlik numarasını, adı, soyadı ve doğum yılını girerek kimlik doğrulama işlemi yapar ve sonucu ekrana yansıtır.

## Özellikler

- Kullanıcının **TC Kimlik Numarası**, **Adı**, **Soyadı**, ve **Doğum Yılı** bilgisini alır.
- **SOAP** istek formatında, **[**TC İÇİŞLERİ BAKANLIĞI NÜFUS VE VATANDAŞLIK İŞLERİ GENEL MÜDÜRLÜĞÜ**](https://tckimlik.nvi.gov.tr/Home)** servisine bağlanır.
- API'den gelen yanıtı kontrol eder ve kullanıcıya kimlik bilgilerinin doğruluğu hakkında bilgi verir.

## Gerekli Bağımlılıklar

Bu uygulama .NET Core veya .NET Framework ile uyumludur ve **HttpClient** kütüphanesini kullanarak web isteği gönderir. `HttpClient` sınıfı, `.NET`'in standart bir parçasıdır, bu yüzden ek bir paket yüklemeye gerek yoktur.

## Kullanım

1. Uygulamayı bir C# projesi olarak açın.
2. **Visual Studio** veya **Visual Studio Code** gibi bir IDE kullanarak projeyi derleyin.
3. Program çalıştığında, terminalde şu bilgileri girmeniz istenecektir:
   - TC Kimlik Numarası
   - Adınız
   - Soyadınız
   - Doğum Yılınız

4. Girdiğiniz bilgiler API'ye gönderilecek ve doğru veya yanlış olduğu size bildirilecektir.

### Adım Adım Kurulum

1. **Proje dosyasını oluşturun**:
   Visual Studio veya başka bir IDE kullanarak yeni bir C# konsol uygulaması oluşturun.

2. **Kodları Projeye Ekleyin**:
   Yukarıdaki kodu `Program.cs` dosyasına ekleyin.

3. **Projeyi Çalıştırın**:
   - Visual Studio'da "Çalıştır" butonuna basın ya da terminalden `dotnet run` komutunu çalıştırarak uygulamayı başlatın.

4. **Veri Girişi**:
   - Terminal ekranında, kullanıcıdan TC Kimlik Numarası, Ad, Soyad ve Doğum Yılı bilgileri istenecektir.

5. **Sonuçları Kontrol Edin**:
   - API, doğru veya yanlış olup olmadığını belirterek size bir yanıt gönderecektir.

## Nerde Kullanılabilir ?
1. Banka Uygulamaları.

2. [Sahibinden](https://www.sahibinden.com/), [Trendyol](https://www.trendyol.com/) gibi ticaret amaçlı olan uygulamalar.

3. Kripto Al/Sat uygulamaları.

4. Tc kimlik isteyen her türlü websitesi ve uygulama.


## Hata Ayıklama

Eğer uygulama çalışırken bir hata ile karşılaşırsanız, hata mesajını görmek için aşağıdaki noktaları kontrol edin:

- **Yanıt Durum Kodu**: Eğer API isteği başarılı olursa, `request.IsSuccessStatusCode` ile kontrol ediir. Yanlış kimlik bilgisi durumunda, API'nin döndüğü XML içerik kontrol edilir.
- **Hata Mesajı**: Uygulama, oluşan hatayı ekrana yazdırır ve bu hataya göre gerekli düzeltmeleri yapabilirsiniz.

## Kaynaklar

- [NVI TC Kimlik No Doğrulama Web Servisi](https://tckimlik.nvi.gov.tr/Home)

  
## Lisans

Bu proje, **MIT Lisansı** altında lisanslanmıştır.

## Request / Response Formatı

**İstek Formatı: SOAP (XML tabanlı)**
**Yanıt Formatı: XML**
