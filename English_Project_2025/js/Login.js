document.getElementById("btn-log-in").addEventListener("submit", async (e) => {
    e.preventDefault();

    /* 

    e es el evento del formulario.
    e.target es el formulario mismo.
    new FormData(...) recoge todos los campos: <input>, <select>, <textarea>, etc.

    */
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData.entries());

    const res = await fetch("/api/guardar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    const respuesta = await res.json();
    alert(respuesta.mensaje);
});