<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4Events.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Login ID="Login1" runat="server" OnLoggingIn="OnLoggingIn">
            <LayoutTemplate>
                </td>
                <asp:Label ID="Label1" runat="server" Text="Gebruikersnaam:"></asp:Label>
                <br />
                <asp:TextBox ID="UserName" runat="server" Height="35" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ValidationGroup="Login1" 
                    ErrorMessage="Dit veld is verplicht." />
                <br />
                </td>
                <asp:Label ID="Label2" runat="server" Text="Wachtwoord:"></asp:Label>
                <br />
                <asp:TextBox ID="Password" TextMode="Password" runat="server" Height="35" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ValidationGroup="Login1" 
                    ErrorMessage="Dit veld is verplicht." />
                <br />
                <asp:Literal runat="server"  ID="FailureText" Text="" EnableViewState="False"></asp:Literal>
                <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="Inloggen" ValidationGroup="Login1" />
                <asp:Button ID="btnRegister" runat="server" Text="Registreren" />
            </LayoutTemplate>
        </asp:Login>




</asp:Content>
