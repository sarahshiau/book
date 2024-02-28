$(".register-btn").click(function () {
    var accountValue = document.getElementsByName("Account")[0].value;
    var pwdValue = document.getElementsByName("Pwd")[0].value;
    var uNameValue = document.getElementsByName("UName")[0].value;
    var emailValue = document.getElementsByName("Email")[0].value;
    var phoneValue = document.getElementsByName("Phone")[0].value;
    var formData = {
        Account: accountValue,
        Pwd: pwdValue,
        UName: uNameValue,
        Email: emailValue,
        Phone: phoneValue
    }
    $.ajax({
        type: "POST",
        url: "/User/Register",
        data: formData,
        success: function (response) {
            console.log("response:",response);
            // 處理成功的回應
            if(response.message === "success"){
                alert("註冊成功");
                RedirectToLogin();
            }else{
                alert("註冊失敗");
            }
        },
        error: function (error) {
            // 處理錯誤
            console.log(error);
        }
    });
});
$(".login-btn").click(function () {
    var accountValue = document.getElementsByName("Account")[0].value;
    var pwdValue = document.getElementsByName("Pwd")[0].value;
    var formData = {
        Account: accountValue,
        Pwd: pwdValue,
    }
    $.ajax({
        type: "POST",
        url: "/User/Login",
        data: formData,
        success: function (response) {
            console.log("response:",response);
            // 處理成功的回應
            switch (response.message) {
                case "success":
                    RedirectToLandingPage();
                    break;
                case "fail":
                    showToast();
                    break;
                default:
                    showToast();
                    break;
            }
        },
        error: function (error) {
            // 處理錯誤
            console.log(error);
        }
    });
});
$(".userPage-btn").click(function () {
    var accountValue = document.getElementsByName("Account")[0].value;
    var pwdValue = document.getElementsByName("Pwd")[0].value;
    var uNameValue = document.getElementsByName("UName")[0].value;
    var emailValue = document.getElementsByName("Email")[0].value;
    var phoneValue = document.getElementsByName("Phone")[0].value;
    var formData = {
        Account: accountValue,
        Pwd: pwdValue,
        UName: uNameValue,
        Email: emailValue,
        Phone: phoneValue
    }
    $.ajax({
        type: "POST",
        url: "/User/EditUser",
        data: formData,
        success: function (response) {
            console.log("response:",response);
            // 處理成功的回應
            if(response.message === "success"){
                alert("更改成功");
            }else{
                alert("更改失敗");
            }
        },
        error: function (error) {
            // 處理錯誤
            console.log(error);
        }
    });
});
function RedirectToLogin(){
    $.get('/User/LoginPage', function() {
        // 在成功後進行重定向到 LoginPage
        window.location.href = '/User/LoginPage';
    });
}
function RedirectToLandingPage(){
    $.get('/', function() {
        // 在成功後進行重定向到 LoginPage
        window.location.href = '/';
    });
}

function showToast() {
    setTimeout(function () {
        var messageBox = document.getElementById('messageBox');
        messageBox.classList.add('d-flex');

        setTimeout(function () {
            messageBox.classList.remove('d-flex');
        }, 2000); // 這裡的2000表示訊息框顯示的時間，單位為毫秒
    }, 500); // 這裡的500表示模擬 Ajax 請求的延遲時間
}