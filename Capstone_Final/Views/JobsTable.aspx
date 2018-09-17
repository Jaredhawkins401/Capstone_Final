<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobsTable.aspx.cs" Inherits="Capstone_Final.Views.JobsTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="searchLabel" runat="server" Text="Search Term" style="display:block"></asp:Label> 
    <asp:TextBox ID="searchBox" runat="server" style="display:block"></asp:TextBox>

    <asp:Label ID="columnLabel" runat="server" Text="Column to Search" Style="display: block"></asp:Label>
    <asp:DropDownList ID="columnBox" runat="server">
        <asp:ListItem Text="Start Date" Value="startDate"></asp:ListItem>
        <asp:ListItem Text="Estimated Completion Date" Value="estimatedCompletionDate"></asp:ListItem>
        <asp:ListItem Text="Completion Date" Value="completionDate"></asp:ListItem>
        <asp:ListItem Text="Estimated Job Cost" Value="estimatedJobCost"></asp:ListItem>
        <asp:ListItem Text="Completed Job Cost" Value="completedJobCost"></asp:ListItem>
        <asp:ListItem Text="Street" Value="street"></asp:ListItem>
        <asp:ListItem Text="City" Value="city"></asp:ListItem>
        <asp:ListItem Text="State" Value="state"></asp:ListItem>
        <asp:ListItem Text="Zip" Value="zip"></asp:ListItem>
        <asp:ListItem Text="E-mail" Value="email"></asp:ListItem>
    </asp:DropDownList>

        <asp:GridView ID="jobView" runat="server" >
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="lives" HeaderText="Lives" />
                <asp:BoundField DataField="hoursplayed" HeaderText="Hours Played" />
                <asp:BoundField DataField="health" HeaderText="HP" />
                <asp:BoundField DataField="strength" HeaderText="Strength" />
                <asp:BoundField DataField="armor" HeaderText="Armor" />
                <asp:BoundField DataField="playingsince" HeaderText="Playing Since" />
                
                <asp:HyperLinkField DataNavigateUrlFields="jobID" DataNavigateUrlFormatString="JobsForm.aspx?jobID={0}" Text="Edit" />
                <asp:HyperLinkField DataNavigateUrlFields="jobID" DataNavigateUrlFormatString="TransactionForm.aspx?jobID={0}" Text="Create Transaction" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        <br />
</asp:Content>