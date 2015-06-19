<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="ICT4Events.Post.CreatePost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <input id="inputFile" type="file" runat="server" />
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Create" OnClick="BtnUpload_Click" />

    </asp:Content>