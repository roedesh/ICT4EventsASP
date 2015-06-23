<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ICT4Events.Post.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="BtnBack" runat="server" Text="Terug" OnClick="BtnBack_Click" />
    <h1>
        <asp:Literal ID="litFile" runat="server" />
    </h1>
    <h2>Bestandsinformatie:</h2>
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_Preview" runat="server" Text="Voorbeeld:"></asp:Label>
            </td>
            <td>
                <asp:Image ID="img_Preview" runat="server" AlternateText="Voorbeeld niet beschikbaar." Width="256px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_UploaderText" runat="server" Text="Uploader:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_Uploader" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_DateText" runat="server" Text="Datum:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_Date" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_SizeText" runat="server" Text="Grootte:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_Size" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_LikesText" runat="server" Text="Aantal likes:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_Likes" runat="server"></asp:Label>
            </td>
        </tr>
        <% if (IsLoggedInAsAdmin)
           {%>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_FlagsText" runat="server" Text="Aantal flags:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_Flags" runat="server"></asp:Label>
            </td>
        </tr>
        <% }%>
    </table>
    <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="BtnLike_Click" />
    <asp:Button ID="btnFlag" runat="server" Text="Ongewenst" OnClick="BtnFlag_Click" />
    <asp:Button ID="btnReply" runat="server" Text="Reageer" CssClass="button" OnClick="BtnReply_Click" />
    <asp:Button ID="BtnDownload" runat="server" OnClick="BtnDownload_Click" Text="Download" />
    <% if (IsLoggedInAsAdmin)
       {%>
    <asp:Button ID="btnDel" CommandName="Delete" runat="server" Text="Verwijder" OnClick="BtnDel_Click" />
    <% }%>
    <br />
    <h2 style="padding-top: 48px">Reacties:</h2>
    <asp:Repeater ID="repMessages" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="border: 1px solid #D3D3D3; margin-bottom: 16px">
                <div style="margin-left: 16px">
                    <table>
                        <% if (IsLoggedInAsAdmin)
                           {%>
                        <tr>
                            <td><b><%#Eval("Titel")%></b> door <b><%#Eval("Author")%></b>, geplaatst op <b><%#Eval("Datum") %></b> -  <b><%#Eval("Likes")%></b> likes <b><%#Eval("Flags")%></b> flags</td>
                        </tr>
                        <% }%>
                        <% else
                           {%>
                        <tr>
                            <td><b><%#Eval("Titel")%></b> door <b><%#Eval("Author")%></b>, geplaatst op <b><%#Eval("Datum") %></b> -  <b><%#Eval("Likes")%></b> likes</td>
                        </tr>
                        <% }%>
                        <tr>
                            <td style="padding-left: 24px"><%#Eval("Inhoud") %></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnMLike" CommandName="Like" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Like" runat="server" />
                    <asp:Button ID="btnMFlag" CommandName="Flag" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Ongewenst" runat="server" />
                    <asp:Button ID="btnMReply" CommandName="Reply" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Reageer" runat="server" />
                    <% if (IsLoggedInAsAdmin)
                       {%>
                    <asp:Button ID="btnMDel" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Verwijder" runat="server" />
                    <% }%>
                </div>
                <asp:Repeater ID="repsubmessages" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div style="border: 1px solid #D3D3D3; margin: 16px 1px 1px 48px">
                            <table>
                                <% if (IsLoggedInAsAdmin)
                                   {%>
                                <tr>
                                    <td><b><%#Eval("Titel")%></b> door <b><%#Eval("Author")%></b>, geplaatst op <b><%#Eval("Datum") %></b> -  <b><%#Eval("Likes")%></b> likes <b><%#Eval("Flags")%></b> flags</td>
                                </tr>
                                <% }%>
                                <% else
                                   {%>
                                <tr>
                                    <td><b><%#Eval("Titel")%></b> door <b><%#Eval("Author")%></b>, geplaatst op <b><%#Eval("Datum") %></b> -  <b><%#Eval("Likes")%></b> likes</td>
                                </tr>
                                <% }%>
                                <tr>
                                    <td style="padding-left: 24px"><%#Eval("Inhoud") %></td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="btnMLike" CommandName="Like" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Like" runat="server" />
                            <asp:Button ID="btnMFlag" CommandName="Flag" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Ongewenst" runat="server" />
                            <% if (IsLoggedInAsAdmin)
                               {%>
                            <asp:Button ID="btnMDel" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click" Text="Verwijder" runat="server" />
                            <% }%>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
