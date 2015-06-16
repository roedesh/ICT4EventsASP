<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageReservations.aspx.cs" Inherits="ICT4Events.Reservering.ManageReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="PERSOON_ID" HeaderText="PERSOON_ID" SortExpression="PERSOON_ID" />
            <asp:BoundField DataField="DATUMSTART" HeaderText="DATUMSTART" SortExpression="DATUMSTART" />
            <asp:BoundField DataField="DATUMEINDE" HeaderText="DATUMEINDE" SortExpression="DATUMEINDE" />
            <asp:BoundField DataField="BETAALD" HeaderText="BETAALD" SortExpression="BETAALD" />
            <asp:TemplateField HeaderText="Select">
             <ItemTemplate>
               <asp:LinkButton ID="btDelete" 
                 CommandArgument='<%# Eval("ID") %>' 
                 CommandName="Delete" runat="server">
                 Delete</asp:LinkButton>
             </ItemTemplate>
           </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;RESERVERING&quot;"></asp:SqlDataSource>
</asp:Content>
