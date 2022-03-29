<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="AKCILT.YoneticiPaneli.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AKCILT Yönetici Panel Girişi</title>
    <link href="CSS/PanelGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="FormTasiyici">
            <div class="FormBaslik">
                <img src="İmages/mainlogo.png" />
                <br />
                <label>Yönetici Girişi</label>
            </div>
            <div class="IcerikTasiyici">
                <asp:Panel ID="pnl_hata" runat="server" CssClass="HataMesaji" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div>
                    <label>
                        Mail:
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" placeholder="mail@mail.com"></asp:TextBox></label><br />

                </div>
                <div>
                    <label>
                        Şifre:
                        <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="MetinKutu" placeholder="Şifrenizi Giriniz"></asp:TextBox></label><br />
                </div>
                <div>
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" OnClick="btn_giris_Click" CssClass="Buton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
