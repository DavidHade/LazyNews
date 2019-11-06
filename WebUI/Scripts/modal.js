var PostBackURL = "http://localhost:63902/Home/Details";
function showmodal () {
    $(".anchorDetail").click(function () {
        //debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: PostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                //debugger;
                $('#ModalContent').html(data);
                $('#Modal').modal(options);
                $('#Modal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    //$("#closebtn").on('click',function(){
    //    $('#myModal').modal('hide');

    $("#closbtn").click(function () {
        $('#Modal').modal('hide');
    });
};