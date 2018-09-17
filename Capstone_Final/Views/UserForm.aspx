<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="Capstone_Final.Views.UserForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="userIDLabel" runat="server" Text="ID"></asp:Label>
    <asp:Label ID="userIDBox" runat="server" Text=""></asp:Label>

    <!-- Account Name Text Box -->
    <asp:Label ID="accountNameLabel" runat="server" Text="Account Name" Style="display: block"></asp:Label>
    <asp:TextBox ID="accountNameBox" runat="server" Style="display: block" MaxLength="16"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fNameBox" ErrorMessage="First Name is required" />

    <!-- First Name Text Box -->
    <asp:Label ID="fNameLabel" runat="server" Text="First Name" Style="display: block"></asp:Label>
    <asp:TextBox ID="fNameBox" runat="server" Style="display: block" MaxLength="16"></asp:TextBox>
    <asp:RequiredFieldValidator ID="fNameRequired" runat="server" ControlToValidate="fNameBox" ErrorMessage="First Name is required" />

    <!-- Last Name Text Box -->
    <asp:Label ID="lNameLabel" runat="server" Text="Last Name" Style="display: block"></asp:Label>
    <asp:TextBox ID="lNameBox" runat="server" Style="display: block" MaxLength="16"></asp:TextBox>
    <asp:RequiredFieldValidator ID="lNameValid" runat="server" ControlToValidate="lNameBox" ErrorMessage="Last Name is required" />

    <!-- Email Text Box -->
    <asp:Label ID="emailLabel" runat="server" Text="E-mail" Style="display: block"></asp:Label>
    <asp:TextBox ID="emailBox" runat="server" Style="display: block" MaxLength="40"></asp:TextBox>
    <asp:RequiredFieldValidator ID="emailValid" runat="server" ControlToValidate="emailBox" ErrorMessage="E-mail is required" />

    <!-- Role -->
    <asp:Label ID="roleLabel" runat="server" Text="Role" Style="display: block"></asp:Label>
    <asp:DropDownList ID="roleBox" runat="server">
        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
        <asp:ListItem Text="Accountant" Value="2"></asp:ListItem>
        <asp:ListItem Text="Contractor" Value="3"></asp:ListItem>
        <asp:ListItem Text="General" Value="4"></asp:ListItem>
    </asp:DropDownList>

    <asp:Label ID="passwordResetFlag" runat="server" Text="Require User to Change Password" Style="display: block"></asp:Label>
    <asp:CheckBox ID="passwordResetBox" runat="server" Checked="false" />

    <asp:Label ID="creationDateLabel" runat="server" Text="Creation Date" Style="display: block"></asp:Label>
    <asp:Label ID="creationDateBox" runat="server" Text="" Style="display: block"></asp:Label>

    <asp:Button ID="createButton" runat="server" Text="Create User" OnClick="CreateButton_Click" />
    <asp:Button ID="updateButton" runat="server" Text="Update User" OnClick="UpdateButton_Click" />
    <asp:Button ID="deleteButton" runat="server" Text="Delete User" OnClick="DeleteButton_Click" />

    <asp:Label ID="serverErrors" runat="server" Text="X"></asp:Label>
    <asp:ValidationSummary ID="vsMainAdd" runat="server" ShowMessageBox="True" ShowSummary="false"/>
    <asp:Label ID="feedbackText" runat="server" Text="X"></asp:Label>
</asp:Content>

