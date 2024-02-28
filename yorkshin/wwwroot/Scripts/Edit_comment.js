/*var EditComment_Btn = $('#EditComment-Btn');
var star_rating_edit = $('.star-rating .fa');
/!*reset all comment setting when buyer add comment*!/
EditComment_Btn.on('click',function (){
    star_rating_edit.siblings('input.rating-value').val(0);
    $('#ratingNum').text(0);
    star_rating_edit.each(function (){
        return $(this).removeClass('fa-star').addClass('fa-star-o');
    })
    $('#imageResult').attr('src', "#");
    $('#Comment_textarea').val("");

});*/
/*reset all comment setting when buyer add comment*/
var star_rating_edit = $('.star-rating .fa');
var SetRatingStar = function() {
    return star_rating_edit.each(function() {
        if (parseInt(star_rating_edit.siblings('input.rating-value').val()) >= parseInt($(this).data('rating'))) {
            return $(this).removeClass('fa-star-o').addClass('fa-star');
        } else {
            return $(this).removeClass('fa-star').addClass('fa-star-o');
        }
    });
};
star_rating_edit.on('click', function() {
    $(this).siblings('input.rating-value').val($(this).data('rating'));
    // 取得rating分數
    var ratingValue = $(this).data('rating');
    $('#ratingNum').text(ratingValue);
    console.log('評分數值: ' + ratingValue+"type:"+typeof(ratingValue));
    // 取得rating分數
    return SetRatingStar($(this).parent());
});

// image
async function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = await function (e) {
            $('#imageResult').attr('src', e.target.result);

        };
        reader.readAsDataURL(input.files[0]);
    }
}

$(function () {
    $('#upload').on('change', function () {
        readURL(input);
    });
});

/*  ==========================================
  SHOW UPLOADED IMAGE NAME
* ========================================== */
var input = document.getElementById( 'upload' );
// var infoArea = document.getElementById( 'upload-label' );

// input.addEventListener( 'change', showFileName );
// function showFileName( event ) {
//   var input = event.srcElement;
//   var fileName = input.files[0].name;
//   infoArea.textContent = 'File name: ' + fileName;
// }

