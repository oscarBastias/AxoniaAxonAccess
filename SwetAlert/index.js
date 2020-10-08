var mostrarConfirmacion = () => {
    swal("Esta es una prueba de confirmacion",{
        dangerMode : true,
        buttons : ["Cancelar","Aceptar"]
    }).then((confirmacion)=>{
        if(confirmacion)
            swal("Exito","Has hecho click sobre el boton aceptar","success");
        else
            swal("Error","Has hecho click sobre el boton cancelar","error");
    });
}