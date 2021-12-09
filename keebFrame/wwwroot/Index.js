function doStuff(callback) {
    // do all app scripts here...
    callback();
}



$(document).ready(function () {

    doStuff(function () {
        document.body.className = 'visible';
    });

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
    });

    $("#addPostBtn").click(function () {
        $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "Home/AddPost", // Controller/View   
                data: { //Passing data  
                    Title: $("#inputTitle").val(), //Reading text box values using Jquery   
                    Question: $("#inputQuestion").val(),
                    Answer: $("#inputAnswer").val()
                }

            });

    });  

});
