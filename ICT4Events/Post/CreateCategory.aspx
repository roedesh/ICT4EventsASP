<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="ICT4Events.Post.CreateCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 153px;
        }
        .auto-style4 {
            width: 153px;
            height: 40px;
        }
        .auto-style5 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Maak een categorie aan:</h1>
    <table class="nav-justified">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lbl_Name" runat="server" Text="Categorienaam:"></asp:Label>
                </td>
                <td class="auto-style5">
    <asp:TextBox ID="tbCategory" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lbl_ParentName" runat="server" Text="Hoort bij categorie:"></asp:Label>
                </td>
                <td class="auto-style5"> 
    <asp:DropDownList ID="ddlCategory" runat="server">
    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
    <asp:Button ID="btnCategory" runat="server" Text="Aanmaken" OnClick="BtnCategory_Click" />
        
                </td>
            </tr>
        </table>
        
</asp:Content>