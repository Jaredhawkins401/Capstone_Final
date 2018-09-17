<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobForm.aspx.cs" Inherits="Capstone_Final.Views.JobForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="jobIDLabel" runat="server" Text="Job ID"></asp:Label>
    <asp:Label ID="jobIDBox" runat="server" Text=""></asp:Label>

    <asp:Label ID="customerIDLabel" runat="server" Text="Customer ID"></asp:Label>
    <asp:Label ID="customerIDBox" runat="server" Text=""></asp:Label>

    <asp:Calendar ID="startDatePicker" runat="server"></asp:Calendar>

    <asp:Calendar ID="estimatedCompletionDatePicker" runat="server"></asp:Calendar>

    <asp:Calendar ID="completionDatePicker" runat="server"></asp:Calendar>

    <!-- Estimated Job Cost -->
    <asp:Label ID="estimatedJobCostLabel" runat="server" Text="Estimated Job Cost" Style="display: block"></asp:Label>
    <asp:TextBox ID="estimatedCostBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:CompareValidator ID="estimatedCostValid" runat="server" ControlToValidate="estimatedCostBox" Type="Currency"
        Operator="DataTypeCheck" ErrorMessage="Value needs to be a dollar amount" />
    <asp:RequiredFieldValidator ID="estimatedJobRequired" runat="server" ControlToValidate="estimatedCostBox" ErrorMessage="Please enter in an estimated job cost" />

    <!-- Completed Job Cost -->
    <asp:Label ID="completedJobCostLabel" runat="server" Text="Completed Job Cost" Style="display: block"></asp:Label>
    <asp:TextBox ID="completedCostBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:CompareValidator ID="completedCostValid" runat="server" ControlToValidate="completedCostBox" Type="Currency"
        Operator="DataTypeCheck" ErrorMessage="Value needs to be a dollar amount" />
    <asp:RequiredFieldValidator ID="completedJobRequired" runat="server" ControlToValidate="completedCostBox" ErrorMessage="Please enter in an estimated job cost" />

    <!-- Street Address -->
    <asp:Label ID="streetLabel" runat="server" Text="Street Address" Style="display: block"></asp:Label>
    <asp:TextBox ID="streetBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="streetValid" runat="server" ControlToValidate="streetBox"
        ErrorMessage="A job must be entered" />
    
    <!-- City -->
    <asp:Label ID="cityLabel" runat="server" Text="City" Style="display: block"></asp:Label>
    <asp:TextBox ID="cityBox" runat="server" Style="display: block"></asp:TextBox>
    <asp:RequiredFieldValidator ID="cityValid" runat="server" ControlToValidate="cityBox" ErrorMessage="City needs to be filled" />

     <!-- State -->
    <asp:Label ID="stateLabel" runat="server" Text="State" style="display:block"></asp:Label>
    <asp:TextBox ID="stateBox" runat="server" style="display:block" MaxLength="2"></asp:TextBox>
    <asp:RegularExpressionValidator runat="server" ID="stateValidate" ControlToValidate="stateBox" 
        ValidationExpression="^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$"
        ErrorMessage="State field is not valid, please enter a state in this format: RI" />
    <asp:RequiredFieldValidator ID="stateRequired" runat="server" ControlToValidate="stateBox" ErrorMessage="State needs to be filled" />

    <!-- Zip -->
    <asp:Label ID="zipLabel" runat="server" Text="Zip Code" style="display:block"></asp:Label>
    <asp:TextBox ID="zipBox" runat="server" style="display:block" MaxLength="5"></asp:TextBox><a href="CustomersTable.aspx">CustomersTable.aspx</a>
    <asp:RegularExpressionValidator ID="zipValid" runat="server" ControlToValidate="zipBox"
        ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$" ErrorMessage="Zip is not correct"/>
    <asp:RequiredFieldValidator ID="zipRequiredValid" runat="server" ControlToValidate="zipBox" ErrorMessage="Zip Code needs to be filled" />


    <asp:Button ID="createButton" runat="server" Text="Create Job" OnClick="CreateButton_Click" />
    <asp:Button ID="updateButton" runat="server" Text="Update Job" OnClick="UpdateButton_Click" />
    <asp:Button ID="deleteButton" runat="server" Text="Delete Job" OnClick="DeleteButton_Click" />


    <asp:Label ID="serverErrors" runat="server" Text="X"></asp:Label>
    <asp:ValidationSummary ID="vsMainAdd" runat="server" ShowMessageBox="True" ShowSummary="false"/>
    <asp:Label ID="feedbackText" runat="server" Text="X"></asp:Label>

</asp:Content>
