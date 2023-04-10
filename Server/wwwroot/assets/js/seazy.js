// product Gallery and Zoom

$('.gallery-parent').each(function () {
  // We finding any "gallery-parent" and find child with class "gallery-top" and "gallery-thumbs" for multiple using plugin
  let thumbs = $(this).children('.gallery-thumbs'),
    top = $(this).children('.gallery-top');

  // activation carousel plugin
  let galleryThumbs = new Swiper(thumbs, {
    direction: 'vertical',
    autoScrollOffset: 2,
    multipleActiveThumbs :true,
    slideThumbActiveClass: 	'swiper-slide-thumb-active',

    breakpoints: {
      0: {
        slidesPerView: 4,
      },
      992: {
        slidesPerView: 4,
      },
    },
  });
  let galleryTop = new Swiper(top, {
    watchOverflow: true,
  watchSlidesVisibility: true,
  watchSlidesProgress: true,

    
    navigation: {
      nextEl: '.swiper-button-prev',
      prevEl: '.swiper-button-next',
    },
    effect: 'fade',
    fadeEffect: {
    crossFade: true
  },
    thumbs: {
      swiper: galleryThumbs,
    },
  });

  // change carousel item height
  // gallery-top
  let productCarouselTopWidth = top.outerWidth();
  top.css('height', productCarouselTopWidth);

  // gallery-thumbs
  let productCarouselThumbsItemWith = thumbs.find('.swiper-slide').outerWidth();
  thumbs.css('height', productCarouselThumbsItemWith);
  
});


// activation zoom plugin
let $easyzoom = $('.easyzoom').easyZoom();
