<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="AKCILT.YoneticiPaneli.YorumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>YORUMLAR</h3>
        </div>
        <div class="FormIcerik contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
             <asp:ListView ID="lv_yorumlar" runat="server" OnItemCommand="lv_yorumlar_ItemCommand">
                <LayoutTemplate>
                    <table class="Tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>Kullanıcı Adı</th>
                            <th>Yazı Başlık </th>
                            <th>İcerik</th>
                            <th>Yorum Tarihi</th>
                            <th>Onay Durumu</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID")%></td>
                        <td><%# Eval("Uye")%></td>
                        <td style="width:150px; overflow: hidden; text-overflow: ellipsis;"><%# Eval("Baslik")%></td>
                        <td style="width:300px; overflow: hidden; text-overflow: ellipsis;"><%# Eval("Icerik")%></td>
                        <td><%# Eval("YorumTarihi")%></td>
                        <td><%# Eval("OnayDurum")%></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton update">Onay</asp:LinkButton>
     
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
