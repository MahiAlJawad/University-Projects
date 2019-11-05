<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesUI.aspx.cs" Inherits="StockManagementSystem.UI.ViewSalesUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales</title>
     <Style>
      .dashboard td {
            color: red;
            height: 10px;
            width: 100px;
            text-align: center;
        }
      
    </Style>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="dashboard">
    <table>
        <tr>
            <td><a href="AddCategoryUI.aspx">Add Category</a></td>
            <td><a href="AddCompanyUI.aspx">Add Company</a></td>
            <td><a href="AddItemUI.aspx">Add Item</a></td>
            <td><a href="StockInUI.aspx">Stock In</a></td>
            <td><a href="StockOutUI.aspx">Stock Out</a></td>
            <td><a href="ItemStatusUI.aspx">Item Status</a></td>
            <td><a href="ViewSalesUI.aspx">Sales</a></td>

        </tr>
    </table>
    </div>    
    <div>
        
        <br />
        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="salesGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("ItemName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sales Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("Quantity") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>
    </form>
    <script src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>
    <script>
        $(function () {
            $('#fromDateTextBox').datepicker(
            {
                showOn: "button",
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true,
                yearRange: '1990:2100',
                buttonText: "Select Date"
            });
        });
        $(function () {
            $('#toDateTextBox').datepicker(
            {
                showOn: "button",
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true,
                yearRange: '1990:2100',
                buttonText: "Select Date"
            });
        });
    </script>
</body>
</html>
