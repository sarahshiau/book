// Assuming you are using jQuery (make sure to include jQuery in your project)
$(document).ready(function () {
    $('#AddOrder-form').submit(function (e) {
        e.preventDefault(); // Prevent the default form submission

        $.ajax({
            url: $(this).attr('action'),
            method: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.message === 'success') {
                    // Handle success case, if needed
                    console.log('Order placed successfully');
                    alert("下訂成功");
                    RedirectToOrderRecordPage();
                } else if (response.message === 'fail') {
                    // Handle failure case
                    alert("下訂失敗");
                    console.log('Order placement failed');
                }
            },
            error: function () {
                console.log('Error in AJAX request');
            }
        });
    });
});

function RedirectToOrderRecordPage(){
    $.get('/Book/OrderRecordPage', function() {
        // 在成功後進行重定向到 LoginPage
        window.location.href = '/Book/OrderRecordPage';
    });
}