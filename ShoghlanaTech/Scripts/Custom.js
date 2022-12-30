$(function () {
    $("#btnGet").click(function () {
        $.ajax({
            type: "POST",
            url: "/Home/AjaxMethod",
            data: '{name: "' + $("#txtName").val() + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                alert("Hello: " + response.Title);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});