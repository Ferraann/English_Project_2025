<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="English_Project_2025.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Page Hotel | English Project 2025 @ Javier Acevedo AND Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Client.css" rel="stylesheet" />
</head>
<body>

<header>
    <a href="HomepageLoged.aspx"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
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
        
        <h2 class="section-title">Personal Data</h2>
        <div class="info-container">           
            <div class="name">
                <h3>Name:</h3>
                <asp:Label ID="LabelClientName" Text="i" runat="server"></asp:Label>
            </div>
       
            <div class="surname">
                 <h3>Surname:</h3>
                 <asp:Label ID="LabelClientSurname" Text="i" runat="server"></asp:Label>
            </div>

            <div class="DOB">
                 <h3>Date of born:</h3>
                 <asp:Label ID="LabelClientDOB" Text="i" runat="server"></asp:Label>
            </div>

            <div class="phone">
                 <h3>Phone:</h3>
                 <asp:Label ID="LabelClientPhone" Text="i" runat="server"></asp:Label>
            </div>

            <div class="address">
                 <h3>Address:</h3>
                 <asp:Label ID="LabelClientAddress" Text="i" runat="server"></asp:Label>
            </div>

            <div class="email">
                 <h3>Email:</h3>
                 <asp:Label ID="LabelClientEmail" Text="i" runat="server"></asp:Label>
            </div>        
       </div>

        <span class="separator"></span>
       
        
        <h2 class="section-title">My reservations</h2>
        
        <div class="info-container_2">
            <div id="ReservationsContainer" runat="server"></div>
        </div>
    </div>    
</main>

<footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
