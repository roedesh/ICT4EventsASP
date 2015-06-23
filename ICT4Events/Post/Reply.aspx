<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="ICT4Events.Post.Reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="label"></asp:Label>
    <br />
    <asp:TextBox ID="tbTitle" runat="server" Width="525px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle" CssClass="form-error" ErrorMessage="Titel is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="lblContent" runat="server" Text="Bericht:" CssClass="label"></asp:Label>
    <br />
    <asp:TextBox ID="tbContent" runat="server" Height="100px" Width="525px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbContent" CssClass="form-error" ErrorMessage="Inhoud is verplicht!" Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnSend" runat="server" Text="Reply" CssClass="button" OnClick="BtnReply_Click"/>
    </asp:Content>