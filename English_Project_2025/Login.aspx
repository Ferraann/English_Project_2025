<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="English_Project_2025.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login Hotel | English Project 2025 @ Javier Acevedo Y Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Login.css" rel="stylesheet" />
</head>
<body>

    <header>
        <a href="Homepage.aspx"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
        <nav>
            <ul>
                <li><a href="#"><h3>Log in</h3></a></li>
            </ul>
        </nav>
    </header>

    <main>  
        <div class="login-container">
            <h1>Log In</h1>
            <form id="form1" runat="server">
                <asp:TextBox ID="UsernameTextBox" runat="server" Placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
                <asp:Button ID="Button1" class="btn-log-in" runat="server" Text="Login" OnClick="Button1_Click" />
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
                <a href="#">Forgot password?</a>
            </form>
        </div>
    </main>

    <footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
