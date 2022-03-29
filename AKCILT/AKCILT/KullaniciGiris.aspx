<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="AKCILT.KullaniciGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <img src="assets/images/user.png" />
            <br />
            <label>Üye Girişi</label>

        </div>
        <div class="IcerikTasiyici">
            <div >
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="HataMesajı"  Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server" CssClass="HataMesaji"></asp:Label>
                </asp:Panel>
            </div>
            <div style="margin-top:15px;">
                <label>
                    Mail:
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" placeholder="mail@mail.com"></asp:TextBox></label><br />

            </div>
            <div>
                <label>
                    Şifre:
                        <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="MetinKutu" placeholder="Şifrenizi Giriniz"></asp:TextBox></label><br />
            </div>
            <div class="ButonRow">
                <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" OnClick="lbtn_giris_Click" CssClass="Buton"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
