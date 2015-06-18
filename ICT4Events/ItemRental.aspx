<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemRental.aspx.cs" Inherits="ICT4Events.ItemRental" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Leen uit:</p>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Item ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Barcode: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Datum: "></asp:Label>
    <p>
        <asp:TextBox ID="tbLeenUitItemID" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbLeenUitBarcode" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbLeenUitDatum" runat="server"></asp:TextBox>
        DD-MM-YYYY&nbsp; HH24:MI:SS</p>
    <p>
&nbsp;<asp:Button ID="btnVrijeArtikelen" runat="server" OnClick="btnVrijeArtikelen_Click" Text="Vrije artikelen" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Geleende artikelen" Width="126px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLeenUit" runat="server" OnClick="btnLeenUit_Click" Text="Leen uit" />
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Neem in" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Zoek een persoon op naam of ID: "></asp:Label>
        <asp:TextBox ID="tbLeenUitZoekPersoon" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="Zoek" />
    </p>
    <p>
        <asp:GridView ID="gvRental" runat="server" OnRowDataBound="gvRental_RowDataBound" OnSelectedIndexChanged="gvRental_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p>
        ------------------------------------------------------------------------------------------------------------------------------------------------</p>
    <p>
        Artikel toevoegen/verwijderen:</p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Artikel naam"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Prijs: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Type: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Text="Aantal: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server" Text="Verwijder een geselecteerd item: "></asp:Label>
        <asp:Button ID="btnArtikelVerwijder" runat="server" Text="Verwijder" />
    </p>
    <asp:TextBox ID="tbArtikelNaam" runat="server"></asp:TextBox>
    <asp:TextBox ID="tbArtikelPrijs" runat="server"></asp:TextBox>
    <asp:TextBox ID="tbArtikelType" runat="server"></asp:TextBox>
    <asp:TextBox ID="tbAantal" runat="server"></asp:TextBox>
    <br />
    <p>
        <asp:Button ID="Button4" runat="server" Text="Voeg toe" Width="199px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" Text="Pas aan" Width="199px" />
        <asp:GridView ID="gvArtikel" runat="server">
        </asp:GridView>
    </p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    </asp:Content>
