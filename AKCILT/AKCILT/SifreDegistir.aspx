<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SifreDegistir.aspx.cs" Inherits="AKCILT.SifreDegistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <img src="assets/images/user.png" />
            <br />
            <label>Şifre Değiştir</label>
        </div>
        <div class="IcerikTasiyici">
            <div>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                    <label>Şifre Değiştirme İşlemi Başarıyla Gerçekleştirildi</label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server" ></asp:Label>
                </asp:Panel>
                
            </div>
            <div>
                <label>
                    Şifre:
                        <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="MetinKutu" placeholder="Yeni Şifreninizi Giriniz"></asp:TextBox></label><br />
            </div>
            <div class="ButonRow">
                <asp:LinkButton ID="lbtn_giris" runat="server" Text="Değiştir" OnClick="lbtn_giris_Click" CssClass="Buton"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
