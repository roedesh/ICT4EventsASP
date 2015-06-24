<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="ICT4Events.Post.Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 73px;
            height: 32px;
        }
        .auto-style2 {
            width: 73px;
            height: 38px;
        }
        .auto-style3 {
            height: 38px;
        }
        .auto-style4 {
            width: 73px;
            height: 120px;
        }
        .auto-style5 {
            height: 120px;
        }
        .auto-style6 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Plaats een reactie:</h1>
    <table class="nav-justified">
        <tr>
            <td class="auto-style2">
    <asp:Label ID="lblTitle" runat="server" Text="Titel"></asp:Label>
            </td>
            <td class="auto-style3">
    <asp:TextBox ID="tbTitle" runat="server" Width="525px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle" CssClass="form-error" ErrorMessage="Titel is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style4">

    <asp:Label ID="lblContent" runat="server" Text="Bericht:"></asp:Label>
            </td>
            <td class="auto-style5">
    <asp:TextBox ID="tbContent" runat="server" Height="100px" Width="525px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbContent" CssClass="form-error" ErrorMessage="Inhoud is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style6">
    <asp:Button ID="btnSend" runat="server" Text="Plaats" CssClass="button" OnClick="BtnReply_Click" />
            </td>
            <td class="auto-style6"></td>
        </tr>
    </table>
    </asp:Content>
