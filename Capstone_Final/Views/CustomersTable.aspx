<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomersTable.aspx.cs" Inherits="Capstone_Final.Views.CustomersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="searchTerm" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>

    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox"  runat="server">

    </asp:DropDownList>

    <asp:GridView ID="customerView" runat="server" CssClass="table">
        <Columns>
            <asp:BoundField DataField="firstName" HeaderText="First Name" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
            <asp:BoundField DataField="street" HeaderText="Street" />
            <asp:BoundField DataField="city" HeaderText="City" />
            <asp:BoundField DataField="state" HeaderText="State" />
            <asp:BoundField DataField="zip" HeaderText="Zip" />
            <asp:BoundField DataField="email" HeaderText="Email" />
                
     <asp:HyperLinkField DataNavigateUrlFields="customerID" DataNavigateUrlFormatString="CustomerForm.aspx?customerID={0}" Text="Edit" />
     <asp:HyperLinkField DataNavigateUrlFields="customerID" DataNavigateUrlFormatString="JobForm.aspx?customerID={0}" Text="Create Job" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        <br />

</asp:Content>
