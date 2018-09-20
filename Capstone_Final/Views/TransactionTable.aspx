<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="TransactionTable.aspx.cs" Inherits="Capstone_Final.Views.TransactionTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="searchLabel" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>


    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox" runat="server">
    </asp:DropDownList>

        <asp:GridView ID="transactionView" runat="server" CssClass="table">
            <Columns>
                <asp:BoundField DataField="jobID" HeaderText="Job ID" ReadOnly="true" />
                <asp:BoundField DataField="userID" HeaderText="User ID" ReadOnly="true" />
                <asp:BoundField DataField="payment" HeaderText="Payment" />
                <asp:BoundField DataField="originalJobCost" HeaderText="Original Job Cost" />
                <asp:BoundField DataField="newJobCost" HeaderText="New Job Cost" />
                
                <asp:HyperLinkField DataNavigateUrlFields="transactionID" DataNavigateUrlFormatString="TransactionForm.aspx?transactionID={0}" Text="Edit" />
  
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
    <asp:Label ID="feedbackText" runat="server" Text="" />
        <br />
</asp:Content>
