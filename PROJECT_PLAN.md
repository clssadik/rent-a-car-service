# MEU RENT Proje Durumu

## Programin Yaptiklari

### Araclar

- Araclari SQL Server veritabanindan listeler.
- Arac detay sayfasinda secilen aracin bilgilerini gosterir.
- Marka, arac tipi, vites ve fiyat araligina gore filtreleme yapar.
- Admin panelinden arac ekleme, duzenleme ve silme islemleri yapar.

### Rezervasyon

- Secilen arac icin rezervasyon formu gosterir.
- Musteri bilgileri, tarih ve lokasyon alanlarini alir.
- Zorunlu alan ve e-posta validasyonu yapar.
- Iade tarihi teslim alma tarihinden onceyse hata verir.
- Gun sayisi ve toplam fiyat hesaplar.
- Gecerli form gonderiminde basari mesaji gosterir.

### Admin Paneli

- Toplam arac sayisini gosterir.
- Arac yonetim ekranindan veritabanindaki araclari yonetir.
- Ornek dashboard kartlari ve son rezervasyonlar tablosu gosterir.

### Veritabani

- SQL Server kullanir.
- `MeurentDb` veritabaninda `Cars` tablosu bulunur.
- Uygulama ilk acilista arac tablosu bossa ornek arac verileri ekler.

### Arayuz

- Ana sayfa, arac listesi, arac detay, rezervasyon ve admin sayfalari vardir.
- Dark theme tasarim kullanir.
- Responsive Razor view yapisi bulunur.

## Eksik Kisimlar

### Veritabani

- `Customer` ve `Reservation` modelleri veritabanina bagli degil.
- Rezervasyonlar veritabanina kaydedilmiyor.
- Migration yapisi yok.
- Connection string sifresi `appsettings.json` icinde acik duruyor.

### Rezervasyon

- Gercek rezervasyon kaydi olusturulmuyor.
- Musteri kaydi olusturulmuyor.
- Ayni tarih araliginda cakisan rezervasyon kontrolu yok.
- Musait olmayan arac icin rezervasyon engeli yok.
- Rezervasyon basari/detay sayfasi yok.

### Admin Paneli

- Dashboard'daki rezervasyon, musteri ve gelir sayilari gercek veriden gelmiyor.
- Son rezervasyonlar tablosu ornek veri kullaniyor.
- Rezervasyon yonetim ekrani yok.
- Musteri yonetim ekrani yok.
- Arac silme icin onay mekanizmasi yok.

### Guvenlik

- Login/register sistemi yok.
- Admin sayfalari yetki kontrolu olmadan aciliyor.
- Kullanici rolleri yok.

### Arama ve Uygunluk

- Ana sayfadaki lokasyon ve tarih alanlari gercek aramaya bagli degil.
- Tarihe gore arac uygunluk kontrolu yok.
- Musaitlik filtresi yok.

### Arayuz ve Gorseller

- Arac gorselleri veritabanindaki `ImageUrl` alanindan tutarli kullanilmiyor.
- Bazi sayfalarda sabit dis gorsel URL'leri var.
- UI dili karisik; Ingilizce ve Turkce metinler birlikte kullaniliyor.

### Test ve Kurulum

- Unit test yok.
- Controller veya servis testi yok.
- SQL Server/Docker kurulum adimlari dokumante edilmemis.
