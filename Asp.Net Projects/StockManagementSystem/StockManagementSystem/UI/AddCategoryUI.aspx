<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddCategoryUI.aspx.cs" Inherits="StockManagementSystem.UI.AddCatagoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Catagory</title>
    
    
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
        
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="catagoryGridView" DataKeyNames="Name" OnRowDataBound="catagoryGridView_OnRowDataBound" OnSelectedIndexChanged="catagoryGridView_OnSelectedIndexChanged" runat="server" AutoGenerateColumns="False">
            <Columns>
            <asp:CommandField SelectText="Select" ShowSelectButton="true" Visible="false" />    
            <asp:TemplateField HeaderText="SL">
                         <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                              <asp:Label runat="server"><%#Eval("Name")%></asp:Label>
                         </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
