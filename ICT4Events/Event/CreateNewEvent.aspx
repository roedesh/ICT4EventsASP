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
        <asp:Button ID="btnCreateLocation" runat="server" Text="Locatie beheer" OnClick="btnCreateLocation_Click"/>
        <br />
        <br />
        <asp:Button ID="btnCreate" ValidationGroup="create" runat="server" Text="Maak event aan" OnClick="btnCreate_Click"/>
        <asp:Button ID="btnCancel" runat="server" Text="Ga terug" OnClick="btnCancel_Click"/>
        <hr />
        <br />
        <h2>Event naam:</h2>
        <asp:TextBox ID="tbEventname" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqEventNameCreate" ControlToValidate="tbEventname" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <br />
        <h2>Datum:</h2>
        <asp:TextBox ID="tbStartDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqEventStartDateCreate" ControlToValidate="tbStartDate" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CustomValidator runat="server" Display="Dynamic" ID="valDateRangeStart" ValidationGroup="save" ControlToValidate="tbStartDate" onservervalidate="valDateRange_ServerValidate"  ErrorMessage="Vul een geldige datum in" />
        <br />
        <asp:TextBox ID="tbEndDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqEventEndDateCreate" ControlToValidate="tbEndDate" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CustomValidator runat="server" Display="Dynamic" ID="valDateRangeEnd"  ValidationGroup="save" ControlToValidate="tbEndDate" onservervalidate="valDateRange_ServerValidate" ErrorMessage="Vul een geldige datum in" />
        <asp:CustomValidator runat="server" Display="Dynamic" ID="CompareDate"  ValidationGroup="save" ControlToValidate="tbEndDate" onservervalidate="valDateCompare_ServerValidate" ErrorMessage="Let op! Eind datum moet na start datum zijn" />
        <br />
        <h2>Maximaal aantal bezoekers:</h2>
        <asp:TextBox ID="tbMaxVis" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqEventMaxVisCreate" ControlToValidate="tbMaxVis" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CompareValidator runat="server" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbMaxVis" ErrorMessage="Vul een geldig getal in" />
        <br />
        <h2>Adres:</h2>
        <asp:TextBox ID="tbLocationName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqEventLocationCreate" ControlToValidate="tbLocationName" runat="server" ErrorMessage="Deze velden zijn verplicht. Laat een locatie in om deze velden te vullen"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tbStreet" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" ReadOnly="true" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbZipCode" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbCity" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        </div>
</asp:Content>
