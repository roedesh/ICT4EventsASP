<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ICT4Events.Account.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Hieronder ziet u uw gebruik- en contactgegevens</h1>
        <br />
        <h2>Gebruikersnaam:</h2>
        <asp:TextBox ID="tbUserName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbUserName"
            ErrorMessage="Dit veld is verplicht." />
        <a href="ChangePassword.aspx">Klik hier om uw wachtwoord veranderen</a>
        <br />
        <h2>Oud Wachtwoord:</h2>
        <br />
        <asp:TextBox ID="tbOldPassword" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFirstName"
            ErrorMessage="Dit veld is verplicht." />
        <h2>Nieuw Wachtwoord:</h2>
        <br />
        <asp:TextBox ID="tbNewPassword" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLastName"
            ErrorMessage="Dit veld is verplicht." />
        <br />
        <h2>Herhaal nieuw Wachtwoord:</h2>
        <br />
        <asp:TextBox ID="tbNewPasswordRe" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLastName"
            ErrorMessage="Dit veld is verplicht." />
        <asp:CompareValidator ID="CompareValidator1" ControlToCompare="tbNewPassword" runat="server" ErrorMessage="Wachtwoord komt niet overeen"></asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Wachtwoord opslaan" />  
    
    </div>
</asp:Content>
