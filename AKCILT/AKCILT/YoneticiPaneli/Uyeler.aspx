<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="Uyeler.aspx.cs" Inherits="AKCILT.YoneticiPaneli.Uyeler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>ÜYELER</h3>
        </div>
        <div class="FormIcerik contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
             <asp:ListView ID="lv_uyeler" runat="server" OnItemcommand="lv_uyeler_ItemCommand">
                <LayoutTemplate>
                    <table class="Tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Soyisim </th>
                            <th>Kullanıcı Adı</th>
                            <th>Mail</th>
                            <th>Şifre</th>
                            <th>Üyelik Tarihi</th>
                            <th>Aktiflik</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID")%></td>
                        <td><%# Eval("Isim")%></td>
                        <td><%# Eval("Soyisim")%></td>
                        <td><%# Eval("KullaniciAdi")%></td>
                        <td><%# Eval("Email")%></td>
                        <td><%# Eval("Sifre")%></td>
                        <td><%# Eval("UyelikTarihi")%></td>
                        <td><%# Eval("Durum")%></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton update">Aktiflik</asp:LinkButton>
     
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
