<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ICT4Events.Post.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repPost" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <img src="<%#Eval("BESTANDSLOCATIE") %>" alt="image"></img>
            <table>
                <tr>
                    <th> Naam</th>
                    <th> Datum </th>
                    <th> Bestands Grootte</th>
                    </tr>
                <tr>
                    <td><%#filename%></td>
                    <td><%#Eval("DATUM") %></td>
                    <td><%#Eval("GROOTTE") %></td>
                </tr>
                </table>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <br />
       <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="BtnLike_Click" />
       <asp:Button ID="btnFlag" runat="server" Text="Flag" OnClick="BtnFlag_Click" />
    <% if (IsLoggedInAsAdmin)
                       {%>
    <asp:Button ID="btnDel" CommandName="Delete" runat="server" Text="Delete" OnClick="BtnDel_Click" />
    <% }%>
    <asp:Button ID="BtnDownload" runat="server" OnClick="BtnDownload_Click" Text="Download" />
    <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="button" OnClick="BtnReply_Click"/>
    <br />
    <br />
    <asp:Repeater ID="repMessages" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
             <table>
                 <tr>
                     <th>Titel</th>
                     <th>Datum</th>
                 </tr>
                <tr>
                    <td><%#Eval("Titel") %></td>
                    <td><%#Eval("Datum") %></td>
                </tr>
            </table>
            <br />
            <br />
            <table>
                 <tr>
                    <td><%#Eval("Inhoud") %></td>
                </tr>
            </table>
                <asp:Button ID="btnMLike" CommandName="Like" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Like" runat="server" />
                <asp:Button ID="btnMFlag" CommandName="Flag" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Flag" runat="server" />
                <asp:Button ID="btnMReply" CommandName="Reply" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Reply" runat="server" />
                      <% if (IsLoggedInAsAdmin)
                       {%>
                            <asp:Button ID="btnMDel" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Delete" runat="server" />
                    <% }%>
            <asp:Repeater ID="repsubmessages" runat="server">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                                 <table>
                 <tr>
                     <th>Titel</th>
                     <th>Datum</th>
                 </tr>
                <tr>
                    <td><%#Eval("Titel") %></td>
                    <td><%#Eval("Datum") %></td>
                </tr>
            </table>
            <br />
            <br />
            <table>
                 <tr>
                    <td><%#Eval("Inhoud") %></td>
                </tr>
            </table>
                <asp:Button ID="btnMLike" CommandName="Like" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Like" runat="server" />
                <asp:Button ID="btnMFlag" CommandName="Flag" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Flag" runat="server" />
                <asp:Button ID="btnMReply" CommandName="Reply" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Reply" runat="server" />
                    <% if (IsLoggedInAsAdmin)
                       {%>
                            <asp:Button ID="btnMDel" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' OnCommand="CommandBtn_Click"  Text="Delete" runat="server" />
                    <% }%>
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater> 
        </ItemTemplate>
        <FooterTemplate>

        </FooterTemplate>
    </asp:Repeater>
    </asp:Content>