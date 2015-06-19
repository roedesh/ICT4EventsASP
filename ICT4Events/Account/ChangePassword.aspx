<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ICT4Events.Account.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Hieronder ziet u uw gebruik- en contactgegevens</h1>
        <h3>Gebruikersnaam:</h3>
        <p>
            
            <asp:TextBox ID="tbUserName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbUserName"
                ErrorMessage="Dit veld is verplicht." />
        </p>
        <h3>Oud Wachtwoord:</h3>
        <p>
            
            <asp:TextBox ID="tbOldPassword" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbOldPassword"
                ErrorMessage="Dit veld is verplicht." />
        </p>
        <h3>Nieuw Wachtwoord:</h3>
        <p>
            
            <asp:TextBox ID="tbNewPassword" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNewPassword"
                ErrorMessage="Dit veld is verplicht." />
        </p>
        <h3>Herhaal nieuw Wachtwoord:</h3>
        <p>
            
            <asp:TextBox ID="tbNewPasswordRe" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNewPasswordRe"
                ErrorMessage="Dit veld is verplicht." />
            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="tbNewPassword" runat="server" ErrorMessage="Wachtwoord komt niet overeen" ControlToValidate="tbNewPasswordRe"></asp:CompareValidator>
        </p>

        <asp:Button ID="btnSave" runat="server" Text="Wachtwoord opslaan" OnClick="BtnSave_Click" />  
    
    </div>
</asp:Content>
