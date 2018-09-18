<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="Capstone_Final.Views.CustomerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
    <asp:Label ID="customerIDLabel" runat="server" Text="ID"></asp:Label>
    <asp:Label ID="customerIDBox" runat="server" Text=""></asp:Label>

    <!-- First Name Text Box -->
    <asp:Label ID="fNameLabel" runat="server" Text="First Name" Style="display: block"></asp:Label>
    <asp:TextBox ID="fNameBox" runat="server" Style="display: block" MaxLength="16"></asp:TextBox>
    <asp:RequiredFieldValidator ID="fNameRequired" runat="server" ControlToValidate="fNameBox" ErrorMessage="First Name is required" />

    <!-- Last Name Text Box -->
    <asp:Label ID="lNameLabel" runat="server" Text="Last Name" Style="display: block"></asp:Label>
    <asp:TextBox ID="lNameBox" runat="server" Style="display: block" MaxLength="16"></asp:TextBox>
    <asp:RequiredFieldValidator ID="lNameValid" runat="server" ControlToValidate="lNameBox" ErrorMessage="Last Name is required" />

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
    <asp:TextBox ID="zipBox" runat="server" style="display:block" MaxLength="5"></asp:TextBox>
    <asp:RegularExpressionValidator ID="zipValid" runat="server" ControlToValidate="zipBox"
        ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$" ErrorMessage="Zip is not correct"/>
    <asp:RequiredFieldValidator ID="zipRequiredValid" runat="server" ControlToValidate="zipBox" ErrorMessage="Zip Code needs to be filled" />

    <!-- Email Text Box -->
        <asp:Label ID="emailLabel" runat="server" Text="E-mail" Style="display: block;"></asp:Label>
    <asp:TextBox ID="emailBox" runat="server" Style="display: block" MaxLength="20"></asp:TextBox>
    <asp:RequiredFieldValidator ID="emailValid" runat="server" ControlToValidate="emailBox" ErrorMessage="E-mail is required" />

    <asp:Button ID="createButton" runat="server" Text="Create Customer" OnClick="CreateButton_Click" />
    <asp:Button ID="updateButton" runat="server" Text="Update Customer" OnClick="UpdateButton_Click" />
    <asp:Button ID="deleteButton" runat="server" Text="Delete Customer" OnClick="DeleteButton_Click" />


    <asp:ValidationSummary ID="vsMainAdd" runat="server" ShowMessageBox="True" ShowSummary="false"/>
    <asp:Label ID="feedbackText" runat="server" Text=""></asp:Label>
</asp:Content>
