<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemStatusUI.aspx.cs" Inherits="StockManagementSystem.UI.ItemStatusUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Status</title>
    
    
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
        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="companyDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="categoryDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <br />
        <br />
        <asp:Label ID="messageLebel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="itemGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                 <asp:TemplateField HeaderText="SL">
                         <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("Name")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("CompanyName")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("CategoryName")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Available Quantity">
                    <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("Available")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Reorder Level">
                    <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("ReorderLevel")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
