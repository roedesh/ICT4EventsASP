<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToegangsControle.aspx.cs" Inherits="ICT4Events.ToegangsControle" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        
    </p>
    <p>
        <asp:Label ID="lblBarcode" runat="server" Text="Barcode:"></asp:Label>
        <asp:TextBox ID="TbBarcode" runat="server" onFocus="this.select()" ></asp:TextBox>
        <asp:Button ID="BtnSearchPerson0" runat="server" Text="Zoek Persoon" OnClick="BtnSearchPerson0_Click" />
    </p>
    <p>
        <asp:Label ID="lblSearchPerson" runat="server" Text="Naam/ID:"></asp:Label>
        <asp:TextBox ID="TbSearchPerson" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSearchPerson" runat="server" Text="Zoek Persoon" OnClick="BtnSearchPerson_Click" />
    </p>
    

    
    <p>
        <asp:Button ID="BtnCheckInOut" runat="server" Text="Check in/uit" OnClick="BtnCheckInOut_Click" />
        <asp:Button ID="BtnShowAttendants" runat="server" Text="Toon alle aanwezige" OnClick="BtnShowAttendants_Click" />
    </p>
    
    <p>
        <asp:TextBox ID="TbBetaald" runat="server" Height="44px" ReadOnly="True" style="margin-bottom: 0px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Gevonden personen:"></asp:Label>
    </p>
    
<asp:GridView ID="GvData" runat="server" OnRowDataBound="GvData_RowDataBound" OnSelectedIndexChanged="GvData_SelectedIndexChanged">
        </asp:GridView>
</asp:Content>
