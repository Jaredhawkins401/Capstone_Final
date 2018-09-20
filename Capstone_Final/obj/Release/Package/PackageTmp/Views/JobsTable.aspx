<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobsTable.aspx.cs" Inherits="Capstone_Final.Views.JobsTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="searchLabel" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>

    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox" runat="server">
    </asp:DropDownList>

        <asp:GridView ID="jobView" runat="server" CssClass="table">
            <Columns>
                <asp:BoundField DataField="startDate" HeaderText="Start Date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
                <asp:BoundField DataField="estimatedCompletionDate" HeaderText="Estimated Completion Date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false" />
                <asp:BoundField DataField="completionDate" HeaderText="Completion Date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false" />
                <asp:BoundField DataField="estimatedJobCost" HeaderText="Estimated Job Cost" />
                <asp:BoundField DataField="completedJobCost" HeaderText="Completed Job Cost" />
                <asp:BoundField DataField="street" HeaderText="Street" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:BoundField DataField="state" HeaderText="State" />
                <asp:BoundField DataField="zip" HeaderText="zip" />

                
                <asp:HyperLinkField DataNavigateUrlFields="jobID" DataNavigateUrlFormatString="JobForm.aspx?jobID={0}" Text="Edit" />
                <asp:HyperLinkField DataNavigateUrlFields="jobID" DataNavigateUrlFormatString="TransactionForm.aspx?jobID={0}" Text="Create Transaction" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        <br />
</asp:Content>