<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ICT4Events.Account.MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Weet u zeker dat u uw account wilt verwijderen?")) {
                confirm_value.value = "Ja";
            } else {
                confirm_value.value = "Nee";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Hieronder ziet u uw gegevens</h1>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Sla gegevens op" OnClick="BtnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder account" OnClick="BtnDelete_Click" OnClientClick="Confirm()" />
        <br />
        <hr />
        <h2>E-mailadres:</h2>
        <asp:TextBox ID="tbEmailAdress" TextMode="Email" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Gebruikersnaam:</h2>
        <asp:TextBox ID="tbUserName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Wachtwoord</h2>
        <asp:TextBox ID="tbPassword" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <a href="ChangePassword.aspx">Klik hier om uw wachtwoord veranderen</a>
        <br />
        
        

    </div>
</asp:Content>
