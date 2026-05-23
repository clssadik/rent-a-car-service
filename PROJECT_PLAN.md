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

- ~~`Customer` ve `Reservation` modelleri veritabanina bagli degil.~~ COZULDU
- ~~Rezervasyonlar veritabanina kaydedilmiyor.~~ COZULDU
- ~~Migration yapisi yok.~~ COZULDU
- ~~Connection string sifresi `appsettings.json` icinde acik duruyor.~~ COZULDU (User Secrets kullaniyor)

### Rezervasyon

- ~~Gercek rezervasyon kaydi olusturulmuyor.~~ COZULDU
- ~~Musteri kaydi olusturulmuyor.~~ COZULDU
- ~~Ayni tarih araliginda cakisan rezervasyon kontrolu yok.~~ COZULDU
- ~~Musait olmayan arac icin rezervasyon engeli yok.~~ COZULDU
- ~~Rezervasyon basari/detay sayfasi yok.~~ COZULDU

### Admin Paneli

- ~~Dashboard'daki rezervasyon, musteri ve gelir sayilari gercek veriden gelmiyor.~~ COZULDU
- ~~Son rezervasyonlar tablosu ornek veri kullaniyor.~~ COZULDU
- ~~Rezervasyon yonetim ekrani yok.~~ COZULDU
- ~~Musteri yonetim ekrani yok.~~ COZULDU
- ~~Arac silme icin onay mekanizmasi yok.~~ COZULDU

### Arayuz ve Gorseller

- Arac gorselleri veritabanindaki `ImageUrl` alanindan tutarli kullanilmiyor.
- Bazi sayfalarda sabit dis gorsel URL'leri var.
- ~~UI dili karisik; Ingilizce ve Turkce metinler birlikte kullaniliyor. Sayfa tamamen türkçe olsun~~ COZULDU

