<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="AKCILT.YoneticiPaneli.KategoriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Kategori Güncelle</h3>
        </div>
        <div class="FormIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Kategori Güncelleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
             <div class="row">
                <label>Kategori No</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="formInput" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row" style="margin-top:40px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="formButton">Kategori Güncelle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
