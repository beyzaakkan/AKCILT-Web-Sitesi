<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="YaziDetay.aspx.cs" Inherits="AKCILT.YaziDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="articleDetail">
        <div class="titleDetail">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="coverDetail">
            <asp:Image ID="img_cover" runat="server" />
        </div>
        <div class="infoDetail">
            Kategori:
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            &nbsp|&nbsp
            Yazar:
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
            &nbsp|&nbsp
            Görüntülenme Sayısı:
            <asp:Literal ID="ltrl_goruntulenme" runat="server"></asp:Literal>
        </div>
        <div class="kutuDetail"></div>
        <div class="contentDetail">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>
    </div>
    <div style="min-height: 200px;">
        <div class="yorum" style="margin-top: 50px;">
            <div class="YorumBaslik">
                <img style="float: left;" src="assets/images/comment.png" />
                <h2 style="float: left; margin-left: 20px; padding-top: 10px;">Yorumlar</h2>
            </div>
            <div class="CommentBox">
                <asp:Repeater ID="rp_yorumlar" runat="server">
                    <ItemTemplate>
                        <div class="yorumitem">
                            <label><%# Eval("Uye") %></label>
                            |
                        <label><%# Eval("YorumTarihi") %></label>
                            <br />
                            <p style="color: #283348;"><%# Eval("Icerik") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="margin-bottom: 30px; margin-top: 20px;">
                <asp:Panel ID="pnl_girisVar" runat="server" Visible="false">
                    <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                        <label>Yorum Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
                    </asp:Panel>
                    <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                        <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                    </asp:Panel>

                    <div style="margin-left: 15px; margin-bottom: 15px;">
                        <h3 style="margin-bottom: 15px; color: #843A77;">Yorumunuz</h3>
                        <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="YorumKutu"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <br />
                    <asp:LinkButton ID="lbtn_yorumYap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumYap_Click" CssClass="yorumYapButton"></asp:LinkButton>
                </asp:Panel>
            </div>
            <asp:Panel ID="pnl_girisyok" runat="server" class="girisYorum">
                <h2>Yorum yapabilmek için lütfen <a href="KullaniciGiris.aspx">giriş yapınız </a>!</h2>
            </asp:Panel>

        </div>

    </div>
</asp:Content>
