<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="English_Project_2025.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Homepage Hotel | English Project 2025 @ Javier Acevedo Y Ferran Sansaloni</title>
    <link href="css/Structure_Page.css" rel="stylesheet" />
    <link href="css/Homepage.css" rel="stylesheet" />
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

    <!-- SOBRE EL HOTEL -->
    <section class="about">
        <div class="about-img"></div>
        <div class="about-text">
            <h2>Bienvenido a Grand Arrow</h2>
            <p>
                Un hotel donde la elegancia y el confort se unen para ofrecerte una experiencia inolvidable.
                Disfruta de nuestras instalaciones premium, atención personalizada y un ambiente único.
            </p>
            <a href="#" class="btn-primary">Mis reservas</a>
        </div>
    </section>

    <!-- SERVICIOS -->
    <section class="features">
        <h2 class="section-title">Nuestros Espacios</h2>

        <div class="feature">
            <h3> Piscina Infinity</h3>
            <p>Relájate con vistas espectaculares al atardecer.</p>
        </div>

        <div class="feature">
            <h3> Restaurante Gourmet</h3>
            <p>Sabores únicos preparados por chefs de prestigio.</p>
        </div>

        <div class="feature">
            <h3> Spa & Wellness</h3>
            <p>Un espacio pensado para el bienestar y la desconexión.</p>
        </div>

        <div class="feature">
            <h3> Gimnasio 24h</h3>
            <p>Equipamiento de última generación.</p>
        </div>
    </section>

    <!-- HABITACIONES -->
    <section class="rooms">
        <h2 class="section-title">Nuestras Habitaciones</h2>
        <div class="room-description">
            <div class="room-card">
                <div class="room-img room1"></div>
                <h3>Suite Deluxe</h3>
                <p>Amplia, elegante y con vistas a la selva madrileña.</p>
            </div>

            <div class="room-card">
                <div class="room-img room2"></div>
                <h3>Suite Presidencial</h3>
                <p>Máximo confort y exclusividad.</p>
            </div>

            <div class="room-card">
                <div class="room-img room3"></div>
                <h3>Habitación Doble</h3>
                <p>Ideal para viajes en pareja.</p>
            </div>
        </div>
    </section>

    <!-- EXPERIENCIAS -->
    <section class="experiences">
        <h2 class="section-title">Experiencias Únicas</h2>

        <div class="exp-card exp1">Clases de cocina</div>
        <div class="exp-card exp2">Visitas guiadas</div>
        <div class="exp-card exp3">Masajes premium</div>
        <div class="exp-card exp4">Catas de vino</div>
    </section>

    <!-- RESEÑAS -->
    <section class="reviews">
        <h2 class="section-title">Lo que dicen nuestros huéspedes</h2>

        <div class="review">
            ⭐⭐⭐⭐⭐  
            <p>“Una experiencia increíble, volveremos sin duda.”</p>
        </div>

        <div class="review">
            ⭐⭐⭐⭐⭐  
            <p>“El personal súper atento y las instalaciones perfectas.”</p>
        </div>
    </section>

    <!-- UBICACIÓN -->
   <section class="location">
    <h2 class="section-title">Ubicación</h2>

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
