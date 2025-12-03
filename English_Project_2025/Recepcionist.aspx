<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recepcionist.aspx.cs" Inherits="English_Project_2025.Recepcionista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recepcionist Page Hotel | English Project @ Javier Acevedo y Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Recepcionist.css" rel="stylesheet" />
</head>
<body>
    <header>
        <a href="Homepage.aspx"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
        <nav>
            <ul>
                <li>
                    <asp:Label ID="LabelName" Text="text" runat="server" />
                    <a href="Logout.aspx" id="logout"> <img src="img/logout.png" alt="Logout icon" /> </a>
                </li>
            </ul>
        </nav>
    </header>

    <main>  
        <div class="content_container">
            <h3>Recepcionist Dashboard</h3>
            <p>Select an action:</p>
            <div class="info-container">

            </div>
        </div>    
    </main>

    <footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
