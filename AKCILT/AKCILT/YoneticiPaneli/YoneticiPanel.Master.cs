using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT.YoneticiPaneli
{
    public partial class YoneticiPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Yonetici yon = (Yonetici)Session["yonetici"];
                lbl_kullanici.Text = yon.Isim + " " + yon.SoyIsim;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void lbtn_cikisYap_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");
        }
    }
}