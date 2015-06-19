<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewLocation.aspx.cs" Inherits="ICT4Events.CreateNewLocation" %>
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
        <h1>Maak hier een nieuwe locatie of verwijder een bestaande locatie:</h1>

        <asp:DropDownList ID="ddlAllLocations" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnLoad" runat="server" Text="Laad Locatie" OnClick="BtnLoad_Click" />
        <asp:Button ID="btnCreate" runat="server" ValidationGroup="create"  Text="Maak locatie aan" OnClick="BtnCreate_Click" OnClientClick="Confirm()"/>
        <asp:Button ID="btnCancel" runat="server" Text="Ga terug" OnClick="BtnCancel_Click"/>
        <hr />
        <br />
        <h2>Naam:</h2>
        <asp:TextBox ID="tbLocationName" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqLocationNameCreate" ControlToValidate="tbLocationName" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <br />
        <h2>Straat / Straatnummer:</h2>
        <asp:TextBox ID="tbStreet" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:TextBox ID="tbStreetNr" runat="server" Height="25px" Width="50px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqStreetNrCreate" ControlToValidate="tbStreet" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:CompareValidator runat="server" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ControlToValidate="tbStreetNr" ErrorMessage="Dit veld mag alleen uit nummers bestaan" />
        <br />
        <h2>Postcode:</h2>
        <asp:TextBox ID="tbZipCode" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="reqZipCodeCreate" ControlToValidate="tbZipCode" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="valZipCode" 
                                        runat="server" 
                                        ControlToValidate="tbZipCode"
                                        ErrorMessage="Postcode is ongeldig. Postcode moet van formaat 1234AA zijn" 
                                        SetFocusOnError="True" 
                                        ValidationExpression="/^[1-9][0-9]{3}[\s]?[A-Za-z]{2}$/i">*</asp:RegularExpressionValidator>
        <br />
        <h2>Plaats:</h2>
        <asp:TextBox ID="tbCity" runat="server" Height="25px" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="create" ID="RequiredFieldValidator1" ControlToValidate="tbStreetNr" runat="server" ErrorMessage="Dit veld is verplicht"></asp:RequiredFieldValidator>
        </div>
</asp:Content>
