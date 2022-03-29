using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace AKCILT
{
    public partial class SifreDegistir : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_sifre.Text))
            {
                Uye u = (Uye)Session["uye"];
                int id = Convert.ToInt32(u.ID);
                u.Sifre = tb_sifre.Text;

                if (dm.UyeGuncelle(u))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Güncelleme işlemi sırasında bir hata meydana geldi";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Şifre boş bırakılamaz";
            }
        }
    }
}