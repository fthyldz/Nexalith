# Nexalith

Nexalith, **.NET Core 8** kullanılarak geliştirilen bir altyapı projesidir ve her projede yeniden kullanılabilen modüler, ölçeklenebilir bir temel sunmayı amaçlar. Proje, **Clean Architecture** prensiplerine dayanır ve uzun vadede geliştirilmeye devam edilecek bir yapıdadır. Nexalith, farklı projeler için genel bir altyapı sağlayarak, hızlı ve sağlam bir şekilde yeni projeler oluşturmayı hedefler.

## Proje Yapısı

Nexalith, beş ana sınıf kütüphanesi (class library) üzerinden yapılandırılmıştır:

- **Domain**: İş kurallarını ve domain entity'lerini içerir.
- **Application**: Uygulama seviyesinde hizmetleri, **CQRS** yapısını, doğrulama (validation) ve çeşitli davranışları (logging, transaction) uygular.
- **Persistence**: Veritabanı etkileşimleri için **Entity Framework Core** tabanlı veri erişim katmanını içerir.
- **Infrastructure**: Çapraz kesişen endişeleri ve dış servislerle entegrasyonları yönetir.
- **Api**: Carter ile minimal API entegrasyonuna örnekler sağlar (geliştiriciye özel, opsiyonel).

## Özellikler

### 1. **Clean Architecture**
- Uygulamanın farklı katmanlara ayrılması ile sürdürülebilir, test edilebilir ve bakımı kolay bir yapı.
- Katmanlar arası bağımlılıkların en aza indirgenmesi.

### 2. **CQRS (Command Query Responsibility Segregation)**
- Her bir işlem için **ICommandHandler** ve **IQueryHandler** arayüzleri ile komutlar ve sorgular ayrılmıştır.
- **ValidationBehavior**, **LoggingBehavior**, ve **TransactionBehavior** gibi davranışlar ile çapraz kesişen operasyonlar merkezi olarak yönetilir.

### 3. **MediatR**
- Mesaj yönlendirme için **MediatR** kullanılarak, komutlar ve sorgular merkezi bir yapıda ele alınır.

### 4. **FluentValidation**
- Komutlar ve sorgular için doğrulamalar **FluentValidation** ile yönetilir, her handler çalışmadan önce doğrulamalar yapılır.

### 5. **Mapster**
- Nesne dönüşümleri için yüksek performanslı ve esnek bir yapı sağlayan **Mapster** kullanılır.

### 6. **Entity Framework Core**
- Veritabanı işlemleri için **EF Core** kullanılır ve her entity için **Strongly-Typed ID** yapısı desteklenir.

### 7. **Repository Pattern & Unit of Work**
- **Generic Repository Pattern** ile tüm veritabanı işlemleri merkezi olarak yönetilir.
- **Unit of Work** yapısı ile birden fazla veritabanı işlemi tek bir transaction içinde güvenli bir şekilde yönetilir.

### 8. **Custom Exception Handling**
- API genelinde tutarlı hata yönetimi sağlayan bir global hata yakalayıcı (exception handler) bulunur.

### 9. **Base Generic CRUD Endpoints**
- Geliştirilmek istenen projeler için CRUD operasyonları için temel endpoint'ler sunar.

### 10. **Transaction Manager**
- Veritabanı işlemlerinin güvenli bir şekilde yapılması için özel bir transaction yönetimi sunar.

### 11. **Dependency Injection**
- Tüm bağımlılıkların statik **IServiceCollection** kullanılarak kolayca yönetilebilmesi.

## Kullanım

Nexalith bir altyapı projesi olarak tasarlandığı için doğrudan çalıştırılamaz. Ancak, bu altyapıyı kendi projelerinizde kullanmak için aşağıdaki adımları izleyebilirsiniz:

1. **Domain Katmanını Genişletin**: Kendi iş kurallarınızı ve domain entity'lerinizi **Domain** katmanına ekleyin.
2. **Application Katmanını Özelleştirin**: Komutlar ve sorgular ile yeni özellikler ekleyin, CQRS yapısını kullanarak uygulama mantığını oluşturun.
3. **Persistence Katmanında Veritabanı Yapılandırmasını Yapın**: Yeni veritabanı entity'lerinizi ve yapılandırmalarınızı **Persistence** katmanına ekleyin.
4. **Infrastructure Katmanını Entegre Edin**: Dış servis entegrasyonları gibi ihtiyaçlarınızı **Infrastructure** katmanına ekleyin.
5. **API Katmanını Geliştirin**: Gerektiğinde yeni API endpoint'leri oluşturmak için **Api** katmanında Carter'ı kullanarak genişletebilirsiniz.
