<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogUI.aspx.cs" Inherits="StockManagementSystem.UI.UserLogUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Session Log</title>
    <link href="../Styles/error-message-styling.css" rel="stylesheet" />
    <link href="../Styles/message-label-color.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
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
           <ul class="navbar-nav ml-auto ml-md-0-right">

      <li class="nav-item dropdown no-arrow active">
        <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <i class="fas fa-user-circle fa-fw"></i>
        </a>
        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">
         
          <a class="dropdown-item" href="UserLogUI.aspx">User Log</a>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" href="LogoutUI.aspx">Logout</a>
        </div>
      </li>

    </ul>

     </nav>
     <div id="wrapper">
        
   <ul class="sidebar navbar-nav">
            
       <li class="nav-item">
        <a class="nav-link" href="StockInUI.aspx">
         <i class="fas fa-arrow-down"></i>
          <span>Stock In</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="StockOutUI.aspx">
          <i class="fas fa-arrow-up"></i>
          <span>Stock Out</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddItemUI.aspx">
         <i class="fas fa-marker"></i>
          <span>Add Item</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddCategoryUI.aspx">
        <i class="fas fa-cogs"></i>
          <span>Setup Category</span> 

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="AddCompanyUI.aspx">
         <i class="fas fa-id-card-alt"></i>
          <span>Setup Company</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="ItemStatusUI.aspx">
         <i class="far fa-list-alt"></i>
          <span>Item Summary</span>

        </a>
       </li> 
        <li class="nav-item">
        <a class="nav-link" href="ViewSalesUI.aspx">
         <i class="fas fa-clock"></i>
          <span>View Sales</span>

        </a>
       </li> 
    </ul>
        
    <div id="content-wrapper">

    <form id="form1" runat="server">
        
     <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>
          User Session Log

          </div>
          <div class="card-body">
            <div class="table-responsive">
                <asp:GridView  width="100%" cellspacing="0" CssClass="table table-bordered" OnRowDataBound="sessionGridView_OnRowDataBound" ID="sessionGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="sessionGridView_SelectedIndexChanged">
                    <Columns>
                         <asp:TemplateField HeaderText="SL#">
                         <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label runat="server"><%#Eval("Username") %></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Session Start Time">
                        <ItemTemplate>
                            <asp:Label runat="server"><%#Eval("StartTime") %></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Session End Time">
                        <ItemTemplate>
                            <asp:Label runat="server"><%#Eval("EndTime") %></asp:Label>
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

   <script src="../Scripts/jquery-ui.js"></script>
  <script src="../Scripts/jquery-3.4.1.js"></script>
  <script src="../Scripts/jquery-ui-1.12.1.min.js"></script> 
             
  <%--<script src="../vendor/jquery/jquery.min.js"></script>--%>
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
          $("#sessionGridView").DataTable();

      });

</script>
</body>
</html>
