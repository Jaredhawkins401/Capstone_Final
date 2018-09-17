<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Capstone_Final.Views.Login" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
 

<asp:TextBox ID="userNameBox" runat="server" MaxLength="20" /><br />
    <br />
<asp:Label ID="nameErrors" runat="server" Text="" />
<asp:TextBox ID="userPassBox" runat="server" MaxLength ="20" /><br />
        <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /> <br />
        <asp:Label ID="errorBox" runat="server" />

</asp:Content>
