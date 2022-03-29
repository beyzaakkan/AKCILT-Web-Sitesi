<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="AKCILT.YoneticiPaneli.Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="FormIcerik contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="Tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>İşlem Seçenekleri</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td>
                            <a href='KategoriGuncelle.aspx?kid=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
