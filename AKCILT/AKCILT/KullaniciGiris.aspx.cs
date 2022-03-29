using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT
{
    public partial class KullaniciGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            Uye u = dm.UyeGirisi(tb_mail.Text,tb_sifre.Text);
            if (u != null)
            {
                if (u.Durum)
                {
                    Session["Uye"] = u;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı askıya alınmıştır";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı Bulunamadı";
            }
        }
    }
}