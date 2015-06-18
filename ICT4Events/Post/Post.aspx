<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ICT4Events.Post.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repPost" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <th>ID</th>
                    <th>Account ID</th>
                    <th> Datum </th>
                    <th> Bestandslocatie</th>
                    <th> Bestands Grootte</th>
                    </tr>
                <tr>
                    <td><%#Eval("ID")%></td>
                    <td><%#Eval("ACCOUNT_ID") %></td>
                    <td><%#Eval("DATUM") %></td>
                    <td><%#Eval("BESTANDSLOCATIE") %></td>
                    <td><%#Eval("GROOTTE") %></td>
                </tr>
                </table>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" />
    <asp:Button ID="btnFlag" runat="server" Text="Flag" OnClick="btnFlag_Click" />
    <br />
    <br />
    <asp:Repeater ID="repMessages" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
             <table>
                 <tr>
                     <th>Titel</th>
                     <th>MessageID</th>
                     <th>AccountID</th>
                     <th>Datum</th>
                 </tr>
                <tr>
                    <td><%#Eval("Titel") %></td>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("ACCOUNT_ID") %></td>
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
        </ItemTemplate>
        <FooterTemplate>

        </FooterTemplate>
    </asp:Repeater>
    </asp:Content>