<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountManagementAdmin.aspx.cs" Inherits="ICT4Events.Account.AccountManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <h1>Zoek account:</h1>
        <asp:TextBox ID="tbSearchUserName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:Button ID="btSearchAccount" runat="server" Text="Zoeken" OnClick="btSearchAccount_Click" />
        <hr />
        <br />
        <h2>Is geactiveerd:</h2>
        <asp:TextBox ID="tbActivated" TextMode="Email" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>E-mailadres:</h2>
        <asp:TextBox ID="tbEmailAdress" TextMode="Email" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>RankID:</h2>
        <br />
        <asp:TextBox ID="tbRank" TextMode="Number" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Gebruikersnaam:</h2>
        <asp:TextBox ID="tbUserName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Wachtwoord:</h2>
        <br />
        <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <a href="ChangePassword.aspx">Klik hier om uw wachtwoord veranderen</a>
        <br />
        <h2>Voornaam:</h2>
        <br />
        <asp:TextBox ID="tbFirstName" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Achternaam:</h2>
        <br />
        <asp:TextBox ID="tbLastName" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Leeftijd:</h2>
        <br />
        <asp:TextBox ID="tbAge" textmode="Number" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Intresses:</h2>
        <br />
        <asp:TextBox ID="tbInterests" runat="server" Height="100px" Width="400px"></asp:TextBox>

        <h2>Adres:</h2>
        <br />
        <asp:TextBox ID="tbAddress" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Stad:</h2>
        <br />
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>Postcode:</h2>
        <br />
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <h2>TelefoonNummer:</h2>
        <br />
        <asp:TextBox ID="tbPhoneNumber" TextMode="Phone" runat="server" Height="25px" Width="250px"></asp:TextBox>

        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Sla gegevens op" OnClick="btnSave_Click" />
        <asp:Button ID="btnCreate" runat="server" Text="Maak account aan" OnClick="btnCreate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder account" OnClick="btnDelete_Click" />
    </div>
</asp:Content>
