<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewEvent.aspx.cs" Inherits="ICT4Events.CreateNewEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Maak hier een nieuw event aan:</h1>
            <br />
            <h2>Zoeken naar locaties of maak er een aan</h2>
            <asp:DropDownList ID="ddlAllLocations" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnLoadLocation" runat="server" Text="Laad locatie" OnClick="btnLoadLocation_Click"/>
        <asp:Button ID="btnCreateLocation" runat="server" Text="Maak een nieuwe locatie aan" OnClick="btnCreateLocation_Click"/>
        <br />
        <br />
        <asp:Button ID="btnCreate" runat="server" Text="Maak event aan" OnClick="btnCreate_Click"/>
        <asp:Button ID="btnCancel" runat="server" Text="Ga terug" OnClick="btnCancel_Click"/>
        <hr />
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
        <asp:TextBox ID="tbLocationName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbStreet" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" ReadOnly="true" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbZipCode" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbCity" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>

</asp:Content>
