# MEU RENT MVC Proje Planı

## Proje Amacı

Bu proje, üniversite Internet Programming dersi için geliştirilecek basit bir Rent A Car web uygulamasıdır. Proje adı MEU RENT olarak belirlenmiştir. Amaç, ASP.NET Core MVC mimarisini kullanarak araç listeleme, araç detay görüntüleme, rezervasyon formu ve temel admin ekranları olan temiz ve anlaşılır bir web arayüzü oluşturmaktır.

Proje başlangıçta statik örnek verilerle hazırlanacaktır. Daha sonraki aşamalarda Entity Framework kullanılarak veritabanı işlemleri eklenecektir.

## Kullanılacak Mimari ve Teknolojiler

- ASP.NET Core MVC
- .NET 10
- Razor Views
- HTML
- CSS
- Tailwind CDN destekli modern Razor sayfa yapısı
- İlerleyen aşamalarda Entity Framework

Proje MVC yapısına uygun olarak Controller, Model ve View katmanlarına ayrılacaktır. İlk aşamada ağırlık View dosyaları ve kullanıcı arayüzü üzerinde olacaktır.

## İlk Sürüm Kapsamı

İlk sürümde aşağıdaki sayfalar ve ekranlar bulunacaktır:

- Ana sayfa
- Araç listesi sayfası
- Araç detay sayfası
- Rezervasyon oluşturma formu
- Basit admin dashboard sayfası
- Admin araç yönetim sayfası

Bu sürümde gerçek veritabanı bağlantısı veya gelişmiş iş mantığı olmayacaktır. Sayfalarda kullanılan araç ve rezervasyon bilgileri geçici statik örnek veriler olacaktır.

## Kapsam Dışı Özellikler

Projeyi basit ve ders projesine uygun tutmak için aşağıdaki özellikler bu aşamada eklenmeyecektir:

- Login ve register sayfaları
- Kullanıcı yetkilendirme sistemi
- Ödeme sistemi
- Harita entegrasyonu
- Blog sayfaları
- Gelişmiş admin dashboard
- Gerçek veritabanı işlemleri
- Karmaşık raporlama ekranları

Bu özellikler gerekli görülürse daha sonraki sürümlerde ayrıca planlanabilir.

## Sayfa Yapısı

### Home

Ana sayfa kullanıcıyı karşılayan ilk ekrandır. Hero alanı, kısa açıklama, araç arama formu, öne çıkan araçlar ve tercih edilme sebepleri bu sayfada yer alır.

### Cars

Araçlar bölümü iki temel sayfadan oluşur:

- `Cars/Index`: Mevcut araçların kart yapısıyla listelendiği sayfa.
- `Cars/Details`: Seçilen aracın detay bilgilerinin gösterildiği sayfa.

İlk aşamada bu sayfalarda statik araç verileri kullanılacaktır.

### Reservations

Rezervasyon bölümü, müşterinin seçilen araç için temel bilgilerini ve rezervasyon tarihlerini girebileceği bir form içerir. Bu form ilk aşamada görsel olarak hazır olacaktır, ancak veritabanına kayıt işlemi yapılmayacaktır.

### Admin

Admin bölümü basit yönetim ekranlarından oluşur:

- `Admin/Index`: Toplam araç, aktif rezervasyon, müşteri ve gelir özetlerini gösteren dashboard.
- `Admin/Cars`: Araç listesini ve basit araç ekleme/düzenleme formunu gösteren yönetim sayfası.

Bu ekranlar ilk aşamada sadece arayüz tasarımı olarak hazırlanacaktır.

## Tasarım Prensipleri

Projenin arayüzü sade, modern, dark theme ve responsive olacak şekilde tasarlanacaktır.

Temel tasarım yaklaşımı:

- Minimal ve profesyonel görünüm
- Temiz spacing
- Okunabilir yazı tipleri
- Rounded card yapıları
- Soft shadow kullanımı
- Tailwind uyumlu grid sistemi
- Desktop, tablet ve mobil ekranlara uyum
- Sayfalar arasında tutarlı renk, buton ve kart tasarımı

