<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomepageLoged.aspx.cs" Inherits="English_Project_2025.HomepageLoged" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Homepage Hotel | English Project 2025 @ Javier Acevedo Y Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/HomepageLoged.css" rel="stylesheet" />
    <link href="css/Homepage.css" rel="stylesheet" />
</head>
<body>
<header>
    <a href="#"> <img src="img/logo.png" alt="Hotel Logo" /> </a>
    <nav>
        <ul>
            <li>
                <asp:Label ID="LabelNameLoged" Text="text" runat="server" />
                <a href="Logout.aspx" id="logout"> <img src="img/logout.png" alt="Logout icon" /> </a>
            </li>
        </ul>
    </nav>
</header>

<main>

    <!-- SOBRE EL HOTEL -->
    <section class="about">
        <div class="about-img"></div>
        <div class="about-text">
            <h2>Welcome to Grand Arrow</h2>
            <p>
                A hotel where elegance and comfort come together to offer you an unforgettable experience.
                Enjoy our premium facilities, personalized service, and a unique atmosphere.
            </p>
            <a href="Client.aspx" class="btn-primary">My Bookings</a>
        </div>
    </section>

    <!-- SERVICIOS / ESPACIOS -->
<section class="features">
    <h2 class="section-title">Our Spaces & Amenities</h2>

    <div class="features-grid">

        <div class="feature-card">
            <div class="feature-bar"></div>
            <h3>Infinity Pool</h3>
            <p>Relax with spectacular sunset views.</p>
        </div>

        <div class="feature-card">
            <div class="feature-bar"></div>
            <h3>Gourmet Restaurant</h3>
            <p>Unique flavors crafted by renowned chefs.</p>
        </div>

        <div class="feature-card">
            <div class="feature-bar"></div>
            <h3>Spa & Wellness</h3>
            <p>A space designed for wellness and relaxation.</p>
        </div>

        <div class="feature-card">
            <div class="feature-bar"></div>
            <h3>24/7 Gym</h3>
            <p>Modern, high-end equipment</p>
        </div>

    </div>
</section>


    <!-- HABITACIONES -->
    <section class="rooms">
        <h2 class="section-title">Our Rooms</h2>
        <div class="room-description">
            <div class="room-card">
                <div class="room-img room1"></div>
                <h3>Deluxe Suite</h3>
               <span class="eliminar2"> <p>Spacious and elegant.<span class="eliminar"> Overlooking the Madrid forest.</span></p></span>
            </div>

            <div class="room-card">
                <div class="room-img room2"></div>
                <h3>Presidential Suite</h3>
               <span class="eliminar2"> <p>Maximum comfort and exclusivity.</p></span>
            </div>

            <div class="room-card">
                <div class="room-img room3"></div>
                <h3>Double Room</h3>
                <span class="eliminar2"><p>Perfect for couples.</p></span>
            </div>
        </div>
    </section>

    <!-- EXPERIENCIAS -->
    <section class="experiences">
        <h2 class="section-title">Unforgettable Experiences</h2>

        <div class="exp-card exp1">Gourmet Cooking Classes</div>
        <div class="exp-card exp2">Private Tours</div>
        <div class="exp-card exp3">Luxury Massages</div>
        <div class="exp-card exp4">Exclusive Wine Tastings</div>
    </section>

   <!-- RESEÑAS -->
    <section class="reviews">
    <h2 class="section-title">Hear from Our Guests</h2>

    <!-- Valoración media centrada -->
    <div class="reviews-average">
        <div class="stars-average">⭐⭐⭐⭐⭐</div>
        <p>5/5 – based on 50,000 reviews</p>
    </div>

    <div class="reviews-grid">

        <div class="review-card">
            <div class="stars">⭐⭐⭐⭐⭐</div>
            <p>“Incredible experience, we can’t wait to come back.”</p>
        </div>

        <div class="review-card">
            <div class="stars">⭐⭐⭐⭐⭐</div>
            <p>“Super attentive staff and perfect facilities.”</p>
        </div>

        <div class="review-card">
            <div class="stars">⭐⭐⭐⭐⭐</div>
            <p>“Hi, I’m Ferran. The wine tasting was amazing!”</p>
        </div>

        <div class="review-card">
            <div class="stars">⭐⭐⭐⭐⭐</div>
            <p>“Excellent attention, and the spa is simply marvelous.”</p>
        </div>

    </div>
</section>



    <!-- UBICACIÓN -->
   <section class="location">
    <h2 class="section-title">Our Location</h2>

    <div class="map-container">
        <img 
            src="img/imagenMapa.png" 
            alt="Mapa con ubicación del hotel">
    </div>
    </section>



</main>



<footer>&copy; All rights reserved | 2025</footer>
</body>
</html>
