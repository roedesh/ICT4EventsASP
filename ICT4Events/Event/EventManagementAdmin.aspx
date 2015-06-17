<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventManagementAdmin.aspx.cs" Inherits="ICT4Events.Event.EventManagementAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div>
        <h1>Zoek naar een event:</h1>
            <asp:DropDownList ID="ddlAllEvents" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnSearchEvent" runat="server" Text="Laad event" OnClick="btnSearchEvent_Click" />
        <hr />
        <br />
        <h2>EventID:</h2>
        <asp:TextBox ID="tbEventID" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Event naam:</h2>
        <asp:TextBox ID="tbEventname" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Datum:</h2>
        <asp:TextBox ID="tbStartDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbEndDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Maximaal aantal bezoekers:</h2>
        <asp:TextBox ID="tbMaxVis" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Adres:</h2>
        <asp:TextBox ID="tbLocationName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbStreet" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Sla gegevens op" OnClick="btnSave_Click" />
        <asp:Button ID="btnCreate" runat="server" Text="Maak event aan" OnClick="btnCreate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder Event" />
    </div>
</asp:Content>
