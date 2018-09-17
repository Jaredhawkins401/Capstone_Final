<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersTable.aspx.cs" Inherits="Capstone_Final.Views.UsersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="searchLabel" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>

    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox" runat="server">
        <asp:ListItem Text="First Name" Value="firstName"></asp:ListItem>
        <asp:ListItem Text="Last Name" Value="lastName"></asp:ListItem>
        <asp:ListItem Text="Account NAme" Value="accountName"></asp:ListItem>
        <asp:ListItem Text="Role" Value="role"></asp:ListItem>
        <asp:ListItem Text="Creation Date" Value="creationDate"></asp:ListItem>
        <asp:ListItem Text="E-mail" Value="email"></asp:ListItem>
    </asp:DropDownList>
 
        <asp:GridView ID="userView" runat="server" >
            <Columns>
                <asp:BoundField DataField="accountName" HeaderText="Account Name" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="creationDate" HeaderText="Creation Date" ReadOnly="true" />
                
                <asp:HyperLinkField DataNavigateUrlFields="userID" DataNavigateUrlFormatString="UserForm.aspx?userID={0}" Text="Edit" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        <br />

</asp:Content>
