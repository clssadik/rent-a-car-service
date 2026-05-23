# Rent A Car MVC Proje Planı

## Proje Amacı

Bu proje, üniversite Internet Programming dersi için geliştirilecek basit bir Rent A Car web uygulamasıdır. Amaç, ASP.NET Core MVC mimarisini kullanarak araç listeleme, araç detay görüntüleme, rezervasyon formu ve temel admin ekranları olan temiz ve anlaşılır bir web arayüzü oluşturmaktır.

Proje başlangıçta statik örnek verilerle hazırlanacaktır. Daha sonraki aşamalarda Entity Framework kullanılarak veritabanı işlemleri eklenecektir.

## Kullanılacak Mimari ve Teknolojiler

- ASP.NET Core MVC
- Razor Views
- HTML
- CSS
- Bootstrap uyumlu sayfa yapısı
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

Projenin arayüzü sade, modern ve responsive olacak şekilde tasarlanacaktır.

Temel tasarım yaklaşımı:

- Minimal ve profesyonel görünüm
- Temiz spacing
- Okunabilir yazı tipleri
- Rounded card yapıları
- Soft shadow kullanımı
- Bootstrap uyumlu grid sistemi
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
- Yapilan degisiklikler iki ayri commit ile GitHub `main` dalina push edildi:
  - `876eadd` - `Move sample data into MVC models`
  - `bddebc0` - `Add reservation form submission flow`

### Henuz Yapilmayanlar

- Entity Framework Core eklenmedi.
- Veritabani baglantisi eklenmedi.
- DbContext sinifi olusturulmadi.
- Migration islemleri yapilmadi.
- Arac verileri veritabanindan okunmuyor.
- Rezervasyonlar veritabanina kaydedilmiyor.
- Admin arac ekleme, duzenleme ve silme islemleri gercek CRUD olarak calismiyor.
- Login ve register sayfalari eklenmedi.
- Kullanici yetkilendirme sistemi eklenmedi.
- Admin ekranlari icin gercek yetki kontrolu yok.
- Odeme sistemi eklenmedi.
- Harita entegrasyonu eklenmedi.
- Gelismis raporlama ekranlari eklenmedi.
- Form verileri kalici olarak saklanmiyor.
- Arac filtreleme formu henuz gercek filtreleme yapmiyor.
- Ana sayfadaki arac arama formu henuz gercek arama yapmiyor.
- Arac gorselleri henuz gercek resim dosyalari veya URL'leri ile baglanmadi.
- Birim testi veya otomatik test yapisi eklenmedi.

### Siradaki Onerilen Adimlar

1. Statik arac verilerini tek bir ornek veri servisine tasimak.
2. Admin arac yonetimi formunu POST akisina baglamak.
3. Arac ekleme ve duzenleme icin basit validasyonlar eklemek.
4. Rezervasyon basari ekranini ayri bir `Success` view olarak duzenlemek.
5. Daha sonra Entity Framework Core ve veritabani katmanina gecmek.
