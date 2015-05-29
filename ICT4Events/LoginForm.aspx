<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ICT4Events.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="bt_login" runat="server" Text="Button" OnClick="bt_login_Click" />    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ACCOUNTID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ACCOUNTID" HeaderText="ACCOUNTID" ReadOnly="True" SortExpression="ACCOUNTID" />
                <asp:BoundField DataField="EVENTID" HeaderText="EVENTID" SortExpression="EVENTID" />
                <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" SortExpression="USERNAME" />
                <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" />
                <asp:BoundField DataField="FULLNAME" HeaderText="FULLNAME" SortExpression="FULLNAME" />
                <asp:BoundField DataField="ADRESS" HeaderText="ADRESS" SortExpression="ADRESS" />
                <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                <asp:BoundField DataField="POSTALCODE" HeaderText="POSTALCODE" SortExpression="POSTALCODE" />
                <asp:BoundField DataField="DATEOFBIRTH" HeaderText="DATEOFBIRTH" SortExpression="DATEOFBIRTH" />
                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                <asp:BoundField DataField="PHONENUMBER" HeaderText="PHONENUMBER" SortExpression="PHONENUMBER" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;ACCOUNT&quot;"></asp:SqlDataSource>
    </form>
</body>
</html>
