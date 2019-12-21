$(document).ready(function () {
    $(".ad-post").click(function (e) {
        e.preventDefault();

        let FormUrl = $(this).attr("href");
        $.ajax({
            url: FormUrl,
            type: "get",
            dataType: "html",
        
            success: function (response) {
                $("#companyModal").html(response)
                $('#companyModal').modal('show');
            }
        })
    })

    $(document).on("click", ".create-company", function (e) {
        e.preventDefault();
        var files = $("input[name=companyphoto]")[0].files;
        var formdata = new FormData();
        formdata.append("Name" ,$("input[name=companyname]").val())
        formdata.append("Email" ,$("input[name=companyemail]").val())
        formdata.append("Phone" ,$("input[name=companyphone]").val())
        formdata.append("Location" ,$("input[name=companyaddress]").val())
        formdata.append("Website" ,$("input[name=companywebsite]").val())
        formdata.append("Info", $("textarea[name=companyinfo]").val())
        formdata.append("Upload", files[0], files[0].name)

        //var form = {
        //    Name: $("input[name=companyname]").val(),
        //    Email: $("input[name=companyemail]").val(),
        //    Phone: $("input[name=companyphone]").val(),
        //    Location: $("input[name=companyaddress]").val(),
        //    Website: $("input[name=companywebsite]").val(),
        //    Upload: $("input[name=companyphoto]")[0].files[0],
        //    Info: $("textarea[name=companyinfo]").val(),
        //}
        $.ajax({
            url: "/SubmitJob/CreateCompany",
            type: "post",
            dataType: "json",
            data: formdata,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (response) {

            },
            error: function (error) {

            },
            complete: function () {
            }
        })
    })

});
