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
        <a href="Homepageloged.aspx"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
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
                <a id="action-search-user" href="#"><h4>Search User</h4></a>
            </div>

            <form id="form1" runat="server">
                <div id="add-user" class="action-panel">

                
                    <asp:TextBox ID="NameTextBox" runat="server" Placeholder="Name"></asp:TextBox>
                    <asp:TextBox ID="SurnameTextBox" runat="server" Placeholder="Surname"></asp:TextBox>
                    <asp:TextBox ID="DOBTextBox" runat="server" Placeholder="Date of born"></asp:TextBox>
                    <asp:TextBox ID="PhoneTextBox" runat="server" Placeholder="Phone"></asp:TextBox>
                    <asp:TextBox ID="AddressTextBox" runat="server" Placeholder="Address"></asp:TextBox>
                    <asp:TextBox ID="ProfileTextBox" runat="server" Placeholder="Profile"></asp:TextBox>
                    <asp:TextBox ID="EmailTextBox" runat="server" Placeholder="Email"></asp:TextBox>
                    <asp:TextBox ID="PasswordTextBox" runat="server" Placeholder="Password"></asp:TextBox>

                    <asp:Button ID="Button1" class="btn-add-user" runat="server" Text="+ Add User" OnClick="Button1_Click" />
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>

                
                </div>

                <div id="search-user" class="action-panel">
                    <h2 class="section-title">Personal Data</h2>

                    <div class="searcher">
                        <asp:TextBox ID="searcherTextBox" runat="server" Placeholder="Search a user by email..."></asp:TextBox>
                        <asp:Button class="searchBtn" runat="server" ImageUel="img/search.png" OnClick="searchBtn" />
                    </div>

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
                
            </form>
        </div> 
    </main>

    <footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
