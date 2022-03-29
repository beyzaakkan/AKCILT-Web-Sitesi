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
    public partial class IcerikEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }

        }
      
        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Yazi yaz = new Yazi();
            yaz.Baslik = tb_isim.Text;
            yaz.Ozet = tb_ozet.Text;
            yaz.Icerik = tb_icerik.Text;
            yaz.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            yaz.Durum = cb_yayinla.Checked;
            yaz.EklemeTarih = DateTime.Now;
            Yonetici y = (Yonetici)Session["yonetici"];

            yaz.Yazar_ID = y.ID;

            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string ResiminIsmi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/YaziKapaklari/" + ResiminIsmi));
                    yaz.KapakResim = ResiminIsmi;
                    resimformat = true;
                }
            }
            else
            {
                yaz.KapakResim = "none.png";
            }
            if (resimformat)
            {
                if (dm.YaziEkle(yaz))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Yazı eklenirken bir hata oluştu!";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır";
            }
        }

    }
}