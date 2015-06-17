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
        <h2>E-mailadres:</h2>
        <asp:TextBox ID="tbEmailAdress" TextMode="Email" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Gebruikersnaam:</h2>
        <asp:TextBox ID="tbUserName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <a href="ChangePassword.aspx">Klik hier om uw wachtwoord veranderen</a>
        <br />
        <h2>Voornaam:</h2>
        <br />
        <asp:TextBox ID="tbFirstName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <h2>Achternaam:</h2>
        <br />
        <asp:TextBox ID="tbLastName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <h2>Adres:</h2>
        <br />
        <asp:TextBox ID="tbStreet" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNum" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Bankrekening:</h2>
        <br />
        <asp:TextBox ID="tbBankrek" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Sla gegevens op" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder account" OnClick="btnDelete_Click" OnClientClick="Confirm()" />

    </div>
</asp:Content>
