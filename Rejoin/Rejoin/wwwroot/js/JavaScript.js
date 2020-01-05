$(document).ready(function () {
    removingExp();
    removingEdu();
    $(document).on("click", ".finish-resume", function (e) {

        e.preventDefault();

        var educations = new Array();
        $(".card-edu").each((index, item) => {
            educations.push({
                SchoolName: $(item).find('input[name="resume-edu-school"]').val(),
                Qualification: $(item).find('input[name="resume-edu-quality"]').val(),
                StartedAt: $(item).find('select[name="resume-edu-since"]').val(),
                FinishedAt: $(item).find('select[name="resume-edu-till"]').val(),
                University: $(item).find('select[name="resume-edu-uni"]').val(),
            })
        })


        var experiences = new Array();
        $(".card-exp").each((index, item) => {
            experiences.push({
                CompanyName: $(item).find('input[name="resume-exp-company"]').val(),
                Position: $(item).find('input[name="resume-exp-position"]').val(),
                StartedAt: $(item).find('select[name="resume-exp-since"]').val(),
                FinishedAt: $(item).find('select[name="resume-exp-till"]').val(),
            })
        })

        var photos = $("input[name=resume-input-img]")[0].files;

        var resumedata = new FormData();
        resumedata.append("name", $("input[name=resume-input-name]").val());
        resumedata.append("profession", $("input[name=resume-input-profession]").val());
        resumedata.append("lastname", $("input[name=resume-input-lastname]").val());
        resumedata.append("email", $("input[name=resume-input-email]").val());
        resumedata.append("phone", $("input[name=resume-input-phone]").val());
        resumedata.append("personalSkill", $("input[name=resume-input-personal]").val());
        resumedata.append("experienceTime", $("select[name=resume-input-exp] option:selected").text());
        if (photos.length > 0) {
            resumedata.append("Upload", photos[0], photos[0].name);
        }

        for (let i = 0; i < experiences.length; i++) {
            resumedata.append("experiences[" + i + "].CompanyName", experiences[i].CompanyName);
            resumedata.append("experiences[" + i + "].Position", experiences[i].Position);
            resumedata.append("experiences[" + i + "].StartedAt", experiences[i].StartedAt);
            resumedata.append("experiences[" + i + "].FinishedAt", experiences[i].FinishedAt);
        }


        for (let i = 0; i < educations.length; i++) {
            resumedata.append("educations[" + i + "].SchoolName", educations[i].SchoolName);
            resumedata.append("educations[" + i + "].Qualification", educations[i].Qualification);
            resumedata.append("educations[" + i + "].StartedAt", educations[i].StartedAt);
            resumedata.append("educations[" + i + "].FinishedAt", educations[i].FinishedAt);
            resumedata.append("educations[" + i + "].University", educations[i].University);
        }

        $.ajax({
            url: "/Resume/CreateResume",
            type: "post",
            dataType: "json",
            data: resumedata,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (response) {

                toastr.success(response.message, 'CV niz əlavə olundu', { timeOut: 600 });
                if (response.isRedirect) {
                    window.location.href = response.redirectUrl;
                }
            },
            error: function (error) {
                toastr.error(response.message, 'məlumatları düzgün doldurduğunuzdan əmin olun', { timeOut: 600 });
            },
            complete: function () {

            }
        })
    })

    $(document).on("click", ".edit-resume", function (e) {

        e.preventDefault();

        var educations = new Array();
        $(".card-edu").each((index, item) => {
            educations.push({
                SchoolName: $(item).find('input[name="resume-edu-school"]').val(),
                Qualification: $(item).find('input[name="resume-edu-quality"]').val(),
                StartedAt: $(item).find('select[name="resume-edu-since"]').val(),
                FinishedAt: $(item).find('select[name="resume-edu-till"]').val(),
                University: $(item).find('select[name="resume-edu-uni"]').val(),
            })
        })


        var experiences = new Array();
        $(".card-exp").each((index, item) => {
            experiences.push({
                CompanyName: $(item).find('input[name="resume-exp-company"]').val(),
                Position: $(item).find('input[name="resume-exp-position"]').val(),
                StartedAt: $(item).find('select[name="resume-exp-since"]').val(),
                FinishedAt: $(item).find('select[name="resume-exp-till"]').val(),
            })
        })


        var editphotos = $("input[name=resume-input-img]")[0].files;

        var EditedResumedata = new FormData();
        EditedResumedata.append("name", $("input[name=resume-input-name]").val());
        EditedResumedata.append("profession", $("input[name=resume-input-profession]").val());
        EditedResumedata.append("lastname", $("input[name=resume-input-lastname]").val());
        EditedResumedata.append("email", $("input[name=resume-input-email]").val());
        EditedResumedata.append("phone", $("input[name=resume-input-phone]").val());
        EditedResumedata.append("personalSkill", $("input[name=resume-input-personal]").val());
        EditedResumedata.append("experienceTime", $("select[name=resume-input-exp] option:selected").text());
        if (editphotos.length > 0) {
            EditedResumedata.append("Upload", editphotos[0], editphotos[0].name);
        }

        for (let i = 0; i < experiences.length; i++) {
            EditedResumedata.append("experiences[" + i + "].CompanyName", experiences[i].CompanyName);
            EditedResumedata.append("experiences[" + i + "].Position", experiences[i].Position);
            EditedResumedata.append("experiences[" + i + "].StartedAt", experiences[i].StartedAt);
            EditedResumedata.append("experiences[" + i + "].FinishedAt", experiences[i].FinishedAt);
        }


        for (let i = 0; i < educations.length; i++) {
            EditedResumedata.append("educations[" + i + "].SchoolName", educations[i].SchoolName);
            EditedResumedata.append("educations[" + i + "].Qualification", educations[i].Qualification);
            EditedResumedata.append("educations[" + i + "].StartedAt", educations[i].StartedAt);
            EditedResumedata.append("educations[" + i + "].FinishedAt", educations[i].FinishedAt);
            EditedResumedata.append("educations[" + i + "].University", educations[i].University);
        }

        $.ajax({
            url: "/Resume/EditResume",
            type: "post",
            dataType: "json",
            data: EditedResumedata,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (response) {

                toastr.success(response.message, 'CV redaktə olundu', { timeOut: 600 });
                if (response.isRedirect) {
                    window.location.href = response.redirectUrl;
                }
            },
            error: function (error) {
                toastr.error(error.message, 'məlumatları düzgün doldurduğunuzdan əmin olun', { timeOut: 600 });
            },
            complete: function () {

            }
        })
    })
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
        if (files.length>0) {
            formdata.append("Upload", files[0], files[0].name);
        }

        $.ajax({
            url: "/CompanyDashboard/CreateCompany",
            type: "post",
            dataType: "json",
            data: formdata,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (data, textStatus, xhr) {
                console.log(xhr.status);
            },
            success: function (response) {

                toastr.success(response.message, 'Şirkət profili yaradıldı artıq iş elanı verə bilərsiniz', { timeOut: 900 });
                $('#companyModal').modal('hide');
                location.reload();
            },
            error: function (error) {
                toastr.error(error.message, 'məlumatları düzgün doldurduğunuzdan əmin olun', { timeOut: 900 });
            },
            complete: function () {
              
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
        Applydata.append("JobId", $("#apply-job").attr('name'))


        $.ajax({
            url: "/ApplyJob/Apply",
            type: "post",
            dataType: "json",
            data: Applydata,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (response) {
                toastr.success(response.message, 'İş müraciətiniz tamamlandı', { timeOut: 900 });
            },
            error: function (error) {

            },
            complete: function () {
            }
        })
    })


    $(".add-another-edu").click((e) => {

        $(".add-another-edu").parent().before(`     <div class="card card-edu">
                        <div class="card-header ">
                            <h3 class="card-title">Təhsili</h3>

                            <div class="card-options">
                                <a class="btn btn-light btn-sm remove-edu" href="#"><i class="fas fa-minus-circle"></i>Sil</a>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="form-group col-lg-6 col-md-12" style="padding-right:4px !important">
                                    <label class="form-label text-dark">Məktəb</label>
                                    <input name="resume-edu-school" type="text" class="form-control" placeholder="Məktəb adı" required>
                                </div>
                                <div class="form-group col-lg-6 col-md-12" style="padding-left:4px !important">
                                    <label class="form-label text-dark">İxtisas</label>

                                    <input name="resume-edu-quality" type="text" class="form-control" placeholder="İxtisas" required>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label text-dark">Universitet</label>
                                <select name="resume-edu-uni" class="form-control custom-select select2-show-search" data-placeholder="Universitet seç">
                                    <option value="Universitet">Universitet</option>
                                    <option value="Bakı Dövlət Universiteti">Bakı Dövlət Universiteti</option>
                                    <option value="Azərbaycan Dövlət Neft və Sənaye Universiteti">Azərbaycan Dövlət Neft və Sənaye Universiteti</option>
                                    <option value="Azərbaycan Dövlət İqtisad Universiteti">Azərbaycan Dövlət İqtisad Universiteti</option>
                                    <option value="Bakı Ali Neft Məktəbi">Bakı Ali Neft Məktəbi</option>
                                    <option value="Azərbaycan Dövlət Dillər Universiteti">Azərbaycan Dövlət Dillər Universiteti</option>
                                    <option value="Azərbaycan Dövlət Texniki Universiteti">Azərbaycan Dövlət Texniki Universiteti</option>
                                    <option value="Azərbaycan Dövlət Memarlıq və İnşaat Universiteti">Azərbaycan Dövlət Memarlıq və İnşaat Universiteti</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <div class="row gutters-xs">
                                    <div class="col-6">
                                        <label class="form-label text-dark">Başlama tarixi</label>
                                        <select name="resume-edu-since" class="form-control custom-select select2-show-search" data-placeholder="Başlama tarixi seç">
                                            <option value="0">Başlama tarixi</option>
                                            <option value="2019">2019</option>
                                            <option value="2018">2018</option>
                                            <option value="2017">2017</option>
                                            <option value="2016">2016</option>
                                            <option value="2015">2015</option>
                                            <option value="2014">2014</option>
                                            <option value="2013">2013</option>
                                            <option value="2012">2012</option>
                                            <option value="2011">2011</option>
                                            <option value="2010">2010</option>
                                            <option value="2009">2009</option>
                                            <option value="2008">2008</option>
                                            <option value="2007">2007</option>
                                            <option value="2006">2006</option>
                                            <option value="2005">2005</option>
                                            <option value="2004">2004</option>
                                            <option value="2003">2003</option>
                                            <option value="2002">2002</option>
                                            <option value="2001">2001</option>
                                            <option value="2000">2000</option>
                                            <option value="1999">1999</option>
                                            <option value="1998">1998</option>
                                            <option value="1997">1997</option>
                                            <option value="1996">1996</option>
                                            <option value="1995">1995</option>
                                            <option value="1994">1994</option>
                                            <option value="1993">1993</option>
                                            <option value="1992">1992</option>
                                            <option value="1991">1991</option>
                                            <option value="1990">1990</option>
                                        </select>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label text-dark">Bitiş tarixi</label>
                                        <select name="resume-edu-till" class="form-control custom-select select2-show-search" data-placeholder="Bitiş tarixi seç">
                                            <option value="0">Bitiş tarixi</option>
                                            <option value="2019">2019</option>
                                            <option value="2018">2018</option>
                                            <option value="2017">2017</option>
                                            <option value="2016">2016</option>
                                            <option value="2015">2015</option>
                                            <option value="2014">2014</option>
                                            <option value="2013">2013</option>
                                            <option value="2012">2012</option>
                                            <option value="2011">2011</option>
                                            <option value="2010">2010</option>
                                            <option value="2009">2009</option>
                                            <option value="2008">2008</option>
                                            <option value="2007">2007</option>
                                            <option value="2006">2006</option>
                                            <option value="2005">2005</option>
                                            <option value="2004">2004</option>
                                            <option value="2003">2003</option>
                                            <option value="2002">2002</option>
                                            <option value="2001">2001</option>
                                            <option value="2000">2000</option>
                                            <option value="1999">1999</option>
                                            <option value="1998">1998</option>
                                            <option value="1997">1997</option>
                                            <option value="1996">1996</option>
                                            <option value="1995">1995</option>
                                            <option value="1994">1994</option>
                                            <option value="1993">1993</option>
                                            <option value="1992">1992</option>
                                            <option value="1991">1991</option>
                                            <option value="1990">1990</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>`);
        removingEdu();
    })



    $(".add-another-exp").click((e) => {
        $(".add-another-exp").parent().before(` <div class="card card-exp">
                        <div class="card-header ">
                            <h3 class="card-title">İş təcrübəsi</h3>

                            <div class="card-options">
                                <a class="btn btn-light btn-sm remove-exp" href="#"><i class="fa fa-plus"></i> Sil</a>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="form-group col-lg-6 col-md-12" style="padding-right:4px !important">
                                    <label class="form-label text-dark">Şirkət adı</label>
                                    <input name="resume-exp-company" type="text" class="form-control" placeholder="Şirkət adı" required>
                                </div>
                                <div class="form-group col-lg-6 col-md-12" style="padding-left:4px !important">
                                    <label class="form-label text-dark">Pozisiya</label>
                                    <input name="resume-exp-position" type="text" class="form-control" placeholder="Pozisiya" required>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row gutters-xs">
                                    <div class="col-6">
                                        <label class="form-label text-dark">Başlama tarixi</label>
                                        <select name="resume-exp-since" class="form-control custom-select select2-show-search" data-placeholder="Başlama tarixi seç">
                                            <option value="0">Başlama tarixi</option>
                                            <option value="2019">2019</option>
                                            <option value="2018">2018</option>
                                            <option value="2017">2017</option>
                                            <option value="2016">2016</option>
                                            <option value="2015">2015</option>
                                            <option value="2014">2014</option>
                                            <option value="2013">2013</option>
                                            <option value="2012">2012</option>
                                            <option value="2011">2011</option>
                                            <option value="2010">2010</option>
                                            <option value="2009">2009</option>
                                            <option value="2008">2008</option>
                                            <option value="2007">2007</option>
                                            <option value="2006">2006</option>
                                            <option value="2005">2005</option>
                                            <option value="2004">2004</option>
                                            <option value="2003">2003</option>
                                            <option value="2002">2002</option>
                                            <option value="2001">2001</option>
                                            <option value="2000">2000</option>
                                            <option value="1999">1999</option>
                                            <option value="1998">1998</option>
                                            <option value="1997">1997</option>
                                            <option value="1996">1996</option>
                                            <option value="1995">1995</option>
                                            <option value="1994">1994</option>
                                            <option value="1993">1993</option>
                                            <option value="1992">1992</option>
                                            <option value="1991">1991</option>
                                            <option value="1990">1990</option>
                                        </select>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label text-dark">Bitiş tarixi</label>
                                        <select name="resume-exp-till" class="form-control custom-select select2-show-search" data-placeholder="Bitiş tarixi seç">
                                            <option value="0">Bitiş tarixi</option>
                                            <option value="2019">2019</option>
                                            <option value="2018">2018</option>
                                            <option value="2017">2017</option>
                                            <option value="2016">2016</option>
                                            <option value="2015">2015</option>
                                            <option value="2014">2014</option>
                                            <option value="2013">2013</option>
                                            <option value="2012">2012</option>
                                            <option value="2011">2011</option>
                                            <option value="2010">2010</option>
                                            <option value="2009">2009</option>
                                            <option value="2008">2008</option>
                                            <option value="2007">2007</option>
                                            <option value="2006">2006</option>
                                            <option value="2005">2005</option>
                                            <option value="2004">2004</option>
                                            <option value="2003">2003</option>
                                            <option value="2002">2002</option>
                                            <option value="2001">2001</option>
                                            <option value="2000">2000</option>
                                            <option value="1999">1999</option>
                                            <option value="1998">1998</option>
                                            <option value="1997">1997</option>
                                            <option value="1996">1996</option>
                                            <option value="1995">1995</option>
                                            <option value="1994">1994</option>
                                            <option value="1993">1993</option>
                                            <option value="1992">1992</option>
                                            <option value="1991">1991</option>
                                            <option value="1990">1990</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>`);
        removingExp()
    })



    function removingEdu() {
        $(".remove-edu").each((index, item) => {
            $(item).click((e) => {
                $(item).closest('.card-edu').remove();
            })
        })
    }
    function removingExp() {
        $(".remove-exp").each((index, item) => {
            $(item).click((e) => {
                $(item).closest('.card-exp').remove();
            })
        })
    }



});
