<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciKayit.aspx.cs" Inherits="AKCILT.KullaniciKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <img src="assets/images/user.png" />
            <br />
            <label>Yeni Üye Kayıdı</label>

        </div>
        <div class="IcerikTasiyici">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Kayıt gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="margin-top: 15px;">
                <div class="icerikBaslik">İsim:</div>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="MetinKutu" placeholder="İsminizi giriniz"></asp:TextBox></><br />
            </div>
            <div>
                <div class="icerikBaslik">Soyisim:</div>
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="MetinKutu" placeholder="Soyisminizi giriniz"></asp:TextBox><br />
            </div>
            <div>
                <div class="icerikBaslik">Kullanıcı İsmi:</div>
                <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="MetinKutu" placeholder="Kullanıcı isminizi giriniz"></asp:TextBox><br />
            </div>
            <div>
                <div class="icerikBaslik">Mail:</div>
                <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" placeholder="mail@mail.com"></asp:TextBox><br />
            </div>
            <div>
                <div class="icerikBaslik">Şifre:</div>
                <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="MetinKutu" placeholder="Şifrenizi Giriniz"></asp:TextBox><br />
            </div>
            <div class="ButonRow">
                <asp:LinkButton ID="lbtn_giris" runat="server" Text="Kayıt Ol" OnClick="lbtn_giris_Click" CssClass="Buton"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
