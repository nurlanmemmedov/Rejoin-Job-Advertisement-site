$(document).ready(function () {

    

    $(".post-job").click(function (e) {
        $.ajax({
            url: "/SubmitJob/Index",
            type: "get",
            dataType: "html",

            success: function (response) {
                $("#companyModal").html(response)
                $('#companyModal').modal('show');
            }
        })
    
    })

    $(".btn-apply").click(function (e) {
        e.preventDefault();

        let FormUrl = $(this).attr("href");
        $.ajax({
            url: FormUrl,
            type: "get",
            dataType: "html",

            success: function (response) {
                $("#applyModal").html(response)
                $('#applyModal').modal('show');
            }
        })
    })

 


    $(document).on("click", ".create-company", function (e) {
        e.preventDefault();
        var files = $("input[name=companyphoto]")[0].files;
        var formdata = new FormData();
        formdata.append("Name", $("input[name=companyname]").val());
        formdata.append("Email", $("input[name=companyemail]").val());
        formdata.append("Phone", $("input[name=companyphone]").val());
        formdata.append("Location", $("input[name=companyaddress]").val());
        formdata.append("Website", $("input[name=companywebsite]").val());
        formdata.append("Info", $("textarea[name=companyinfo]").val());
        formdata.append("Upload", files[0], files[0].name);

        $.ajax({
            url: "/CompanyDashboard/CreateCompany",
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
                $('#companyModal').modal('hide');
                location.reload();
            }
        })
    })

    $(document).on("click", ".send-reply", function (e) {
        e.preventDefault();
        var formdata = new FormData();
        formdata.append("Comment", $("textarea[name=comment-message]").val())
        $.ajax({
            url: "/WriteComment/JobReview",
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

    $(document).on("click", ".apply-job", function (e) {
        var Applydata = new FormData();
        Applydata.append("WhyYou", $("textarea[name=why-you]").val())
        Applydata.append("JobId", $(".apply-job").name)


        $.ajax({
            url : "/ApplyJob/Apply",
            type: "post",
            dataType : "json",
            data: Applydata,
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
