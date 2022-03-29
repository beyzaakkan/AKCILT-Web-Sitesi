using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_Kategoriler.DataSource = dm.KategoriListele();
            rp_Kategoriler.DataBind();
            if (Session["Uye"] != null)
            {
                Uye u = (Uye)Session["Uye"];
                pnl_GirisAktif.Visible = true;
                lbl_kullanici.Text = u.Isim;
                pnl_Giris_Yok.Visible = false;
            }
            else 
            {
                pnl_GirisAktif.Visible = false;
                pnl_Giris_Yok.Visible = true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["Uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}