<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4Events.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Login ID="Login1" runat="server" OnLoggingIn="OnLoggingIn">
            <LayoutTemplate>
                <h3>Gebruikersnaam</h3>
                <asp:TextBox ID="tbUserName" runat="server" Height="35" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="rUserName"
                    ErrorMessage="Dit veld is verplicht." />

                <h3>Wachtwoord</h3>
                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" Height="35" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="rPassword"
                    ErrorMessage="Dit veld is verplicht." />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Inloggen" ValidationGroup="Login1" />
                <asp:Button ID="btnRegister" runat="server" Text="Registreren" />
            </LayoutTemplate>
        </asp:Login>

    </div>


</asp:Content>
