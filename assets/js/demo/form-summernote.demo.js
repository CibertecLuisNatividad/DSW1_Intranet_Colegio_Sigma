/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Twitter Bootstrap 4
Version: 4.4.0
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin/admin/
*/

var handleSummernote = function() {
	$('.summernote').summernote({
		placeholder: 'Ingresa tu mensaje',
		height: $(window).height() - $('.summernote').offset().top - 450
	});
};

var FormSummernote = function () {
	"use strict";
	return {
		//main function
		init: function () {
			handleSummernote();
		}
	};
}();

$(document).ready(function() {
	FormSummernote.init();
});