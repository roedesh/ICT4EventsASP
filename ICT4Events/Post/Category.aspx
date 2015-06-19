<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Category.aspx.cs" Inherits="ICT4Events.Post.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnCreatePost" runat="server" OnClick="btnCreatePost_Click" Text="Post"  />
    <asp:Repeater ID="repMainCat" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <itemtemplate>
        <asp:Hyperlink ID="Categoryurl" runat="Server" Text='<%#Eval("Naam") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:Hyperlink>
    </itemtemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
        </asp:Repeater>
    <br />
    <asp:Repeater ID="repSubCat" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Hyperlink ID="Categoryurl" runat="Server" Text='<%#Eval("Naam") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:Hyperlink>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="repFile" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
             <asp:Hyperlink ID="Posturl" runat="Server" Text='<%#Eval("BESTANDSLOCATIE") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:Hyperlink>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    </asp:Content>
