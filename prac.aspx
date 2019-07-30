<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prac.aspx.cs" Inherits="prac" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function zoom() {
            document.body.style.zoom = "100%" 
        }
</script>
</head>
<body onload="zoom()">
    <%
        if (Request.QueryString["pesel"] != null && Request.QueryString["nr"] != null && Request.QueryString["score"] != null)
        {
            Add_Rating();
        }
    %>
</body>
</html>
