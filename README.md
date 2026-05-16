# LRP - Laboratuvar Kaynak Planlama Sistemi

**2025-2026 Bahar Dönemi Vize Ödevi | Ömer Avcı**

Okul laboratuvarlarındaki bilgisayarların ve sorumlu öğrencilerin dijital ortamda takip edilmesini sağlayan web tabanlı bir yönetim sistemidir.

------------------
## Teknolojiler

- **Backend:** .NET 8.0 Minimal APIs
- **Veritabanı:** SQLite + Entity Framework Core (Code-First)
- **Frontend:** Bootstrap 5, FontAwesome, Vanilla JavaScript (Fetch API)
- **Mimari:** Single Page Application (loadPage mantığı)

------------------
## Kurulum ve Çalıştırma

1. Repoyu klonlayın: git clone https://github.com/ExeCoder00/LRP-Project-Vize-OmerAvci.git
2. Visual Studio 2022 ile LabYonetimSistemi.sln dosyasını açın
3. Package Manager Console'da şunu çalıştırın: Update-Database
4. Projeyi https profiliyle çalıştırın
5. Tarayıcıda açın: https://localhost:7126/login.html

------------------
## Giriş Bilgileri

| Rol | Kullanıcı Adı | Şifre |
|-----|--------------|-------|
| Admin | admin | admin123 |
| Öğrenci | öğrenci no | 123456 |

Admin kullanıcısı uygulama ilk çalıştığında otomatik oluşturulur.

------------------
## Özellikler

**Admin Paneli:**
- Lab ekleme, listeleme, güncelleme, silme
- Bilgisayar CRUD — otomatik demirbaş kodu üretimi (Örn: LABA-PC-01)
- Laptop / Masaüstü tip seçimi, HDMI, İnternet, Veyon özellikleri
- Lab detay sayfası — toplu PC ekleme, silme, düzenleme
- Öğrenci atama — otomatik kullanıcı hesabı oluşturma
- Birden fazla PC zimmetleme
- Sorun kayıtları — kategori, açıklama, çözüldü işaretleme
- Dashboard — sistem özeti, açık/çözülen sorunlar

**Öğrenci Portalı:**
- Rol bazlı yetki kontrolü
- Zimmetli bilgisayarların teknik özelliklerini görüntüleme

------------------
## Ekran Görüntüleri

> Aşağıdaki ekran görüntüleri sistemin çalışır haldeki görünümünü yansıtmaktadır.

------------------
### 🔐 Giriş Ekranı
Admin ve Öğrenci rolleri için ayrı sekmeli giriş sistemi.

<img width="1921" height="1017" alt="image" src="https://github.com/user-attachments/assets/fecfe798-6ad0-4352-afba-3a9c6f29d89a" />

------------------
### 📊 Dashboard
Laboratuvar, bilgisayar, öğrenci sayıları ve açık/çözülen sorunların özet görünümü.

<img width="1922" height="1016" alt="image" src="https://github.com/user-attachments/assets/a0af798e-9ac6-4390-807c-d3ff0930b2c2" />

-------------------
### 🏫 Lab Yönetimi
Lab ekleme, düzenleme, silme ve detay görüntüleme.

<img width="1915" height="1019" alt="image" src="https://github.com/user-attachments/assets/11761434-a065-4326-806a-3955f9473283" />
<img width="1897" height="1021" alt="image" src="https://github.com/user-attachments/assets/e5289b2d-b2a9-447d-b766-9381f3581372" />
<img width="625" height="611" alt="image" src="https://github.com/user-attachments/assets/ad09a7e0-824d-4aba-a4a6-a1cc8d2e21be" />
<img width="622" height="431" alt="image" src="https://github.com/user-attachments/assets/005a1bd7-5690-45bd-8a07-98a7a3b366c0" />
<img width="1002" height="845" alt="image" src="https://github.com/user-attachments/assets/440d9bd5-ee31-49f7-bca0-a5b25fb1bdad" />

<img width="633" height="498" alt="image" src="https://github.com/user-attachments/assets/85c24e59-a836-460b-ba69-1c114a3e3711" />
<img width="1575" height="330" alt="image" src="https://github.com/user-attachments/assets/9a25f8f7-1577-4c7b-8b33-8d8183661bc6" />

------------------
### 🖥️ Lab Detay
Her laba ait bilgisayarlar kart görünümünde listelenir. Toplu PC ekleme, silme ve düzenleme yapılabilir.

<img width="1916" height="1022" alt="image" src="https://github.com/user-attachments/assets/3eb4a08a-9aeb-4b87-a406-ae1c923dbfaa" />
<img width="631" height="315" alt="image" src="https://github.com/user-attachments/assets/7ba8e996-84cd-478d-a57c-82dfac30ce14" />

------------------
### 💻 Bilgisayarlar
Otomatik demirbaş kodu üretimi, Laptop/Masaüstü tipi, HDMI, İnternet, Veyon özellikleri.

