using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT
{
    public partial class KullaniciKayit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (!string.IsNullOrEmpty(tb_soyisim.Text))
                {
                    if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
                    {
                        if (!string.IsNullOrEmpty(tb_mail.Text))
                        {
                            if (!string.IsNullOrEmpty(tb_sifre.Text))
                            {
                                Uye u = new Uye();
                                u.Isim = tb_isim.Text;
                                u.Soyisim = tb_soyisim.Text;
                                u.KullaniciAdi = tb_kullaniciadi.Text;
                                u.Email = tb_mail.Text;
                                u.Sifre = tb_sifre.Text;
                                u.UyelikTarihi = DateTime.Now;
                                u.Durum = true;
                                if (dm.UyeEkle(u))
                                {
                                    pnl_basarili.Visible = true;
                                    pnl_basarisiz.Visible = false;
                                    tb_isim.Text = "";
                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Üye eklenirken bir hata oluştu";
                                }
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Şifre boş bırakılamaz";
                            }
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Mail boş bırakılamaz";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı adı boş bırakılamaz";
                    }

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Soyisim boş bırakılamaz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "İsim boş bırakılamaz";
            }

        }
    }
}