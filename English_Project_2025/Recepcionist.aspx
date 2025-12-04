<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recepcionist.aspx.cs" Inherits="English_Project_2025.Recepcionista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recepcionist Page Hotel | English Project @ Javier Acevedo y Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Recepcionist.css" rel="stylesheet" />
    <script src="js/RecepcionistActions.js" defer></script>
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
            <h2>Recepcionist Dashboard</h2>
            <div class="actions-container">
                <a id="action-add-user" href="#"><h4>Add User</h4></a>
                <span class="separator"></span>

                <a id="action-add-reservation" href="#"><h4>Add Reservation To User</h4></a>                
                <span class="separator"></span>

                <a id="action-delete-user" href="#"><h4>Delete User</h4></a>
            </div>
            <div id="add-user" class="action-panel">
                add user
            </div>
            <div id="add-reservation" class="action-panel">
                add reservation
            </div>
            <div id="delete-user" class="action-panel">
                delete user
            </div>
        </div> 
    </main>

    <footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
