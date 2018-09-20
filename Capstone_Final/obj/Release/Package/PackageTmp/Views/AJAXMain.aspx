<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AJAXMain.aspx.cs" Inherits="Capstone_Final.Views.AJAXMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="stats-wrapper">
        <div id="Stat1">
            <div class="stat1statistic">
         <asp:Label ID="stat1" runat="server" CssClass="" Text=""></asp:Label>
            </div>
            <div class="statHeader">
                Job Completion Estimate Accuracy
            </div>
            <div class="statText">
                <asp:Label ID="statTextBox" runat="server" Text=""></asp:Label>

            </div>
        </div>

        <div id="Stat2">
            <div class="stat2statistic">
                <asp:Label ID="stat2" runat="server" CssClass="" Text=""></asp:Label>
            </div>
            <div class="statHeader">
                Job Cost Esimate Accuracy
            </div>
            <div class="statText">
            <asp:Label ID="jobPercent" runat="server" Text="" CssClass=""></asp:Label>

            </div>
        </div>

        <div id="Stat3">
            <div class="stat3statistic">
                <asp:Label ID="stat3" runat="server" CssClass="stat3statistic" Text=""></asp:Label>
            </div>
            <div class="statHeader">
                New Customers
            </div>
            <div class="statText">
               <asp:Label ID="customersTotal" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    
</asp:Content>
