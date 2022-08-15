$(document).ready(function () {


    $(window).scroll(
        function () {

            var scrollval = $(this).scrollTop();

           

            $("#logo").css("transform", 'translate(0px,-' + scrollval / 20 + '%)');
            $("#btn").css("transform", 'translate(-50%,' + scrollval / 3 + '%)');


        }
    );



    //$('html, body').animate({
    //    scrollTop: $('#food-list').offset().top
    //}, 'slow');



});