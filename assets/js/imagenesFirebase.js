window.onload = inicializar;
var fichero;
var storageRef;
var imagenesFB;
var progressBar;
var url_imagen;

//Para Actualizar
var ficheroEditar;
var progressEditar;
function inicializar(){
	//Get Id's para registrar foto
    fichero = document.getElementById("file-input");
    progressBar = document.getElementById("progress");
   //Get Id's para actualizar foto
    ficheroEditar = document.getElementById("file-input_editar");
    progressEditar = document.getElementById("editarprogress");
    storageRef = firebase.storage().ref();
    fichero.addEventListener('change',subirImagenAFirebase,false);
    ficheroEditar.addEventListener('change',actualizarImgaFirebase,false);
    //Referencia a la base de Datos
    imagenesFB= firebase.database().ref().child('imagenes');

    //Para Actualizar Foto
   
   
}
//Para REgistrar Foto
function subirImagenAFirebase(){
   var imagenASubir = fichero.files[0];
   var uploadTask = storageRef.child('usuarios/'+ imagenASubir.name).put(imagenASubir);
 
   uploadTask.on('state_changed',

        function progress(snapshot) {
            var porcentaje = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
            progressBar.value = porcentaje;
        },
        function(error) {

            alert("Hubo un error"+error);

        },
        function() {

               // storageRef.child('usuarios/' + imagenASubir.name).getDownloadURL().then(function(url) {
                storageRef.child('usuarios/' + imagenASubir.name).getDownloadURL().then(function(url){
                    // Or inserted into an <img> element:
                   // url_imagen = document.getElementById('urlImagen');
                    $("#urlImagen").val(url);

                    console.log(url);
                crearNodoFB(imagenASubir.name,url);
                }).catch(function(error) {
                    // Handle any errors
                });

        });

}


//Para Actualizar
function actualizarImgaFirebase(){
	   var imagenASubir = ficheroEditar.files[0];
	   var uploadTask = storageRef.child('usuarios/'+ imagenASubir.name).put(imagenASubir);
	 
	   uploadTask.on('state_changed',

	        function progress(snapshot) {
	            var porcentaje = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
	            progressEditar.value = porcentaje;
	        },
	        function(error) {

	            alert("Hubo un error"+error);

	        },
	        function() {

	               // storageRef.child('usuarios/' + imagenASubir.name).getDownloadURL().then(function(url) {
	                storageRef.child('usuarios/' + imagenASubir.name).getDownloadURL().then(function(url){
	                    // Or inserted into an <img> element:
	                   // url_imagen = document.getElementById('urlImagen');
	                    $("#act_urlImagen").val(url);

	                    console.log(url);
	               
	                }).catch(function(error) {
	                    // Handle any errors
	                });

	        });

	}


function crearNodoFB(nombreImagen,urlimagen){
    imagenesFB.push({nombre: nombreImagen, url:urlimagen});
}