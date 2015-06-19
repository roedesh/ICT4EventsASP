<%@ Page Title="ICT4Events - Registreren" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registreren.aspx.cs" Inherits="ICT4Events.Registreren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
            <tr>
                <td class="auto-style2">Gebruikersnaam:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbUsername" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" CssClass="form-error" ErrorMessage="Gebruikersnaam is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CheckUsername" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Gebruikersnaam is bezet!"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">E-Mail:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbEmail" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" CssClass="form-error" ErrorMessage="E-Mail is verplicht" Display="Dynamic"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="form-error" ErrorMessage="Vul een geldig e-mailadres in!" ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" OnServerValidate="CheckEmail" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email is bezet!"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Wachtwoord:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPassword" CssClass="form-error" ErrorMessage="Wachtwoord is verplicht" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Wachtwoord bevestigen:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbConfirmPassword" CssClass="form-error" ErrorMessage="Wachtwoord bevestigen is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" CssClass="form-error" ErrorMessage="Wachtwoorden moeten hetzelfde zijn" Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btSubmit" runat="server" OnClick="BtSubmit_Click" Text="Submit" />
                    <asp:Button ID="btReset" runat="server" Text="Reset" OnClick="BtReset_Click" causesValidation="false"/></td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
