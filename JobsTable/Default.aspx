<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>   
    <title>Job List</title>   
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet"/>   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <link rel="stylesheet" href="http://cdn.datatables.net/1.10.2/css/jquery.dataTables.min.css"/></style>
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.2/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
</head>
<body style="margin:20px auto">
    <form id="form1" runat="server">
    <div class="container">
         <div class="row header" style="text-align:center;color:green">
        <h3>Jobs</h3>
        </div>
        <table id="myTable" class="table table-striped" >  
        <thead>  
          <tr>  
            <th>Client</th>  
            <th>Job Number</th>  
            <th>Job Name</th>  
            <th>Due</th>  
            <th>Status</th>  
          </tr>  
        </thead>  
        <tbody>  
            <asp:PlaceHolder id="placeHolder" runat="server"></asp:PlaceHolder>
        </tbody>  
      </table>  
    </div>
    </form>
</body>
    <script>
        $(document).ready(function () {
            $('#myTable').dataTable();
        });
</script>
</html>
