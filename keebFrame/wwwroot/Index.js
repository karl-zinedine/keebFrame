

$(document).ready(function () {
    $.ajax({
        url: '/Home/GetPosts',
        type: 'post',
        dataType: 'json',
        //contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#example').DataTable({
                //processing: true,
                //serverSide: true,
                //ajax: {
                //    url: '/Home/GetPosts',
                //    type: 'post',
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json',
                //    //dataSrc: ''
                //    /*data: { 'getValues': '1' }*/
                //},
                //columnDefs: [{
                //    "defaultContent": "-",
                //    "targets": "_all"
                //}],
                data: data,
                columns: [
                    { data: "PId" },
                    { data: "PTitle" },
                    { data: "PQuestion" },
                    { data: "PAnswer" },
                    { data: "PImageId" }                 
                ]
            });
        }
    })

});
