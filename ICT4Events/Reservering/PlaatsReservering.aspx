<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaatsReservering.aspx.cs" Inherits="ICT4Events.Reservering.PlaatsReservering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 253px;
    }
    .auto-style3 {
        width: 253px;
        height: 30px;
    }
    .auto-style4 {
        height: 30px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Plaats een reservering voor een event</h2>
    <table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <h3>Informatie over boeker</h3>
        </td>
            <td>
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Voornaam:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbFirstName" ErrorMessage="Voornaam is verplicht!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbFirstName" ErrorMessage="Voornaam mag geen cijfers bevatten!" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label2" runat="server" Text="Tussenvoegsel:"></asp:Label>
        </td>
        <td class="auto-style4">
            <asp:TextBox ID="tbMiddleName" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbMiddleName" ErrorMessage="Tussenvoegsel mag geen cijfers bevatten!" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
        </td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Achternaam:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbLastName" ErrorMessage="Achternaam is verplicht!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbLastName" ErrorMessage="Achternaam mag geen cijfers bevatten!" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="Straat:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbStreet" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbStreet" ErrorMessage="Straat is verplicht!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbStreet" ErrorMessage="Straat mag geen cijfers bevatten!" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label5" runat="server" Text="Huisnr:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbHouseNr" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbHouseNr" ErrorMessage="Huisnummer is verplicht!"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label6" runat="server" Text="Woonplaats:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbCity" Display="Dynamic" ErrorMessage="Woonplaats is verplicht!"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label7" runat="server" Text="Bankrekeningnr:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbBankAccount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbBankAccount" Display="Dynamic" ErrorMessage="IBAN is verpicht!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbBankAccount" Display="Dynamic" ErrorMessage="Moet een geldig IBAN zijn!" ValidationExpression="[a-zA-Z]{2}[0-9]{2}[a-zA-Z0-9]{4}[0-9]{7}([a-zA-Z0-9]?){0,16}"></asp:RegularExpressionValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><h3>Informatie over de reservering</h3></td>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Evenement:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlEvent" DataTextField="NAAM" DataValueField="ID">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Begindatum:</td>
        <td>
            <asp:Calendar ID="calBeginData" runat="server" OnSelectionChanged="calBeginData_SelectionChanged"></asp:Calendar>
            <asp:CustomValidator ID="cusValBeginDate" runat="server" ErrorMessage="Datum moet later dan vandaag zijn!" OnServerValidate="cusValBeginDate_ServerValidate"></asp:CustomValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Einddatum:</td>
        <td>
            <asp:Calendar ID="calEndDate" runat="server" OnSelectionChanged="calEndDate_SelectionChanged"></asp:Calendar>
            <asp:CustomValidator ID="cusValEndDate" runat="server" ErrorMessage="Einddatum moet later zijn dan begindatum!" OnServerValidate="cusValEndDate_ServerValidate"></asp:CustomValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Plaats:</td>
        <td>
            <asp:DropDownList ID="ddPlace" runat="server" DataSourceID="sqlPlace" DataTextField="NUMMER" DataValueField="ID">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">Gebruikersnamen van de mensen die meegaan, gescheiden door een komma:</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbOtherPersons" runat="server" Width="240px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tbOtherPersons" ErrorMessage="Gebruikersnamen moeten worden gescheiden door een komma" ValidationExpression="^[a-zA-Z]+(,\s[a-zA-Z]+)*"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbOtherPersons" ErrorMessage="Aantal mensen is verplicht"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style3"></td>
        <td class="auto-style4">
            <asp:Button ID="Button1" runat="server" Text="Reservering plaatsen" OnClick="Button1_Click" />
        </td>
        <td class="auto-style4"></td>
    </tr>
</table>
<asp:SqlDataSource ID="sqlPlace" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;PLEK&quot;"></asp:SqlDataSource>
<asp:SqlDataSource ID="sqlEvent" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;EVENT&quot;"></asp:SqlDataSource>
</asp:Content>
