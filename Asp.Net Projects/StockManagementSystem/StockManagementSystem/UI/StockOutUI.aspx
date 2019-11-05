<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystem.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out</title>
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
        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="itemDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="reorderLevelTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="availableTextBox" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;<br />
        <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
&nbsp;<asp:TextBox ID="stockQuantityTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
    
         <br />
         <br />
         
          <asp:GridView ID="stockOutGridView"  runat="server" AutoGenerateColumns="False">
            <Columns>
              
            <asp:TemplateField HeaderText="SL">
                         <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item">
                         <ItemTemplate>
                              <asp:Label runat="server"><%#Eval("ItemName")%></asp:Label>
                         </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Company">
                         <ItemTemplate>
                              <asp:Label runat="server"><%#Eval("CompanyName")%></asp:Label>
                         </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Quantity">
                         <ItemTemplate>
                              <asp:Label runat="server"><%#Eval("Quantity")%></asp:Label>
                         </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
         <br />
         <asp:Button ID="sellButton" runat="server" OnClick="sellButton_Click" Text="Sell" />
&nbsp;&nbsp;&nbsp;
         <asp:Button ID="damageButton" runat="server" OnClick="damageButton_Click" Text="Damage" />
&nbsp;&nbsp;&nbsp;
         <asp:Button ID="lostButton" runat="server" OnClick="lostButton_Click" Text="Lost" />
    </div>        
    </form>
</body>
</html>
