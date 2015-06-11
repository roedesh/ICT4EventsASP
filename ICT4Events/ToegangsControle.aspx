﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToegangsControle.aspx.cs" Inherits="ICT4Events.ToegangsControle" %>
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
&nbsp;<asp:Button ID="btnSearchPerson0" runat="server" Text="Zoek Persoon" Width="94px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearchPerson" runat="server" Text="Zoek Persoon" Width="94px" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCheckInOut" runat="server" Text="Check in/uit" Width="94px" />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Betaalstatus:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Gevonden personen:"></asp:Label>
    <br />
    <asp:Button ID="btnShowAttendants" runat="server" Text="Toon alle aanwezige" Width="139px" />
&nbsp;<asp:Image ID="imgPaymentStatus" runat="server" Height="78px" Width="186px" BackColor="#CCCCCC" CssClass=" " ForeColor="#CCCCCC" ImageUrl="http://mineblocks.com/1/wiki/images/5/59/Empty.png" />
    <asp:ListBox ID="lbPersonInfo" runat="server" Height="77px" style="margin-top: 0px" Width="411px"></asp:ListBox>
    <br />
&nbsp;
</asp:Content>
