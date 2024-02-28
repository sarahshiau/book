const originalCourseList = $('#selectedCourse').val().split(',')
const originalDepList = $('#selectedDep').val().split(',')
let courseList = [];
let departmentList = [];
$(document).ready(function () {
    // $('#description-select').on('change', function () {
    //     console.log(this.value);
    // })
    const departmentCheckboxes = $('#department input[type="checkbox"]');
    const courseCheckboxes = $('#course input[type="checkbox"]')
    const departmentDropdown = $('#departmentDropdown');
    const courseDropdown = $('#courseDropdown');

    function handleCourse() {
        courseList = [];
        let courseBtnText = '';

        courseCheckboxes.each(function () {
            if ($(this).prop('checked')) {
                courseList.push($(this).val());
                courseBtnText += $(this).val() + ', ';
            }
        });
        courseDropdown.text(courseList.length > 0 ? courseBtnText.slice(0, -2) : '請選擇');
    }

    function handleDepartment() {
        departmentList = [];
        let departmentBtnText = '';

        departmentCheckboxes.each(function () {
            if ($(this).prop('checked')) {
                departmentList.push($(this).val());
                departmentBtnText += $(this).val() + ', ';
            }
        });
        departmentDropdown.text(departmentList.length > 0 ? departmentBtnText.slice(0, -2) : '請選擇');
    }

    courseCheckboxes.on('change', handleCourse)
    departmentCheckboxes.on('change', handleDepartment);

})

function updateBook() {
    const departmentString = departmentList.join(',');
    const courseString = courseList.join(',');
    $('#departmentValue').val(departmentString);
    $('#courseValue').val(courseString);
    console.log(departmentString);
}

function selected() {
    console.log("aaa")
    const selected = $('#selectSelected').val();
    console.log(selected)
    switch (selected) {
        case "全新":
            $('#selectNew').hide();
            break;
        case "二手書":
            $('#selectSecond').hide();
            break;
        case "有筆記":
            $('#selectNote').hide();
            break;
    }
}
