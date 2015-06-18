<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="ICT4Events.Post.CreateCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Selecteer hoofdcaterogie</h3>
    <asp:DropDownList ID="ddlCategory" runat="server">
    </asp:DropDownList>
    <br />
    <h3>Maak caterogie aan</h3> 
    <asp:TextBox ID="tbCategory" runat="server"></asp:TextBox>
    <asp:Button ID="btnCategory" runat="server" Text="Button" OnClick="btnCategory_Click" />
        
</asp:Content>