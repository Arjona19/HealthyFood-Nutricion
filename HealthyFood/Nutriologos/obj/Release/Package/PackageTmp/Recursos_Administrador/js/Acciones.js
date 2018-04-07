function getDatos(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            console.log(response);
        }
    });
}
function Toast() {
    document.getElementById("Noti_Eliminar").classList.add("peek");
    
}