Tasarım öğrenciler için anlaşılır, bakım yapılabilir ve fazla karmaşık olmayan bir yapıda tutulacaktır.

## Gelecek Geliştirme Planı

İlerleyen aşamalarda projeye aşağıdaki parçalar eklenebilir:

- MVC controller sınıfları
- Car, Reservation ve Customer model sınıfları
- Entity Framework DbContext yapısı
- Araçlar için CRUD işlemleri
- Rezervasyon kayıt işlemleri
- Form validasyonları
- Basit hata mesajları
- Veritabanından dinamik veri listeleme

Bu geliştirmeler yapılırken mevcut View yapısı korunacak ve statik örnek veriler model tabanlı dinamik verilerle değiştirilecektir.

## Başarı Kriterleri

Proje başarılı kabul edilmesi için aşağıdaki kriterleri karşılamalıdır:

- ASP.NET Core MVC projesi olarak çalıştırılabilir olmalıdır.
- Sayfalar desktop, tablet ve mobil ekranlarda düzgün görünmelidir.
- Kod yapısı beginner-friendly ve kolay anlaşılır olmalıdır.
- Gereksiz sayfa, özellik veya karmaşık yapı eklenmemelidir.
- View dosyaları ileride Entity Framework modellerine kolayca bağlanabilecek şekilde düzenli olmalıdır.
- Tasarım tüm sayfalarda görsel olarak tutarlı olmalıdır.

## Guncel Durum

Bu bolum, proje gelistirme surecinde tamamlanan ve henuz yapilmayan adimlari takip etmek icin eklenmistir.

### Tamamlanan Adimlar

- Proje dosyasi olusturuldu: `rent-a-car-service.csproj`
- Proje hedef framework surumu `net10.0` olarak guncellendi.
- ASP.NET Core MVC uygulama girisi olusturuldu: `Program.cs`
- MVC routing yapisi eklendi.
- Static dosyalar icin `wwwroot` kullanimi aktif hale getirildi.
- Home controller olusturuldu.
- Cars controller olusturuldu.
- Reservations controller olusturuldu.
- Admin controller olusturuldu.
- Temel model siniflari eklendi: `Car`, `Customer`, `Reservation`
- Mevcut Razor View dosyalari controller actionlari ile calisir hale getirildi.
- Proje `dotnet build` ile hatasiz derlenebilir hale getirildi.
- Uygulama `http://localhost:5000` adresinde calistirildi ve ana sayfa dogrulandi.
- View dosyalarindaki statik ornek veriler controller tarafina tasindi.
- View dosyalari `@model` kullanacak sekilde duzenlendi.
- Admin dashboard icin ViewModel yapisi eklendi: `AdminDashboardViewModel`, `ReservationSummaryViewModel`
- Rezervasyon sayfasi icin ViewModel yapisi eklendi: `ReservationCreateViewModel`
- Arac detay linkleri id ile calisacak hale getirildi.
- Rezervasyon sayfasi secili arac bilgisini modelden alacak hale getirildi.
- Rezervasyon formu gercek MVC POST akisina baglandi.
- Rezervasyon formu icin server-side validation eklendi.
- Bos form gonderiminde validasyon mesajlari gosterildi.
- Basarili form gonderiminde basari mesaji gosterildi.
- Return date, pickup date ile ayni veya daha once olursa hata verecek kontrol eklendi.
- Client-side validation script partial dosyasi eklendi: `_ValidationScriptsPartial.cshtml`
- Ana sayfa, arac listesi, arac detay, rezervasyon, admin dashboard ve admin arac yonetimi sayfalari tarayicida kontrol edildi.
- Yeni frontend design dosyalari incelendi.
- ORION DRIVE dark theme tasarimi MVC Razor view dosyalarina entegre edildi.
- Proje marka adi MEU RENT olarak guncellendi.
- Layout dosyasina Tailwind CDN, Inter fontu ve Material Symbols ikon destegi eklendi.
- `site.css` dosyasi yeni dark theme yardimci classlari ile guncellendi.
- Ana sayfa, arac listesi, arac detay, rezervasyon, admin dashboard ve admin arac yonetimi sayfalari yeni tasarimla uyumlu hale getirildi.
- Proje `dotnet build` ile `net10.0` hedefinde hatasiz derlenebilir hale getirildi.
- Statik arac verileri controllerlardan ayrilip `SampleDataService` icinde tek kaynak haline getirildi.
- Home, Cars, Reservations ve Admin controllerlari ornek verileri `SampleDataService` uzerinden kullanacak sekilde guncellendi.
- Rezervasyon sayfasinda secili arac bilgisi artik `carId` degerine gore ortak veri servisinden alinacak hale getirildi.
- Ana sayfa arama formundaki `carType` alani `Cars/Index` filtreleme akisina baglandi.
- `Cars/Index` sayfasinda brand, type, transmission ve price range filtreleri calisir hale getirildi.
- Filtre sonucunda eslesen arac yoksa kullaniciya sonuc bulunamadi mesaji gosterildi.
- Admin arac yonetimi formu gercek MVC POST akisina baglandi.
- Admin arac formu icin server-side validation eklendi.
- Admin arac ekleme islemi gecici `SampleDataService` uzerinden calisir hale getirildi.
- Admin arac silme islemi POST ve antiforgery ile calisir hale getirildi.
- Admin arac duzenleme islemi `editId` ile form doldurma ve POST ile guncelleme seklinde calisir hale getirildi.
- Gecici `SampleDataService` uzerinde temel admin CRUD akisi tamamlandi: add, edit, delete.
- Yapilan degisiklikler iki ayri commit ile GitHub `main` dalina push edildi:
  - `876eadd` - `Move sample data into MVC models`
  - `bddebc0` - `Add reservation form submission flow`
  - `25f7b24` - `Add car filtering flow`
  - `c71449b` - `Add admin car form submission`
  - `41fa9ef` - `Add sample car creation`
  - `18047cc` - `Add sample car deletion`
  - `64bdde5` - `Add sample car editing`

