CREATE DATABASE AKCILT_DB
GO
USE AKCILT_DB
GO
CREATE TABLE YoneticiTurler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurler(Isim) VALUES('Admin')
INSERT INTO YoneticiTurler(Isim) VALUES('Moderatör')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	Email nvarchar(120),
	Sifre nvarchar(20),
	Durum bit,
	CONSTRAINT pk_yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyisim, Email,Sifre,Durum)
VALUES(1, 'Beyza','Akkan','beyza_akkan@hotmail.com','123456',1)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(50),
	Email nvarchar(120),
	Sifre nvarchar(20),
	UyelikTarihi datetime,
	Durum bit,
	CONSTRAINT pk_uye PRIMARY KEY(ID)
)
INSERT INTO Uyeler(Isim, Soyisim,KullaniciAdi, Email,Sifre,UyelikTarihi,Durum)
VALUES('Beyza','Akkan','beyza_akkan@hotmail.com','123456',1)
SELECT ID, Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum FROM Uyeler
SELECT COUNT(*) FROM Uyeler

SELECT * FROM Yazilar
UPDATE Yazilar SET GoruntulenmeSayisi = GoruntulenmeSayisi + 1 WHERE ID = 10006
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Yazilar
(
	ID int IDENTITY(10000,1),
	KategoriID int,
	YazarID int,
	Baslik nvarchar(50),
	Ozet nvarchar(500),
	Icerik nvarchar(MAX),
	KapakResim nvarchar(75),
	GoruntulenmeSayisi int,
	EklemeTarihi datetime,
	Durum bit,
	CONSTRAINT pk_yazi PRIMARY KEY(ID),
	CONSTRAINT fk_YaziKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_YaziYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	UyeID int,
	YaziID int,
	Icerik nvarchar(500),
	YorumTarihi datetime,
	OnayDurum bit,
	CONSTRAINT pk_yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(YaziID) REFERENCES Yazilar(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)
)
SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.YaziID, Ya.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Yazilar AS Ya ON Ya.ID = Y.YaziID WHERE Y.ID = 10 AND OnayDurum = 1

INSERT INTO Yorumlar(UyeID, YaziID, Icerik,YorumTarihi,OnayDurum)
VALUES(1,10008,'gerçekten çok güzel bir paylaþým olmuþ',22-02-2022,1)
INSERT INTO Yorumlar(UyeID, YaziID, Icerik,YorumTarihi,OnayDurum)
VALUES(1,10008,'Tebrik ederim',22-02-2022,1)
INSERT INTO Yorumlar(UyeID, YaziID, Icerik,YorumTarihi,OnayDurum)
VALUES(1,10008,'Gayet açýklayýcý bir yazý olmuþ',22-02-2022,1)
SELECT*FROM Yorumlar

SELECT * FROM Yoneticiler
SELECT ID,Icerik FROM Yorumlar
SELECT * FROM Uyeler

