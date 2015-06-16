<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToegangsControle.aspx.cs" Inherits="ICT4Events.ToegangsControle" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblBarcode" runat="server" Text="Barcode:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblSearchPerson" runat="server" Text="Naam/ID:"></asp:Label>
    <br />
    <asp:TextBox ID="tbBarcode" runat="server" onFocus="this.select()" ></asp:TextBox>
    <asp:TextBox ID="tbSearchPerson" runat="server"></asp:TextBox>
    <br />
&nbsp;<asp:Button ID="btnSearchPerson0" runat="server" Text="Zoek Persoon" Width="94px" OnClick="btnSearchPerson0_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearchPerson" runat="server" Text="Zoek Persoon" Width="94px" OnClick="btnSearchPerson_Click" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCheckInOut" runat="server" Text="Check in/uit" Width="94px" OnClick="btnCheckInOut_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Gevonden personen:"></asp:Label>
    <br />
    <asp:Button ID="btnShowAttendants" runat="server" Text="Toon alle aanwezige" Width="139px" OnClick="btnShowAttendants_Click" />
&nbsp;

    <br />
&nbsp;<asp:TextBox ID="tbBetaald" runat="server" Height="44px" ReadOnly="True" style="margin-bottom: 0px"></asp:TextBox>
&nbsp;<asp:GridView ID="gvData" runat="server" OnRowDataBound="gvData_RowDataBound" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
        </asp:GridView>
</asp:Content>
