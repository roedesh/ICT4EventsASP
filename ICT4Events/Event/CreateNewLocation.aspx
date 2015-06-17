<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewLocation.aspx.cs" Inherits="ICT4Events.CreateNewLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Maak hier een nieuwe locatie:</h1>
            <br />
        <h2>Zoeken naar locaties of maak er een aan</h2>
            <asp:DropDownList ID="ddlAllLocations" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnCreate" runat="server" Text="Maak locatie aan" OnClick="btnCreate_Click"/>
        <asp:Button ID="btnCancel" runat="server" Text="Ga terug" OnClick="btnCancel_Click"/>
        <hr />
        <br />
        <h2>Naam:</h2>
        <asp:TextBox ID="tbLocationName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Straat / Straatnummer:</h2>
        <asp:TextBox ID="tbStreet" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <h2>Postcode:</h2>
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <h2>Plaats:</h2>
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>
</asp:Content>
