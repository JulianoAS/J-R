/*$(document).ready(function () {
  $(window).scroll(function () {
    // check if scroll event happened
    if ($(document).scrollTop() > 50) {
      // check if user scrolled more than 50 from top of the browser window
      $('.nav-main').css('background-color', '#f8f8f8'); // if yes, then change the color of class "navbar-fixed-top" to white (#f8f8f8)
      $('.nav-main a').css('color', '#000000');
      $('.nav-main').css('opacity', '1');
    } else {
      $('.nav-main').css('background-color', 'white'); // if not, change it back to transparent
      $('.nav-main a').css('color', 'black');
      $('.nav-main').css('opacity', '0.7');
    }
  });
});*/

$(document).on('click', 'a[href^="#"]', function (e) {
  e.preventDefault();
  $('html, body')
    .stop()
    .animate(
      {
        scrollTop: $($(this).attr('href')).offset().top -75,
      },
      700,
      'linear'
    );
});

function callModal() {
 
    $('#mContato').modal('show');
}