<img width="1898" height="1021" alt="image" src="https://github.com/user-attachments/assets/b09f0adb-3af1-4d13-904e-31506545f7a2" />
<img width="618" height="613" alt="image" src="https://github.com/user-attachments/assets/2f36e222-7d72-4652-b67a-593060167c3c" />
<img width="617" height="614" alt="image" src="https://github.com/user-attachments/assets/71d3706b-ae0a-43ff-ba8e-8cd01a9fb98d" />

------------------
### 👨‍🎓 Öğrenciler
Öğrenci ekleme ile otomatik kullanıcı hesabı oluşturma. Birden fazla PC zimmetleme.

<img width="1917" height="1021" alt="image" src="https://github.com/user-attachments/assets/194c6f61-d9bf-43aa-ae87-71124c19649d" />
<img width="620" height="636" alt="image" src="https://github.com/user-attachments/assets/8f49f8f1-98d3-4cc0-829e-6b36b9545b28" />
<img width="625" height="638" alt="image" src="https://github.com/user-attachments/assets/18d14a16-3dce-484a-aaa2-ab09e934d203" />

------------------
### ⚠️ Sorunlar
Bilgisayar sorunlarını kategorize etme, çözüldü işaretleme ve takip.

<img width="1916" height="1018" alt="image" src="https://github.com/user-attachments/assets/20f3650e-2db2-44ee-b1a3-471af00e9990" />
<img width="615" height="578" alt="image" src="https://github.com/user-attachments/assets/ce26fe7c-9843-43e7-a551-bcadf976da9c" />

------------------
### 🎓 Öğrenci Paneli
Öğrenci girişinde sadece zimmetli bilgisayarların teknik özellikleri görüntülenir.

<img width="1912" height="1020" alt="image" src="https://github.com/user-attachments/assets/4b2052f0-1e01-4c1f-bd9d-203e5e063e4d" />
<img width="1901" height="1022" alt="image" src="https://github.com/user-attachments/assets/23d2f017-1706-43b2-93d8-021d59c95aef" />
<img width="1899" height="1021" alt="image" src="https://github.com/user-attachments/assets/6a43f6e2-2e00-4227-b13d-7766029373f7" />

------------------
### 📡 Swagger
Tüm endpoint'lerin test edilebileceği API dokümantasyonu.

<img width="1898" height="1019" alt="image" src="https://github.com/user-attachments/assets/c318464a-c959-4bf2-84b8-c4badbc76351" />
<img width="1900" height="1021" alt="image" src="https://github.com/user-attachments/assets/ad8345c0-b659-4714-bfe3-0f3b4cf01fa1" />
<img width="1902" height="1019" alt="image" src="https://github.com/user-attachments/assets/51570ff4-e6d6-4429-9a1f-f908917ace83" />
<img width="1901" height="1022" alt="image" src="https://github.com/user-attachments/assets/f7585324-0e3f-465b-a1d4-885d658de4ed" />

------------------
## Proje Yapısı
```
LabYonetimSistemi/
│
├── Data/
│   └── AppDbContext.cs              # EF Core veritabanı bağlantısı ve DbSet tanımları
│
├── Endpoints/
│   ├── AuthEndpoints.cs             # Login ve rol bazlı giriş işlemleri
│   ├── LabEndpoints.cs              # Laboratuvar CRUD işlemleri
│   ├── PcEndpoints.cs               # Bilgisayar CRUD ve AssetCode üretimi
│   ├── StudentEndpoints.cs          # Öğrenci atama ve öğrenci portalı işlemleri
│   ├── IssueEndpoints.cs            # Arıza / sorun kayıt işlemleri
│   └── StatEndpoints.cs             # Dashboard istatistik endpointleri
│
├── Migrations/
│   └── ...                          # EF Core Code-First migration dosyaları
│
├── Models/
│   ├── Computer.cs                  # Bilgisayar modeli
│   ├── Issue.cs                     # Arıza / sorun modeli
│   ├── Lab.cs                       # Laboratuvar modeli
│   ├── Software.cs                  # Yazılım modeli
│   ├── Student.cs                   # Öğrenci modeli
│   └── User.cs                      # Kullanıcı ve rol modeli
│
├── wwwroot/
│   ├── view/
│   │   ├── dashboard.html           # Admin dashboard içerik sayfası
│   │   ├── labs.html                # Laboratuvar yönetim sayfası
│   │   ├── computers.html           # Bilgisayar yönetim sayfası
│   │   ├── students.html            # Öğrenci / zimmet yönetim sayfası
│   │   ├── issues.html              # Arıza kayıt ve takip sayfası
│   │   └── lab-detail.html          # Laboratuvar detay sayfası
│   │
│   ├── admin.html                   # Admin panel ana sayfası / SPA şablonu
│   ├── index.html                   # Admin yönlendirme / ana giriş sayfası
│   ├── login.html                   # Kullanıcı giriş ekranı
│   ├── student.html                 # Öğrenci portalı
│   └── style.css                    # Ortak CSS stilleri
│
├── .gitignore                       # bin, obj ve .db gibi dosyaları hariç tutar
├── appsettings.json                 # Uygulama ayarları
├── LabYonetimSistemi.http           # API test istekleri
├── Program.cs                       # Uygulama başlangıç ve endpoint kayıtları
└── README.md                        # Proje açıklaması ve çalıştırma bilgileri
```
