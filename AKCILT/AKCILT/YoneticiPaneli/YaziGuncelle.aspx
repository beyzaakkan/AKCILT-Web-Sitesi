<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="YaziGuncelle.aspx.cs" Inherits="AKCILT.YoneticiPaneli.YaziGuncelle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>YAZI GÜNCELLE</h3>
        </div>
        <div class="FormIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Yazı Güncelleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div>
                <div class="row" style="width: 480px">
                    <label>Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Kapak Resimi</label><br />
                    <br />
                    <asp:Image ID="img_resim" runat="server" Width="500" /><br />
                    <label style="font-size: 12pt">Seçiniz:</label>
                    <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
            </div> 
            <div>
                <div class="row">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <asp:CheckBox ID="cb_yayinla" runat="server" />
                <label>Yayınla</label>

            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_guncelle" runat="server" OnClick="lbtn_guncelle_Click" CssClass="formButton">Yazı Güncelle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
