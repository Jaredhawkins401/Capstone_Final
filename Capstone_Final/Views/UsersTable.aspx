﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersTable.aspx.cs" Inherits="Capstone_Final.Views.UsersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="searchLabel" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>

    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox" runat="server">
    </asp:DropDownList>
 
        <asp:GridView ID="userView" runat="server" CssClass="table">
            <Columns>
                <asp:BoundField DataField="accountName" HeaderText="Account Name" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="creationDate" HeaderText="Creation Date" ReadOnly="true"  dataformatstring="{0:MMMM d, yyyy}" htmlencode="false" />
                
                <asp:HyperLinkField DataNavigateUrlFields="userID" DataNavigateUrlFormatString="UserForm.aspx?userID={0}" Text="Edit" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        <br />

</asp:Content>
