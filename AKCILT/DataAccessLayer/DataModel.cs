using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yönetici Panel Giriş Metod
        public Yonetici YoneticiPanelGirisi(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,EMail,Sifre,Durum FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.SoyIsim = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Kategori Metodları
        public bool KategoriEkle(Kategori k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();

                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategori k = new Kategori();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region YazıMetodları
        public bool YaziEkle(Yazi yaz)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yazilar(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResim, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResim, @goruntulenmeSayisi, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", yaz.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", yaz.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", yaz.Baslik);
                cmd.Parameters.AddWithValue("@ozet", yaz.Ozet);
                cmd.Parameters.AddWithValue("@icerik", yaz.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", yaz.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", yaz.GoruntulenmeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", yaz.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", yaz.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yazi> YaziListele()
        {
            try
            {
                List<Yazi> yazilar = new List<Yazi>();
                cmd.CommandText = "SELECT Y.ID,Y.KategoriID,K.Isim,Y.YazarID,Ya.Isim+' '+Ya.Soyisim,Y.Baslik,Y.Ozet,Y.Icerik,Y.KapakResim,Y.GoruntulenmeSayisi,Y.EklemeTarihi,Y.Durum FROM Yazilar AS Y JOIN Kategoriler AS K ON K.ID = Y.KategoriID JOIN Yoneticiler AS Ya ON Ya.ID = Y.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yazi y = new Yazi();
                    y.ID = reader.GetInt32(0);
                    y.Kategori_ID = reader.GetInt32(1);
                    y.Kategori = reader.GetString(2);
                    y.Yazar_ID = reader.GetInt32(3);
                    y.Yazar = reader.GetString(4);
                    y.Baslik = reader.GetString(5);
                    y.Ozet = reader.GetString(6);
                    y.Icerik = reader.GetString(7);
                    y.KapakResim = reader.GetString(8);
                    y.GoruntulenmeSayisi = reader.GetInt32(9);
                    y.EklemeTarih = reader.GetDateTime(10);
                    y.Durum = reader.GetBoolean(11);
                    yazilar.Add(y);
                }
                return yazilar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yazi> YaziListeleDurum()
        {
            try
            {
                List<Yazi> yazilar = new List<Yazi>();
                cmd.CommandText = "SELECT Y.ID,Y.KategoriID,K.Isim,Y.YazarID,Ya.Isim+' '+Ya.Soyisim,Y.Baslik,Y.Ozet,Y.Icerik,Y.KapakResim,Y.GoruntulenmeSayisi,Y.EklemeTarihi,Y.Durum FROM Yazilar AS Y JOIN Kategoriler AS K ON K.ID = Y.KategoriID JOIN Yoneticiler AS Ya ON Ya.ID = Y.YazarID AND Y.Durum = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yazi y = new Yazi();
                    y.ID = reader.GetInt32(0);
                    y.Kategori_ID = reader.GetInt32(1);
                    y.Kategori = reader.GetString(2);
                    y.Yazar_ID = reader.GetInt32(3);
                    y.Yazar = reader.GetString(4);
                    y.Baslik = reader.GetString(5);
                    y.Ozet = reader.GetString(6);
                    y.Icerik = reader.GetString(7);
                    y.KapakResim = reader.GetString(8);
                    y.GoruntulenmeSayisi = reader.GetInt32(9);
                    y.EklemeTarih = reader.GetDateTime(10);
                    y.Durum = reader.GetBoolean(11);
                    yazilar.Add(y);
                }
                return yazilar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yazi> YaziListele(int katid)
        {
            try
            {
                List<Yazi> yazilar = new List<Yazi>();
                cmd.CommandText = "SELECT Y.ID,Y.KategoriID,K.Isim,Y.YazarID,Ya.Isim+' '+Ya.Soyisim,Y.Baslik,Y.Ozet,Y.Icerik,Y.KapakResim,Y.GoruntulenmeSayisi,Y.EklemeTarihi,Y.Durum FROM Yazilar AS Y JOIN Kategoriler AS K ON K.ID = Y.KategoriID JOIN Yoneticiler AS Ya ON Ya.ID = Y.YazarID WHERE Y.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yazi y = new Yazi();
                    y.ID = reader.GetInt32(0);
                    y.Kategori_ID = reader.GetInt32(1);
                    y.Kategori = reader.GetString(2);
                    y.Yazar_ID = reader.GetInt32(3);
                    y.Yazar = reader.GetString(4);
                    y.Baslik = reader.GetString(5);
                    y.Ozet = reader.GetString(6);
                    y.Icerik = reader.GetString(7);
                    y.KapakResim = reader.GetString(8);
                    y.GoruntulenmeSayisi = reader.GetInt32(9);
                    y.EklemeTarih = reader.GetDateTime(10);
                    y.Durum = reader.GetBoolean(11);
                    yazilar.Add(y);
                }
                return yazilar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        public Yazi YaziGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT Y.ID,Y.KategoriID,K.Isim,Y.YazarID,Ya.Isim+' '+Ya.Soyisim, Y.Baslik, Y.Ozet, Y.Icerik, Y.KapakResim, Y.GoruntulenmeSayisi, Y.EklemeTarihi, Y.Durum FROM Yazilar AS Y JOIN Kategoriler AS K ON K.ID = Y.KategoriID JOIN Yoneticiler AS Ya ON Ya.ID = Y.YazarID WHERE Y.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Yazi y = new Yazi();
                while (reader.Read())
                {

                    y.ID = reader.GetInt32(0);
                    y.Kategori_ID = reader.GetInt32(1);
                    y.Kategori = reader.GetString(2);
                    y.Yazar_ID = reader.GetInt32(3);
                    y.Yazar = reader.GetString(4);
                    y.Baslik = reader.GetString(5);
                    y.Ozet = reader.GetString(6);
                    y.Icerik = reader.GetString(7);
                    y.KapakResim = reader.GetString(8);
                    y.GoruntulenmeSayisi = reader.GetInt32(9);
                    y.EklemeTarih = reader.GetDateTime(10);
                    y.Durum = reader.GetBoolean(11);
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YaziGuncelle(Yazi yaz)
        {
            try
            {
                cmd.CommandText = "UPDATE Yazilar SET KategoriID=@kategoriID, Baslik=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", yaz.ID);
                cmd.Parameters.AddWithValue("@kategoriID", yaz.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", yaz.Baslik);
                cmd.Parameters.AddWithValue("@ozet", yaz.Ozet);
                cmd.Parameters.AddWithValue("@icerik", yaz.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", yaz.KapakResim);
                cmd.Parameters.AddWithValue("@durum", yaz.Durum);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YaziSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yazilar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YaziDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Yazilar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Yazilar SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool GoruntuSayac(Yazi y)
        {
            try
            {
                cmd.CommandText = "UPDATE Yazilar SET GoruntulenmeSayisi = GoruntulenmeSayisi + 1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", y.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return false;

            }
            catch
            {
                return true;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yorum Medotları
        public List<Yorum> YorumListele()
        {
            try
            {
                List<Yorum> yorumlar = new List<Yorum>();

                cmd.CommandText = "SELECT Y.ID,Y.UyeID,U.KullaniciAdi,Y.YaziID,Ya.Baslik,Y.Icerik,Y.YorumTarihi,Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Yazilar AS Ya ON Ya.ID=Y.YaziID";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.YaziID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.YorumTarihi = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT OnayDurum FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool OnayDurum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Yorumlar SET OnayDurum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !OnayDurum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele(int id)
        {
            try
            {
                List<Yorum> yorumlar = new List<Yorum>();

                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.YaziID, Ya.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Yazilar AS Ya ON Ya.ID = Y.YaziID WHERE Ya.ID = @id AND OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.YaziID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.YorumTarihi = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    
        public List<Yorum> YorumListele(bool onay)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.YaziID, Ya.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Yazilar AS Ya ON Ya.ID=Y.YaziID WHERE Y.OnayDurum = @d";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", onay);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.YaziID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.YorumTarihi = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumEkle(Yorum y)
        {
            try
            {

                cmd.CommandText = " INSERT INTO Yorumlar(UyeID, YaziID, Icerik, YorumTarihi, OnayDurum) VALUES (@uyeID, @yaziID, @icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@yaziID", y.YaziID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.YorumTarihi);
                cmd.Parameters.AddWithValue("@onayDurum", y.OnayDurum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Kullanici Metodları
        public Uye UyeGirisi(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi >= 1)
                {
                    cmd.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Email = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeEkle(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, Soyisim,KullaniciAdi, Email,Sifre,UyelikTarihi,Durum)VALUES(@isim,@soyisim,@kullaniciadi,@email,@sifre,@uyeliktarihi,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", u.Isim);
                cmd.Parameters.AddWithValue("@soyisim",u.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciadi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@sifre", u.Sifre);
                cmd.Parameters.AddWithValue("@uyeliktarihi", u.UyelikTarihi);
                cmd.Parameters.AddWithValue("@durum", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Uye> UyeListele()
        {
            try
            {
                List<Uye> uyeler = new List<Uye>();

                cmd.CommandText = "SELECT ID, Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.KullaniciAdi = reader.GetString(3);
                    u.Email = reader.GetString(4);
                    u.Sifre = reader.GetString(5);
                    u.UyelikTarihi = reader.GetDateTime(6);
                    u.Durum = reader.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Uyeler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeGuncelle(Uye u)
        {
            try
            {
                cmd.CommandText = "UPDATE Uyeler SET Sifre = @s WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@s", u.Sifre);
                cmd.Parameters.AddWithValue("@id", u.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Uye UyeGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Sifre FROM Uyeler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Uye u = new Uye();

                while (reader.Read())
                {
                    u.ID = reader.GetInt32(0);
                    u.Sifre = reader.GetString(1);
                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}