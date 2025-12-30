<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="English_Project_2025.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Page Hotel | English Project 2025 @ Javier Acevedo AND Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Client.css" rel="stylesheet" />
</head>
<body>

    <!-- Header -->
<header>
    <!-- Enlace que lleva al HomepageLoged y la iamgen de logo. El alt es como una descripcion de la imagen -->
    <a href="HomepageLoged.aspx"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
    <!-- Nav -->
    <nav>
        <ul>
            <li>
                <!-- Label donde irá el nombre del usaurio -->
                <asp:Label ID="LabelName" Text="text" runat="server" />
                <!-- Icono de logout -->
                <a href="Logout.aspx" id="logout"> <img src="img/logout.png" alt="Logout icon" /> </a>
            </li>
        </ul>
    </nav>
</header>

    <!-- Main -->
<main>  
    <!-- Cuadrado de la pagina (contenedor) -->
    <div class="content_container">
        <!-- Título de la pagina -->
        <h2 class="section-title">Personal Data</h2>

        <!-- Contenedor de la informacion del usuario -->
        <div class="info-container">    
            <!-- Div con cada informacion del usuario.
                IMPORTANTE: El label esta vacio pero TIENE id, esa id despues en el c# la usaremos para sustituir el contenido por el dato real del usaurio -->
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
       
        <!-- Título de mis reservas -->
        <h2 class="section-title">My reservations</h2>
        
        <!-- Div del contenedor de las reservas-->
        <div class="info-container_2">
            <!-- Este div es donde en c# añadiremos las reservas. A partir del id sabemos donde tienen que ir las reservas -->
            <div id="ReservationsContainer" runat="server"></div>
        </div>
    </div>    
</main>

    <!-- Header. El &copy; es © -->
<footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
