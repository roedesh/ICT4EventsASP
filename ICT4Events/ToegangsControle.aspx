<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToegangsControle.aspx.cs" Inherits="ICT4Events.ToegangsControle" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        
    </p>
    <p>
        <asp:Label ID="lblBarcode" runat="server" Text="Barcode:"></asp:Label>
        <asp:TextBox ID="tbBarcode" runat="server" onFocus="this.select()" ></asp:TextBox>
        <asp:Button ID="btnSearchPerson0" runat="server" Text="Zoek Persoon" OnClick="btnSearchPerson0_Click" />
    </p>
    <p>
        <asp:Label ID="lblSearchPerson" runat="server" Text="Naam/ID:"></asp:Label>
        <asp:TextBox ID="tbSearchPerson" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearchPerson" runat="server" Text="Zoek Persoon" OnClick="btnSearchPerson_Click" />
    </p>
    

    
    <p>
        <asp:Button ID="btnCheckInOut" runat="server" Text="Check in/uit" OnClick="btnCheckInOut_Click" />
        <asp:Button ID="btnShowAttendants" runat="server" Text="Toon alle aanwezige" OnClick="btnShowAttendants_Click" />
    </p>
    
    <p>
        <asp:TextBox ID="tbBetaald" runat="server" Height="44px" ReadOnly="True" style="margin-bottom: 0px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Gevonden personen:"></asp:Label>
    </p>
    
<asp:GridView ID="gvData" runat="server" OnRowDataBound="gvData_RowDataBound" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
        </asp:GridView>
</asp:Content>
