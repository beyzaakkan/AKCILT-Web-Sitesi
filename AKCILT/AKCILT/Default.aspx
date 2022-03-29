<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AKCILT.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ListView ID="lv_yazilar" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="article">
                <div class="cover">
                    <img src='YaziKapaklari/<%#Eval("KapakResim") %>' />
                </div>
                <div class="info">
                    <p>Kategori: <%#Eval("Kategori") %> &nbsp|&nbsp Yazar: <%#Eval("Yazar")%></p>
                </div>
                <div class="kutu"></div>
                <div class="title">
                    <h3><%#Eval("Baslik") %></h3>
                </div>
                <div class="summary">
                    <p><%#Eval("Ozet") %></p>
                </div>
                <div class="button">
                    <a href='YaziDetay.aspx?yid=<%#Eval("ID") %>'>Yazının Devamı</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
