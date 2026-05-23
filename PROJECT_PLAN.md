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
