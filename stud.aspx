<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stud.aspx.cs" Inherits="stud" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <%
        if (Request.QueryString["log"] == null || Request.QueryString["pass"] == null)
         {
             Response.Write("Nie udalo sie zalogowac");
         }
    %>
</body>
</html>
