<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="StockManagementSystem.UI.LoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link href="../Styles/error-message-styling.css" rel="stylesheet" />
    <link href="../Styles/message-label-color.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
     <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="../vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />
    <link href="../Styles/sb-admin.min.css" rel="stylesheet" />
    <link href="../Styles/table-center.css" rel="stylesheet" />
</head>
<body class="bg-dark">
   
     <nav class="navbar navbar-expand navbar-dark static-top">
          <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" href="#">
           <i class="fas fa-store"></i>
          </button>

        <a class="navbar-brand mr-1" href="#">Stock Management System</a>

     </nav>
   
     <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Login</div>
      <div class="card-body">
        <form id="Form1" runat="server">
            
           <div class="form-group">
            <div class="form-label-group">
                <asp:TextBox class="form-control" placeholder="Enter Username" required="required" autofocus="autofocus" ID="usernameTextBox" runat="server"></asp:TextBox>
                <label for="usernameTextBox">Username</label>
            </div>
          </div>
           <div class="form-group">
            <div class="form-label-group">
                 <asp:TextBox ID="passwordTextBox" type="password"  class="form-control" placeholder="Enter Password" required="required" runat="server"></asp:TextBox>
                 <label for="passwordTextBox">Password</label>
            </div>
          </div>
           <div class="form-group">
            <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me">
                Remember Password
              </label>
            </div>
          </div>
         <asp:Button class="btn btn-primary btn-block" ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" /> 
          <div class="text-center">
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
        </div>
        </form>
      </div>
    </div>
  </div>
   
    
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
  
</body>
</html>
