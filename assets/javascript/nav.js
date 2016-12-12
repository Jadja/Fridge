var navCount = 0;

function nav_SelectPage(title, navId) {
	title = title.toLowerCase();
	navId = navId.toLowerCase();
	$('#page-' + nav_currentPage).css('display', 'none');
	$('#' + nav_currentNavId).removeClass('nav-element-active');
	$('#page-' + title).css('display', 'block');
	$('#' + navId).addClass('nav-element-active');
	nav_currentPage = title;
	nav_currentNavId = navId;
}

function AddPage(name) {
	$('nav ul').append('<li id="nav-' + navCount + '">' + name + '</li>');
	$('main').append('<div id="page-' + navCount + '">' + name + '</li>');
	navCount++;
}
var nav_currentPage = '';
var nav_currentNavId = '';

$(document).ready(function() {
	AddPage('Home');
	AddPage('test');
	AddPage('test');
	AddPage('test');
	AddPage('test');

	for (var i = 1; i < navCount; i++) {
		$('main #page-' + i).hide();
	}
});