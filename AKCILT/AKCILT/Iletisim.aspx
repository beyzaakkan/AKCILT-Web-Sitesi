<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="AKCILT.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/MainPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="HakkimizdaBaslik">
        <h2>İletişim bilgilerimiz</h2>
    </div>
    <div class="HakkimizdaIcerik">
        <br />
        <img style="width:25px; float:left;" src="assets/images/phone.png" /> 
        <div style="float:left; margin-top:3px; margin-left:15px;">
            0 (539) 930 55 45
        </div>
        <br /><br />
        <img style="width:25px; float:left;" src="assets/images/mail.png" /> 
        <div style="float:left; margin-top:3px; margin-left:15px;">
            0 (222) 489 47 45
        </div>
        <br /><br />
        <img style="width:25px; float:left;" src="assets/images/mail.png" /> 
        <div style="float:left; margin-top:3px; margin-left:15px;">
            info@akcilt.com.tr
        </div>

       
    </div>
</asp:Content>
