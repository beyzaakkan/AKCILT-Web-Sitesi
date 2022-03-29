using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT
{
    public partial class YaziDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["yid"]);
                    Yazi y = dm.YaziGetir(id);
                    ltrl_baslik.Text = y.Baslik;
                    ltrl_kategori.Text = y.Kategori;
                    ltrl_yazar.Text = y.Yazar;
                    ltrl_goruntulenme.Text = Convert.ToString(y.GoruntulenmeSayisi);
                    ltrl_icerik.Text = y.Icerik;
                    img_cover.ImageUrl = "YaziKapaklari/" + y.KapakResim;
                    dm.GoruntuSayac(y);

                    if (Session["Uye"] != null)
                    {
                        pnl_girisVar.Visible = true;
                        pnl_girisyok.Visible = false;
                    }
                    else
                    {
                        pnl_girisVar.Visible = false;
                        pnl_girisyok.Visible = true;
                    }
                    rp_yorumlar.DataSource = dm.YorumListele(id);
                    rp_yorumlar.DataBind();

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_yorum.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["yid"]);
                Yorum y = new Yorum();
                y.YaziID = id;
                y.UyeID = ((Uye)Session["uye"]).ID;
                y.Icerik = tb_yorum.Text;
                y.YorumTarihi = DateTime.Now;
                y.OnayDurum = false;

                if (dm.YorumEkle(y))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_yorum.Text = "";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Yorum eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Yorum alanı boş bırakılamaz";
            }
        }
    }
}