//Nuevo Usuario
function readURL(input) {
	if (input.files && input.files[0]) {
		var reader = new FileReader();

		reader.onload = function(e) {
			$('#imgperfil').attr('src', e.target.result);
		}

		reader.readAsDataURL(input.files[0]); // convert to base64 string
	}
}
$("#file-input").change(function() {
	readURL(this);
	var progress = document.getElementById("progress");
	progress.style.display = "block";
	document.getElementById("imgperfil").style.display="block";
});


// Editar Usuario
function readURLEditar(input) {
	if (input.files && input.files[0]) {
		var reader = new FileReader();

		reader.onload = function(e) {
			$('#editarimgperfil').attr('src', e.target.result);
		}

		reader.readAsDataURL(input.files[0]); // convert to base64 string
	}
}
$("#file-input_editar").change(function() {
	readURLEditar(this);
	var progress = document.getElementById("editarprogress");
	progress.style.display = "block";
	document.getElementById("editarimgperfil").style.display="block";
});


