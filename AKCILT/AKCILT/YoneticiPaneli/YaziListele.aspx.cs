using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT.YoneticiPaneli
{
    public partial class YaziListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yazilar.DataSource = dm.YaziListele();
            lv_yazilar.DataBind();
        }

        protected void lv_yazilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.YaziSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.YaziDurumDegistir(id);
            }
            lv_yazilar.DataSource = dm.YaziListele();
            lv_yazilar.DataBind();
        }
    }
}