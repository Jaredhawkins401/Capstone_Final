<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AJAXMain.aspx.cs" Inherits="Capstone_Final.Views.AJAXMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="stats-wrapper">
        <div id="Stat1">
            <div class="stat1statistic">
                25%
            </div>
            <div class="statHeader">
                Job Completion Estimate Accuracy
            </div>
            <div class="statText">
                Our jobs are completed 25% longer than our estimate.
            </div>
        </div>

        <div id="Stat2">
            <div class="stat2statistic">
                15%
            </div>
            <div class="statHeader">
                Job Cost Esimate Accuracy
            </div>
            <div class="statText">
                Our jobs are costing 15% more than our initial estimates.
            </div>
        </div>

        <div id="Stat3">
            <div class="stat3statistic">
                8
            </div>
            <div class="statHeader">
                New Customers
            </div>
            <div class="statText">
                We have received 8 new customer inquiries in the last 60 days.
            </div>
        </div>
    </div>
    
</asp:Content>
