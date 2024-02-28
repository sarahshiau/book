if(sessionStorage.getItem("orderRecordPageTab") != null && window.location.pathname === '/Book/OrderRecordPage'){
    document.getElementById(sessionStorage.getItem("orderRecordPageTab")).click();
}

const orderedListTab = document.getElementById('orderedList-tab');
orderedListTab.addEventListener('click', function () {
    sessionStorage.setItem("orderRecordPageTab", "orderedList-tab");
});

const finishedListTab = document.getElementById('finishedList-tab');
finishedListTab.addEventListener('click', function () {
    sessionStorage.setItem("orderRecordPageTab", "finishedList-tab");
});

const CommentForBuyerTab = document.getElementById('CommentForBuyer-tab');
CommentForBuyerTab.addEventListener('click', function () {
    sessionStorage.setItem("orderRecordPageTab", "CommentForBuyer-tab");
});