//menu

  $(window).scroll(function() {
    var a = $(window).scrollTop();
    if (a > 100) {
        $('.scroll-menu').slideDown();
  
    } else {
        $('.scroll-menu').slideUp();
    }
    console.log(a);
  });


  
//owl-slider
$(".owl-ourSolutions").owlCarousel({
  loop: true,
  margin: 10,
  nav: false,
  dots: false,
  autoplay: true,
  autoplayTimeout: 5000,
  autoplayHoverPause: false,
  // center:true,
  stagePadding: 20,
  responsive: {
    0: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 3,
    },
  },
});
var selector = $(".owl-carousel");

$(".my-next-button").click(function () {
  selector.trigger("next.owl.carousel");
});

$(".my-prev-button").click(function () {
  selector.trigger("prev.owl.carousel");
});

var $owl = $(".dd");

$owl.children().each(function (index) {
  $(this).attr("data-position", index); // NB: .attr() instead of .data()
});

$owl.owlCarousel({
  center: true,
  loop: true,
  dots: true,
  autoplay: true,
  autoplayTimeout: 5000,
  autoplayHoverPause: false,
  responsive: {
    0: {
      items: 1,
    },
    600: {
      items: 3,
    },
    1000: {
      items: 3,
    },
  },
});

$(document).on("click", ".owl-item>div", function () {
  // see https://owlcarousel2.github.io/OwlCarousel2/docs/api-events.html#to-owl-carousel
  var $speed = 300; // in ms
  $owl.trigger("to.owl.carousel", [$(this).data("position"), $speed]);
});

$(".owl-areas").owlCarousel({
  loop: true,
  margin: 10,
  nav: false,
  dots: false,
  // center:true,
  stagePadding: 20,
  responsive: {
    0: {
      items: 1,
    },
    600: {
      items: 3,
    },
    1000: {
      items: 5,
    },
  },
});
var selector = $(".owl-carousel");

$(".my-next-button").click(function () {
  selector.trigger("next.owl.carousel");
});

$(".my-prev-button").click(function () {
  selector.trigger("prev.owl.carousel");
});


//active class
    var selector = ".btn-headquarters";
    $(selector).on("click", function () {
      $(selector).removeClass("actived");
      $(this).addClass("actived");
    });

     //Up Down arrows for quantity field
     var qtyMin, qtyMax, qtyField, qtyVal;
     $(".icon-minus-squared").on("click", function () {
       qtyField = $(this).next("input[type=number]");
       qtyMin = parseInt($(qtyField).attr("min"));
       qtyVal = parseInt($(qtyField).val());
       if (qtyVal > qtyMin) {
         qtyVal--;
         $(qtyField).val(qtyVal);
         $(this).siblings(".icon-plus-squared").removeClass("off");
         if (qtyVal === qtyMin) {
           $(this).addClass("off");
         }
       }
     });
     $(".icon-plus-squared").on("click", function () {
       qtyField = $(this).prev("input[type=number]");
       qtyMax = parseInt($(qtyField).attr("max"));
       qtyVal = parseInt($(qtyField).val());
       if (qtyVal < qtyMax) {
         qtyVal++;
         $(qtyField).val(qtyVal);
         $(this).siblings(".icon-minus-squared").removeClass("off");
         if (qtyVal === qtyMax) {
           $(this).addClass("off");
         }
       }
     });

     //Validate numeric range of number fields (for quantity input
     $("input[type=number]").on("blur", function () {
       var $this = $(this);
       if ($this.attr("min").length > 0 && $this.attr("max").length > 0) {
         (vQty = parseInt($this.val())),
           (vMin = $this.attr("min")),
           (vMax = $this.attr("max"));
         if (!$.isNumeric(vQty)) {
           $this.val(vMin);
           $(".icon-plus-squared").removeClass("off");
           $(".icon-minus-squared").addClass("off");
         } else if (vQty < vMin) {
           $this.val(vMin);
           $(".icon-plus-squared").removeClass("off");
           $(".icon-minus-squared").addClass("off");
         } else if (vQty > vMax) {
           $this.val(vMax);
           $(".icon-minus-squared").removeClass("off");
           $(".icon-plus-squared").addClass("off");
         } else {
           return;
         }
       }
     });


  
//DOM elements
const DOMstrings = {
  stepsBtnClass: "multisteps-form__progress-btn",
  stepsBtns: document.querySelectorAll(`.multisteps-form__progress-btn`),
  stepsBar: document.querySelector(".multisteps-form__progress"),
  stepsForm: document.querySelector(".multisteps-form__form"),
  stepsFormTextareas: document.querySelectorAll(
    ".multisteps-form__textarea"
  ),
  stepFormPanelClass: "multisteps-form__panel",
  stepFormPanels: document.querySelectorAll(".multisteps-form__panel"),
  stepPrevBtnClass: "js-btn-prev",
  stepNextBtnClass: "js-btn-next",
};
