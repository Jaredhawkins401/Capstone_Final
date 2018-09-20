<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="TransactionForm.aspx.cs" Inherits="Capstone_Final.Views.TransactionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="transactionID" runat="server" Text="Transaction ID"></asp:Label>
    <asp:Label ID="transactionIDBox" runat="server" Text=""></asp:Label>

    <asp:Label ID="userIDLabel" runat="server" Text="User ID"></asp:Label>
    <asp:Label ID="userIDBox" runat="server" Text=""></asp:Label>

    <asp:Label ID="jobID" runat="server" Text="Job ID"></asp:Label>
    <asp:Label ID="jobIDBox" runat="server" Text=""></asp:Label>


    <!-- Payment -->
    <asp:Label ID="paymentLabel" runat="server" Text="Payment" Style="display: block"></asp:Label>
    <asp:TextBox ID="paymentBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:CompareValidator ID="epaymentValid" runat="server" ControlToValidate="paymentBox" Type="Currency"
        Operator="DataTypeCheck" ErrorMessage="Value needs to be a dollar amount" />
    <asp:RequiredFieldValidator ID="paymentRequired" runat="server" ControlToValidate="paymentBox" ErrorMessage="Please enter a payment" />

    <!-- Original Job Cost -->
    <asp:Label ID="originalJobCostLabel" runat="server" Text="Original Job Cost" Style="display: block"></asp:Label>
    <asp:TextBox ID="originalCostBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:CompareValidator ID="coriginalCostValid" runat="server" ControlToValidate="originalCostBox" Type="Currency"
        Operator="DataTypeCheck" ErrorMessage="Value needs to be a dollar amount" />
    <asp:RequiredFieldValidator ID="originalJobRequired" runat="server" ControlToValidate="originalCostBox" ErrorMessage="Please enter in an original job cost" />

        <!-- New Job Cost -->
    <asp:Label ID="newJobCostLabel" runat="server" Text="New Job Cost" Style="display: block"></asp:Label>
    <asp:TextBox ID="newJobCostBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:CompareValidator ID="newJobCostValid" runat="server" ControlToValidate="newJobCostBox" Type="Currency"
        Operator="DataTypeCheck" ErrorMessage="Value needs to be a dollar amount" />
    <asp:RequiredFieldValidator ID="newJobCostRequired" runat="server" ControlToValidate="newJobCostBox" ErrorMessage="Please enter a new job cost" />
   

    <asp:Button ID="createButton" runat="server" Text="Create Transaction" OnClick="CreateButton_Click" />
    <asp:Button ID="updateButton" runat="server" Text="Update Transaction" OnClick="UpdateButton_Click" />
    <asp:Button ID="deleteButton" runat="server" Text="Delete Transaction" OnClick="DeleteButton_Click" />

    <asp:ValidationSummary ID="vsMainAdd" runat="server" ShowMessageBox="True" ShowSummary="false"/>
    <asp:Label ID="feedbackText" runat="server" Text=""></asp:Label>



</asp:Content>
