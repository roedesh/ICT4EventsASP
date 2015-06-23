<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Category.aspx.cs" Inherits="ICT4Events.Post.Category" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repMainCat" runat="server">
        <HeaderTemplate>
            <h1>Hoofdcategorieën:</h1>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="Categoryurl" runat="Server" Text='<%#Eval("Naam") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:HyperLink>
            <br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="repSubCat" runat="server" OnItemDataBound="RepSubCat_ItemDataBound">
        <HeaderTemplate>
            <asp:Button ID="BtnBack" runat="server" Text="Terug" Onclick="BtnBack_Click"/>
            <h1>
                <asp:Literal ID="litCategory" runat="server" /></h1>
            <h2>Subcategoriëen:</h2>
            <asp:Label ID="lbl_NoCategories" runat="server" Text="Er is geen subcategorie gevonden." Visible="false"></asp:Label>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="Categoryurl" runat="Server" Text='<%#Eval("Naam") %>' NavigateUrl='<%#("Category.aspx?catid="+Eval("BIJDRAGE_ID" )) %>'><%#Eval("NAAM") %></asp:HyperLink>
            <br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Button ID="BtnCreateCat" runat="server" Text="Categorie toevoegen" OnClick="BtnCreateCat_Click" />
    <% if (IsLoggedInAsAdmin)
       {
           if (C != string.Empty)
           {%>
    <asp:Button ID="btnDel" Text="Categorie verwijderen" runat="server" OnClick="BtnDel_Click" />
    <%}
       }%>
    <asp:Repeater ID="repFile" runat="server" OnItemDataBound="RepFile_ItemDataBound">
        <HeaderTemplate>
            <h2>Bestanden:</h2>
            <asp:Label ID="lbl_NoFiles" runat="server" Text="Er is geen bestand gevonden." Visible="false"></asp:Label>
            <table id="postTable">
                <tr>
                    <% if (FilesFound)
                       {%>
                    <th>Naam</th>
                    <th>Uploader</th>
                    <th>Datum</th>
                    <th style="padding-right: 32px">Aantal likes</th>
                    <% if (IsLoggedInAsAdmin)
                       {%>
                    <th>Aantal flags</th>
                    <%}
                       }%>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="padding-right: 48px">
                    <asp:HyperLink ID="Posturl" runat="Server" Text='<%#Eval("NAAM") %>' NavigateUrl='<%#("Post.aspx?postid="+Eval("ID")) %>'><%#Eval("NAAM") %></asp:HyperLink>
                </td>
                <td style="padding-right: 48px">
                    <asp:Label ID="lbl_Uploader" runat="server" Text='<%#Eval("UPLOADER") %>'></asp:Label>
                </td>
                <td style="padding-right: 48px">
            <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("DATUM") %>'></asp:Label>
                </td>
                <td style="padding-right: 48px">
            <asp:Label ID="lbl_Likes" runat="server" Text='<%#Eval("LIKES") %>'></asp:Label>
                </td>
                <td style="padding-right: 48px">
            <% if (IsLoggedInAsAdmin)
               {%>
            <asp:Label ID="lbl_Flags" runat="server" Text='<%#Eval("FLAGS") %>'></asp:Label>
            <%}%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <% if (!IsMainCategory)
       { %>
    <asp:Button ID="btnCreatePost" runat="server" OnClick="BtnCreatePost_Click" Text="Bestand uploaden" />
    <%}
    %>
</asp:Content>
