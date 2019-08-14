<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studlog.aspx.cs" Inherits="studlog" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <div>
        <form id="form1" runat="server" action="stud.aspx" method="get">
        Pesel: <input type="text" name="log" /><br />
        Hasło: <input type="password" name="pass" /><br />
        <input type="submit" value="Loguj"/>
    </form>
    </div>
    <div class="fixed"><img src="logo.png" /></div>
</body>
</html>
