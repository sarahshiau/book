// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function rejectOrder(bookId) {
    // 執行刪除訂單
    fetch(`/RejectOrder`, {
        method: 'POST'
    }).then(response => {
        // 處理返回的結果
        console.log('訂單已拒絕');
        console.log('bookid:'+bookId)
    }).catch(error => {
        // 處理錯誤
        console.error('拒絕訂單時出錯', error);
    });
}

/////////////////////////Navbar收起/////////////////////////
document.addEventListener("DOMContentLoaded", function () {
    var landingWrapper = document.querySelector(".LandingWrapper");
    var banner = document.querySelector(".banner");
    var navbar = document.querySelector(".navbar");

    // 計算觸發效果的滾動位置（例如離開 100px 前觸發）
    var triggerScrollPosition = landingWrapper ? landingWrapper.offsetTop + landingWrapper.offsetHeight - 500 : 100;
    
    window.addEventListener("scroll", function () {
        // 檢查是否超過觸發滾動位置
        var isPastTriggerPosition = window.scrollY > triggerScrollPosition;

        // 根據條件添加或移除 class
        if (isPastTriggerPosition) {
            navbar.classList.add("navbar-collapsed");
        } else {
            navbar.classList.remove("navbar-collapsed");
        }
    });
});


/////////////////////////分類頁面－會員Navbar透明設定/////////////////////////
if (window.location.pathname === '/Classification/ClassifyByUser'){
    document.querySelector('.navbar').classList.remove('bg-black');
}
//分類頁面-管理員Navbar透明設定
if (window.location.pathname === '/Classification/ClassifyByManager'){
    document.querySelector('.navbar').classList.remove('bg-black');
}
/////////////////////////


/////////////////////////根據網頁路徑判斷是否新Banner////////////////////////
$(document).ready(function () {
    // 獲取當前網頁路徑和 title
    var currentPath = window.location.pathname;
    var currentTitle = document.title;

    // 判斷是否要插入 Banner
    if (currentPath === "/Book/BookListPage" || currentPath === "/Book/OrderRecordPage" || currentPath === "/Order/OrderPage" ||currentPath === "/User/UserPage") {
        // 創建 banner 元素
        var banner = `
            <div class="banner">
                <div>
                    <h2 id="bannerTitle">${currentTitle}</h2>
                    <p id="breadcrumbText">Your description goes here.</p>
                </div>
            </div>
        `;

        // 插入 banner 在 header 下方
        $("header").after(banner);

        // 更新 p 元素的內容為 breadcrumb
        updateBreadcrumbText();
    }

    // 更新 p 元素的內容為 breadcrumb
    function updateBreadcrumbText() {
        // 分割 title，獲取各個部分
        var titleSegments = currentTitle.split(' - ').filter(function (segment) {
            return segment !== ''; // 去掉空的部分
        });

        // 創建 breadcrumb 內容
        var breadcrumbContent = '首頁';
        var currentPathSoFar = '/';

        for (var i = 0; i < titleSegments.length; i++) {
            currentPathSoFar += titleSegments[i] + '/';
            breadcrumbContent += ' > <a href="' + currentPathSoFar + '">' + titleSegments[i] + '</a>';
        }

        // 更新 p 元素的內容
        $("#breadcrumbText").html(breadcrumbContent);
    }
});


// remove landing page container
if (window.location.pathname === "/") {
    document.querySelector('#body').classList.remove('container');
}
function submitForm(){
    $('#landingPageForm').submit();
    
}

$('#searchInput').keypress(function (e) {
    // 如果按下的是 Enter 键（键码 13）
    if (e.which === 13) {
        // 手动触发点击事件
        submitForm();
    }
});