### Henuz Yapilmayanlar

- Entity Framework Core eklenmedi.
- Veritabani baglantisi eklenmedi.
- DbContext sinifi olusturulmadi.
- Migration islemleri yapilmadi.
- Arac verileri veritabanindan okunmuyor.
- Rezervasyonlar veritabanina kaydedilmiyor.
- Login ve register sayfalari eklenmedi.
- Kullanici yetkilendirme sistemi eklenmedi.
- Admin ekranlari icin gercek yetki kontrolu yok.
- Odeme sistemi eklenmedi.
- Harita entegrasyonu eklenmedi.
- Gelismis raporlama ekranlari eklenmedi.
- Form verileri kalici olarak saklanmiyor.
- Ana sayfadaki location ve tarih alanlari henuz gercek rezervasyon uygunluk kontrolu yapmiyor.
- Arac gorselleri su an dis URL'ler ile gosteriliyor; lokal proje assetleri olarak henuz duzenlenmedi.
- Birim testi veya otomatik test yapisi eklenmedi.

### Siradaki Onerilen Adimlar

1. Rezervasyon basari ekranini ayri bir `Success` view olarak duzenlemek.
2. Arac gorsellerini `wwwroot/images/cars/` altinda lokal asset olarak duzenlemek.
3. Entity Framework Core paketlerini eklemek.
4. `ApplicationDbContext` sinifini olusturmak.
5. `Car`, `Customer` ve `Reservation` modellerini veritabani iliskilerine hazir hale getirmek.
6. Connection string eklemek.
7. Ilk migration islemini yapmak.
8. Arac verilerini veritabanindan okumak.
9. Rezervasyonlari veritabanina kaydetmek.
10. Admin dashboard sayilarini veritabanindan hesaplamak.
11. Ana sayfadaki location ve tarih alanlarini rezervasyon uygunluk akisi ile iliskilendirmek.
12. Son asamada sayfalari responsive olarak tekrar kontrol etmek ve `dotnet build` ile dogrulamak.
