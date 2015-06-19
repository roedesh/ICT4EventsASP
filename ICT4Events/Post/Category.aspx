<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Category.aspx.cs" Inherits="ICT4Events.Post.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repMainCat" runat="server">
    <HeaderTemplate>
        <ul>
            <h3>Categorieën:</h3>
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
                <h3>Categorieën:</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Hyperlink ID="Categoryurl" runat="Server" Text='<%#Eval("Naam") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:Hyperlink>
            <br />
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Repeater ID="repFile" runat="server">
        <HeaderTemplate>
            <ul>
                <h3>Posts</h3>
        </HeaderTemplate>
        <ItemTemplate>
             <asp:Hyperlink ID="Posturl" runat="Server" Text='<%#Eval("BESTANDSLOCATIE") %>' NavigateUrl='<%#("Post.aspx?postid="+Eval("ID")) %>'><%#Eval("NAAM") %></asp:Hyperlink>
            <br />
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
        <asp:Button ID="btnCreatePost" runat="server" OnClick="BtnCreatePost_Click" Text="Nieuwe post" />
                            <% if (IsLoggedInAsAdmin)
                               {
                                   if(C != string.Empty)
                                   {%>
                                        <asp:Button ID="btnDel" Text="Delete" runat="server" OnClick="BtnDel_Click" />
                                 <%} 
                               }%>
    </asp:Content>
