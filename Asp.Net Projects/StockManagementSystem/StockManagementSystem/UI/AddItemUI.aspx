<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItemUI.aspx.cs" Inherits="StockManagementSystem.UI.AddItemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Item</title>
    <Style>
      .dashboard td {
            color: red;
            height: 10px;
            width: 100px;
            text-align: center;
        }
      
    </Style>
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
        <br />
        <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="categoryDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="companyDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="reorderLevelTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
