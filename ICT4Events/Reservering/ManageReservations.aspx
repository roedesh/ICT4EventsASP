<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageReservations.aspx.cs" Inherits="ICT4Events.Reservering.ManageReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView DataKeyNames="ID" ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        OnRowCommand="GridView1_RowCommand" 
        OnRowDataBound="GridView1_RowDataBound" 
        DataSourceID="SqlDataSource1">
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
                    CommandName="DeleteRow" runat="server">
                    Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;RESERVERING&quot;">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
