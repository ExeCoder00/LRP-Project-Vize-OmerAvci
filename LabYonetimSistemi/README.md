# LRP - Laboratuvar Kaynak Planlama Sistemi

## Proje Hakkında
Okul bünyesindeki laboratuvarların, bilgisayarların ve öğrencilerin dijital ortamda takip edilmesini sağlayan bir yönetim sistemidir.

## Teknolojiler
- .NET 8.0 Minimal APIs
- Entity Framework Core (SQLite)
- Bootstrap 5
- Vanilla JavaScript (Fetch API)

## Nasıl Çalıştırılır?
1. Visual Studio 2022'de projeyi açın
2. Package Manager Console'da şu komutları çalıştırın:

3. Projeyi `https` profiliyle çalıştırın
4. Tarayıcıda `https://localhost:7126/login.html` adresine gidin

## Giriş Bilgileri
- **Admin:** kullanıcı adı: `admin`, şifre: `admin123`
- **Öğrenci:** kullanıcı adı: öğrenci no, şifre: `123456`

## Özellikler
- Login ve rol bazlı yetkilendirme (Admin/Student)
- Laboratuvar yönetimi (CRUD)
- Bilgisayar yönetimi (CRUD + otomatik demirbaş kodu)
- Öğrenci atama ve otomatik kullanıcı oluşturma
- Öğrenci portalı (zimmetli bilgisayar görüntüleme)
- Single Page Application (SPA) mimarisi