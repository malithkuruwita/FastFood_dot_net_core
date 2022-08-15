$(document).ready(function () {


    $(window).scroll(
        function () {



            var scrollvalp = $(this).scrollTop();
            
            if (scrollvalp > $('#blog-posts').offset().top - $(window).height()) {

                var offset1 = Math.min(0, scrollvalp - $('#blog-posts').offset().top + $(window).height() - 350);

                $('#post1').css({
                    'transform': 'translate(' + offset1 + 'px,' + Math.abs(offset1 * 0.5) + 'px)'

                });

                $('#post3').css({
                    'transform': 'translate(' + Math.abs(offset1) + 'px,' + Math.abs(offset1 * 0.5) + 'px)'

                });

            }

            var scrollvalp1 = $(this).scrollTop();

            if (scrollvalp1 > $('#blog-posts1').offset().top - $(window).height()) {
                var offset2 = Math.min(0, scrollvalp1 - $('#blog-posts1').offset().top + $(window).height() - 350);

                $('#post4').css({
                    'transform': 'translate(' + offset2 + 'px,' + Math.abs(offset2 * 0.5) + 'px)'

                });

                $('#post5').css({
                    'transform': 'translate(' + Math.abs(offset2) + 'px,' + Math.abs(offset2 * 0.5) + 'px)'

                });

            }
        }
    );

});