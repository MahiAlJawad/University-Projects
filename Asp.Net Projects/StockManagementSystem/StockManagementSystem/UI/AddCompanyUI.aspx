<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="AddCompanyUI.aspx.cs" Inherits="StockManagementSystem.UI.AddCompanyUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Company</title>
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
            
       <li class="nav-item">
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
        <li class="nav-item active">
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
           Add Company 
           </div>
          <div class="card-body">
            <div class="form-group">
            <table class="center">
                <tr>
                    
                    <td><label for="nameTextBox">Name</label></td>
                    <td></td>
                    <td><asp:TextBox CssClass="form-control" ID="nameTextBox" runat="server" placeholder="Enter Company Name"></asp:TextBox></td>
                </tr>
                <tr>
          
                    <td></td>
                    <td></td>
                    <td><asp:Button CssClass="btn btn-primary btn-block" ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
                </tr>

            </table>
            </div>
          </div>
          <div class="card-footer small text-muted"> <asp:Label ID="messageLabel" runat="server"></asp:Label></div>
        </div>
        
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>
            Available Companies

          </div>
          <div class="card-body">
            <div class="table-responsive">
                 <asp:GridView width="100%" cellspacing="0" CssClass="table table-bordered" ID="companyGridView" runat="server" AutoGenerateColumns="False"
                     OnRowDataBound="companyGridView_OnRowDataBound">
            <Columns>
                 
            <asp:TemplateField HeaderText="SL#">
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
          </div>
             <div class="card-footer small text-muted"></div>
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
    <script>
        $(document).ready(function () {
            $("#companyGridView").DataTable();
        });
    </script>
</body>
</html>
