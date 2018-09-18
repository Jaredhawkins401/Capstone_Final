<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Capstone_Final.Views.passReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>Reset Password Required</p>

<asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
<asp:TextBox ID="passwordBox" type="password" runat="server" MaxLength="20" /><br />
<asp:Label ID="passwordErrors" runat="server" Text="" />
    <br />

<asp:Label ID="passwordConfirmLabel" runat="server" Text="Confirm"></asp:Label>
<asp:TextBox ID="confirmBox" type="password" runat="server" MaxLength ="20" /><br />
    <asp:Label ID="confirmErrors" runat="server" Text="" />
        <br />
    <asp:Button ID="PassConfirmButton" runat="server" Text="Change Password" OnClick="PassConfirmButton_Click" /> <br />
        <asp:Label ID="errorBox" runat="server" />

</asp:Content>
