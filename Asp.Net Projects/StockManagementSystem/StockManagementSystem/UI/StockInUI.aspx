<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementSystem.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock In</title>
     <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="../vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />
    <link href="../Styles/sb-admin.min.css" rel="stylesheet" />
    <link href="../Styles/table-center.css" rel="stylesheet" />
</head>
<body id="page-top">
    
     <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

        <a class="navbar-brand mr-1" href="#">Stock Management System</a>

        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" href="#">
            <i class="fas fa-bars"></i>
        </button>

     </nav>
    
    <div id="wrapper">
    
     <ul class="sidebar navbar-nav">
            
       <li class="nav-item active">
        <a class="nav-link" href="StockInUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Stock In</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="StockOutUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Stock Out</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddItemUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Add Item</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddCategoryUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Add Category</span> 

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddCompanyUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Add Company</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="ItemStatusUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>Item Summary</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="ViewSalesUI.aspx">
          <i class="fas fa-fw fa-table"></i>
          <span>View Sales</span>

        </a>
       </li> 
    </ul>
            
    <div id="content-wrapper">
    <form id="form1" runat="server">
    
     <div class="card mb-3">
          <div class="card-header">
           Stock-In Item
           </div>
          <div class="card-body">
            <div class="form-group">
            <table class="center">
               <tr>
                   <td><label for="companyDropDownList">Company</label></td>
                   <td></td>
                   <td>
                         <asp:DropDownList CssClass="form-control"  ID="companyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
                   </td>
               </tr>
                 <tr>
                   <td><label for="itemDropDownList">Item</label></td>
                   <td></td>
                   <td>
                       <asp:DropDownList CssClass="form-control"  ID="itemDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
                   </td>
               </tr>
                 <tr>
                   <td><label >Reorder Level</label></td>
                   <td></td>
                   <td>
                      <asp:TextBox CssClass="form-control"  ID="reorderLevelTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                   </td>
               </tr>
                <tr>
                   <td><label >Available Quantity</label></td>
                   <td></td>
                   <td><asp:TextBox CssClass="form-control"  ID="availableTextBox" runat="server" ReadOnly="True"></asp:TextBox></td>
               </tr>
                 <tr>
                   <td><label for="stockQuantityTextBox">Stock in Quantity</label></td>
                   <td></td>
                   <td> <asp:TextBox CssClass="form-control" placeholder="Enter Stock In Quantity"  ID="stockQuantityTextBox" runat="server"></asp:TextBox></td>
               </tr>
                <tr>
                   <td></td>
                    <td></td>
                    <td> <asp:Button CssClass="btn btn-primary btn-block"   ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" /></td>
                </tr>
            </table>
            </div>
          </div>
          <div class="card-footer small text-muted"> <asp:Label ID="messageLabel" runat="server"></asp:Label> </div>
        </div>

    </form>
     </div>
     <footer class="sticky-footer">
        <div class="container my-auto">
          <div class="copyright text-center my-auto">
            <span>Copyright © Personal Stock Management System</span>
            <br />
            <span>Developed by Mahi Al Jawad and Team O(n!)</span>
          </div>
        </div>
      </footer>   
    
    </div>
    
    <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
    </a>
    <!-- Bootstrap core JavaScript-->
            
  <script src="../vendor/jquery/jquery.min.js"></script>
  <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Page level plugin JavaScript-->
  <script src="../vendor/chart.js/Chart.min.js"></script>
  <script src="../vendor/datatables/jquery.dataTables.js"></script>
  <script src="../vendor/datatables/dataTables.bootstrap4.js"></script>

  <!-- Custom scripts for all pages-->
  
   <script src="../Scripts/sb-admin.min.js"></script>

  <!-- Demo scripts for this page-->
  <script src="../Scripts/demo/datatables-demo.js"></script>
  <script src="../Scripts/demo/chart-area-demo.js"></script>
</body>
</html>
