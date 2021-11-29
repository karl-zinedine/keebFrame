

$(document).ready(function () {
    //$.ajax({
    //    url: 'Home/GetPosts',
    //    type: 'post',
    //    dataType: 'json',
    //    success: function (data) {
    $('#example').DataTable({
        ajax: {
            url: '/Home/GetPosts',
            type: 'get',
            dataType: 'json',
        },
        //columnDefs: [{
        //    "defaultContent": "-",
        //    "targets": "_all"
        //}],
        columns: [
            { data: "PId" },
            { data: "PTitle" },
            { data: "PQuestion" },
            { data: "PAnswer" },
            { data: "PImageId" }
        ]


    });
    //    }
    //})

});
