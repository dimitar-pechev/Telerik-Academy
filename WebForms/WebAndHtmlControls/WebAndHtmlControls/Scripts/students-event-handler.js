$('#BtnSubmitClient').on('click', () => {
    let list = [];
    let courses = $('#MainContent_CoursesList').children();

    for (let i = 0; i < courses.length; i++) {
        if (courses[i]['selected']) {
            list.push('<p>' + courses[i]['label'] + '</p>');
        }
    }

    if (!$('#MainContent_FirstName').val() || !$('#MainContent_LastName').val() || !$('#MainContent_FacultyNumber').val()) {
        $('#modal-body').html('Please fill out all the fields!');
        $('#MainContent_BtnConfirmCourses').hide();
        return;
    } else {
        $('#MainContent_BtnConfirmCourses').show();
    }

    if (!list.length) {
        $('#modal-body').html('You\'ve selected no courses!');
        $('#MainContent_BtnConfirmCourses').hide();
        return;
    } else {
        $('#MainContent_BtnConfirmCourses').show();
    }

    $('#modal-body').html(list.join(''));
});