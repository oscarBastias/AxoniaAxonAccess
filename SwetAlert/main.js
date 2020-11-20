const btnSwitch = document.querySelector('#switch');

btnSwitch.addEventListener('click', () => {
	document.body.classList.toggle('dark');
	btnSwitch.classList.toggle('active');
});
document.querySelector(".third").addEventListener('click', function(){
  swal("Our First Alert", "With some body text and success icon!", "success");
});