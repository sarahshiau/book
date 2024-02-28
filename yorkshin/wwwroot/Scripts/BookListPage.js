let courseListAddBook = [];
let departmentListAddBook = [];

const departmentCheckboxes = $('#departmentAddBook input[type="checkbox"]');
const courseCheckboxesAddBook = $('#courseAddBook input[type="checkbox"]')
const departmentDropdownAddBook = $('#departmentDropdownAddBook');
const courseDropdownAddBook = $('#courseDropdownAddBook');

function handleCourse() {
    let courseBtnText = '';

    courseCheckboxesAddBook.each(function () {
        if ($(this).prop('checked')) {
            courseListAddBook.push($(this).val());
            courseBtnText += $(this).val() + ', ';
        }
    });
    courseDropdownAddBook.text(courseListAddBook.length > 0 ? courseBtnText.slice(0, -2) : '請選擇');
}

function handleDepartment() {
    departmentListAddBook = [];
    let departmentBtnText = '';

    departmentCheckboxes.each(function () {
        if ($(this).prop('checked')) {
            departmentListAddBook.push($(this).val());
            departmentBtnText += $(this).val() + ', ';
        }
    });
    departmentDropdownAddBook.text(departmentListAddBook.length > 0 ? departmentBtnText.slice(0, -2) : '請選擇');
}

courseCheckboxesAddBook.on('change', handleCourse)
departmentCheckboxes.on('change', handleDepartment);

let imgOutput = document.getElementById('image-result');
$('#input-file').on('change', function (e) {
    let fileReader = new FileReader();
    fileReader.onload = function () {
        imgOutput.src = fileReader.result;
    }
    fileReader.readAsDataURL(e.target.files[0]);
})
const form = $('#form');
// function reload() {
//     form.trigger('reset');
//     if (imgOutput.src !== '#') {
//         imgOutput.src = '';
//     }
// }
function addBook(){
    const departmentString = departmentListAddBook.join(',');
    const courseString = courseListAddBook.join(',');
    console.log('trigger addBook departmentString:', departmentString);
    console.log('trigger addBook courseString:', courseString);
    $('#departmentValueAddBook').val(departmentString)
    $('#courseValueAddBook').val(courseString);
}
if(sessionStorage.getItem("bookListTab") != null && window.location.pathname === '/Book/BookListPage'){
    document.getElementById(sessionStorage.getItem("bookListTab")).click();
}
const bookListTab = document.getElementById('bookList-tab');
bookListTab.addEventListener('click', function () {
    sessionStorage.setItem("bookListTab", "bookList-tab");   
});

const waitingAcceptListTab = document.getElementById('waitingAcceptList-tab');
waitingAcceptListTab.addEventListener('click', function () {
    sessionStorage.setItem("bookListTab", "waitingAcceptList-tab");
});

const acceptedListTab = document.getElementById('acceptedList-tab');
acceptedListTab.addEventListener('click', function () {
    sessionStorage.setItem("bookListTab", "acceptedList-tab");
});

const soldListTab = document.getElementById('soldList-tab');
soldListTab.addEventListener('click', function () {
    sessionStorage.setItem("bookListTab", "soldList-tab");
});

const commentTab = document.getElementById('comment-tab');
commentTab.addEventListener('click', function () {
    sessionStorage.setItem("bookListTab", "comment-tab");
});

