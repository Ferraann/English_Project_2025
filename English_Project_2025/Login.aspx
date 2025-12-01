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
        <a href="#"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
        <nav>
            <ul>
                <li><a href="#"><h3>Log in</h3></a></li>
            </ul>
        </nav>
    </header>

    <main>  
        <div class="login-container">
            <h1>Log In</h1>
            <form action="Login.aspx.cs" method="post">
                <input id="POST-userna e" type="text" name="username" placeholder="Username" />
                <input id="POST-password" type="password" name="password" placeholder="Password" />
                <input class="btn-log-in" type="submit" value="Log In" />
                <label id="error"></label>
                <a href="#">Forgot password?</a>
            </form>
        </div>
    </main>

    <footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
