<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventManagementAdmin.aspx.cs" Inherits="ICT4Events.Event.EventManagementAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div>
        <h1>Zoek event:</h1>
        <asp:TextBox ID="tbSearchEvent" runat="server" Height="25px" Width="250px"></asp:TextBox>
            <br />
            <asp:Button ID="btnSearchEvent" runat="server" Text="Zoek event" OnClick="btnSearchEvent_Click" />
        <hr />
        <br />
        <h2>Event naam:</h2>
        <asp:TextBox ID="tbEventname" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEventName"
            ErrorMessage="Dit veld is verplicht." />
        <br />
        <h2>Adres:</h2>
        <br />
        <asp:TextBox ID="tbAddress" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbAddress"
            ErrorMessage="Dit veld is verplicht." />
        <h2>Stad:</h2>
        <br />
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbCity"
            ErrorMessage="Dit veld is verplicht." />
        <h2>Postcode:</h2>
        <br />
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbZipCode"
            ErrorMessage="Dit veld is verplicht." />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Sla gegevens op" OnClick="btnSave_Click" />
        <asp:Button ID="btnCreate" runat="server" Text="Maak event aan" OnClick="btnCreate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder Event" />
    </div>
</asp:Content>
