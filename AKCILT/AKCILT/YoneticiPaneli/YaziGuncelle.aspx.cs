using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace AKCILT.YoneticiPaneli
{
    public partial class YaziGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["yid"]);
                    Yazi y = dm.YaziGetir(id);
                    tb_isim.Text = y.Baslik;
                    tb_ozet.Text = y.Ozet;
                    tb_icerik.Text = y.Icerik;
                    ddl_kategoriler.SelectedValue = Convert.ToString(y.Kategori_ID);
                    img_resim.ImageUrl = "../YaziKapaklari/" + y.KapakResim;
                    cb_yayinla.Checked = y.Durum;
                }
            }
            else
            {
                Response.Redirect("YaziListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunMu = true;
            int id = Convert.ToInt32(Request.QueryString["yid"]);
            Yazi y = dm.YaziGetir(id);
            y.Baslik = tb_isim.Text;
            y.Icerik = tb_icerik.Text;
            y.Ozet = tb_ozet.Text;
            y.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            y.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/YaziKapaklari/" + dosyaadi));
                    string dosyaadi1 = dosyaadi;
                    y.KapakResim = dosyaadi1;
                }
                else
                {
                    uygunMu = false;
                }
            }
            if (uygunMu)
            {
                if (dm.YaziGuncelle(y))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı png,jpg veya jpeg olmalıdır";
            }
        }
    }
}