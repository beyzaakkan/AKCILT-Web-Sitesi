<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="YaziListele.aspx.cs" Inherits="AKCILT.YoneticiPaneli.YaziListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>YAZILAR</h3>
        </div>
        <div class="FormIcerik contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_yazilar" runat="server" OnItemCommand="lv_yazilar_ItemCommand">
                <LayoutTemplate>
                    <table class="Tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>Resim</th>
                            <th>ID</th>
                            <th>Baslik</th>
                            <th>Kategori</th>
                            <th>Yazar</th>
                            <th>Ekleme Tarihi</th>
                            <th>Görüntülenme Sayısı</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src='../YaziKapaklari/<%# Eval("KapakResim")%>' width="100" /></td>
                        <td><%# Eval("ID")%></td>
                        <td style="width:100px; overflow: hidden; text-overflow: ellipsis;"><%# Eval("Baslik")%></td>
                        <td style=" width:90px;overflow: hidden; text-overflow: ellipsis;"><%# Eval("Kategori")%></td>
                        <td><%# Eval("Yazar")%></td>
                        <td><%# Eval("EklemeTarih")%></td>
                        <td><%# Eval("GoruntulenmeSayisi")%></td>
                        <td><%# Eval("Durum")%></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton>
                            <a href='YaziGuncelle.aspx?yid=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
