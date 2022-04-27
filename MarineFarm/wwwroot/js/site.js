// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//para generar una alerta pasandole como cuerpo el html
const AlertaHtml = (title, contHTMLlineal, btnSend = '<i class="fa fa-thumbs-up"></i> ', btnCancel = '<i class="fa fa-thumbs-down"></i>') => {
  return  Swal.fire({
        title: title,
        icon: null,
        width: '80%',
        background: '#fff',
        backdrop: false,
        position: 'top-end',
        html: contHTMLlineal,
        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        confirmButtonText: btnSend,
        confirmButtonAriaLabel: 'Enviar',
        cancelButtonText: btnCancel,
        cancelButtonAriaLabel: 'Calcular De Nuevo'

    })
}

//alerta de exito
const AlertSuccess = messege => {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: messege,
        showConfirmButton: false,
        backdrop: false,
        timer: 1500
    })
}

//alerta de error
const AlertError = (title, body) => {
    Swal.fire({
        icon: 'error',
        title: title,
        text: body,
        backdrop: false,
    })
}


// Tranforma un valor fecha en una vista mas agradable
const TraformarFechaDDMMYY = fecha => {
    let date = new Date(fecha);
    var options = { year: 'numeric', month: 'long', day: 'numeric' };
    return date.toLocaleDateString("es-ES", options)
    
}

// retorna un valor con solo dos decimales
const fixedTwoDecimal = dotNumber => {

    return (Math.round(dotNumber * 100) / 100).toFixed(2)
}