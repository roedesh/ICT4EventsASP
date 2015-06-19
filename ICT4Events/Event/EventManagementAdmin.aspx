<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventManagementAdmin.aspx.cs" Inherits="ICT4Events.Event.EventManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Weet u zeker dat u door wilt gaan?")) {
                confirm_value.value = "Ja";
            } else {
                confirm_value.value = "Nee";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Zoek naar een event:</h1>
        <p>
            <asp:DropDownList ID="ddlAllEvents" runat="server"></asp:DropDownList>
            <asp:Button ID="btnSearchEvent" runat="server" Text="Laad event" OnClick="btnSearchEvent_Click" />
        </p>
        <p>
            <asp:Button ID="btnSave" ValidationGroup="save" runat="server" Text="Sla veranderingen op" OnClick="btnSave_Click" OnClientClick="Confirm()"/>
            <asp:Button ID="btnDelete" ValidationGroup="delete" runat="server" Text="Verwijder event" OnClick="btnDelete_Click" OnClientClick="Confirm()"/>
            &nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnCreate" runat="server" Text="Maak event aan" OnClick="btnCreate_Click" />
        </p>
        <p>
            <h3>EventID:</h3>
            <asp:TextBox ID="tbEventID" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        </p>
        <p>
        <h3>Event naam:</h3>
        <asp:TextBox ID="tbEventname" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="save" ID="reqEventNameSave" ControlToValidate="tbEventname" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="delete" ID="reqEventNameDelete" ControlToValidate="tbEventname" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        </p>
        <p>
        <h3>Datum:</h3>
        <asp:TextBox ID="tbStartDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="save" ID="reqEventStartDateSave" ControlToValidate="tbStartDate" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CustomValidator runat="server" Display="Dynamic" ID="valDateRangeStart" ValidationGroup="save" ControlToValidate="tbStartDate" onservervalidate="valDateRange_ServerValidate"  ErrorMessage="Vul een geldige datum in" />
        </p>
        <p>
        <asp:TextBox ID="tbEndDate" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="save" ID="reqEventEndDateSave" ControlToValidate="tbEndDate" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CustomValidator runat="server" Display="Dynamic" ID="valDateRangeEnd"  ValidationGroup="save" ControlToValidate="tbEndDate" onservervalidate="valDateRange_ServerValidate" ErrorMessage="Vul een geldige datum in" />
        <asp:CustomValidator runat="server" Display="Dynamic" ID="CompareDate"  ValidationGroup="save" ControlToValidate="tbEndDate" onservervalidate="valDateCompare_ServerValidate" ErrorMessage="Let op! Eind datum moet na start datum zijn" />
        </p>
        <p>
        <h3>Maximaal aantal bezoekers:</h3>
        <asp:TextBox ID="tbMaxVis" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="save" ID="reqEventMaxVisSave" ControlToValidate="tbMaxVis" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CompareValidator runat="server" Display="Dynamic" ValidationGroup="save" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbMaxVis" ErrorMessage="Vul een geldig getal in" />
        </p>
        <p>
        <h3>Adres:</h3>
        <asp:TextBox ID="tbLocationName" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbStreet" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" ReadOnly="true" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbZipCode" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbCity" ReadOnly="true" runat="server" Height="25px" Width="250px"></asp:TextBox>
        </p>
    </div>
</asp:Content>
