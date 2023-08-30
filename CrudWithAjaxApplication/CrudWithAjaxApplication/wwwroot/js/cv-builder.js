// A $( document ).ready() block.
$(document).ready(function () {

    function getsocialMedia() {
        let socailName = document.querySelectorAll('.socialName');
        let sociallink = document.querySelectorAll('.sociallink');

        let socialMeida = [];

        for (let socialIcon = 0; socialIcon < sociallink.length; socialIcon++) {
            //debugger
            let icon = socailName[socialIcon].innerText;
            let name = sociallink[socialIcon].innerText;

            socialMeida.push({ SocailName: icon, SocialLink: name });
        }

        return socialMeida;
    }

    function getProfessionalSummary() {
        let professionalHeading = document.querySelector('.professional-heading');
        let professionaltext = document.querySelector('.professionaltext');

        const summary = {
            heading: professionalHeading.innerText,
            summary: professionaltext.innerText
        }

        return summary;
    }
    

    function getProfessionalSkill() {

        let skill = document.querySelector('.skills');
        let skillList = document.querySelectorAll('.skill-list li');

        const skillItem = [];

        for (let i = 0; i < skillList.length; i++) {
            let skillName = skillList[i].innerText;

            skillItem.push({ skillName: skillName })
        }

        return skillItem;
    }


    function getWorkingExperience() {

        let postion = document.querySelectorAll('.position')
        let companys = document.querySelectorAll('.companyName');
        let workingYears = document.querySelectorAll('.yorking-year');
        let workingTools = document.querySelectorAll('.workingTools li');
        //     debugger
        const WorkingExperince = [];

        let countForNestLopping = 0;


        for (let i = 0; i < postion.length; i++) {
            let positionName = postion[i].innerText;
            let companyName = companys[i].innerText;
            let workingYear = workingYears[i].innerText;

            let Tools = [];


            for (let j = 0; j < workingTools.length; j++) {
                //    debugger;
                let workingTool = workingTools[j].innerText;
                Tools.push({ item: workingTool });
            }
            // countForNestLopping += positionName.length;


            WorkingExperince.push({
                positionName: positionName,
                Company: companyName,
                workingYear: workingYear,
                workingTool: Tools
            })

        }

        return WorkingExperince;
    }


    function getPersonalAndIndustrialProject() {
        let projects = [];
        let project = document.querySelector('.project');
        let projectPersonal = document.querySelector('.projectPersonal');
        let projecDscription = document.querySelector('.projecDscription');
        let projectCompanys = document.querySelectorAll('.projectCompany');
        let projectCompanyDescriptions = document.querySelectorAll('.projectCompanyDescription');

        for (let i = 0; i < projectCompanys.length; i++) {
            let projectCompany = projectCompanys[i].innerText;
            let projectCompanyDescription = projectCompanyDescriptions[i].innerText;

            projects.push({
                project: project.innerText,
                projectPersonal: projectPersonal.innerText,
                Description: projecDscription.innerText,
                Title: projectCompany,
                projectCompanyDescription: projectCompanyDescription
            })

        }

        return projects;
    }


    function getReference() {
        let reffenceDesig = document.querySelectorAll('.reffenceDesig');
        let reffenceName = document.querySelectorAll('.reffenceName');

        const refference = [];
        for (let i = 0; i < reffenceDesig.length; i++) {
            let designation = reffenceDesig[i].innerText;
            let name = reffenceName[i].innerText;

            refference.push({ Designation: designation, name: name });
        }

        return refference;
    }

    function getEducation() {
        const education = [];

        let subjects = document.querySelectorAll('.subject');

        let passingYears = document.querySelectorAll('.passing-year');

        for (let i = 0; i < subjects.length; i++) {
            let subject = subjects[i].innerText;
            let passingYear = passingYears[i].innerText;

            education.push({ Institution: subject, GraduationYear: passingYear })

        }
        return education;
    }

    function getTraining() {
        let training = document.querySelectorAll('.professionTraining li');
        const trains = [];

        for (let i = 0; i < training.length; i++) {

            trains.push({train: training[i].innerText})
        }

        return trains;
    }

    $("#saveData").click(function () {

        let name = document.querySelector('.cvName');
        let email = document.querySelector('.email');
        let mobile = document.querySelector('.mobile');
       
        let address = document.querySelector('.address');
        const socialMeida =   getsocialMedia();
   

        // professional sumarray 
        const summary = getProfessionalSummary();
  
        const skillItem = getProfessionalSkill();

        // language framework and tools


        //  working expericene
        const WorkingExperince = getWorkingExperience();

        // Personal and industrial project
        const projects = getPersonalAndIndustrialProject();

        // profesional Traing
        const trains = getTraining();

        // education
     
        const education = getEducation();

        //  referece

        const refference = getReference();


        const Data = {
            name: name.innerText,
            email: email.innerText,
            mobile: mobile.innerText,
            socialMeida: socialMeida,
            skillItem: skillItem,
            WorkExperience: WorkingExperince,
            Project: projects,
            Education: education,
            Reference: refference,
            Summary: summary,
            Trainning: trains


        }


        console.log(Data);

        //$.ajax({
        //    type: "POST",
        //    url: "CVBuilder/CVBuilderAdd",
        //    data: Data,
        //    contentType: 'application/x-www-form-urlencoded',
        //    dataType: "json",

        //    success: function (msg) {
        //        console.log(msg);
        //    }

        //});



    });



    // image croping and download 



    $("body").on("change", "#browse_image", function (e) {
        var files = e.target.files;
        var done = function (url) {
            $('#display_image_div').html('');
            $("#display_image_div").html(` <img name = "display_image_data"
                  id = "display_image_data"
                  src = "${url}"
                  alt = "Uploaded Picture"> `);
        };

        if (files && files.length > 0) {
            file = files[0];
            if (URL) {
                done(URL.createObjectURL(file));
            } else if (FileReader) {
                reader = new FileReader();
                reader.onload = function (e) {
                    done(reader.result);
                };
                reader.readAsDataURL(file);
            }
        }

        var image = document.getElementById('display_image_data');
        var button = document.getElementById('crop_button');
        var result = document.getElementById('cropped_image_result');
        var croppable = false;
        var cropper = new Cropper(image, {
            aspectRatio: 1,
            viewMode: 1,
            ready: function () {
                croppable = true;
            },

        });

        button.onclick = function () {
            var croppedCanvas;
            var roundedCanvas;
            var roundedImage;
            if (!croppable) {
                return;
            }
            // Crop
            croppedCanvas = cropper.getCroppedCanvas();
            // Round
            roundedCanvas = getRoundedCanvas(croppedCanvas);
            // Show
            roundedImage = document.createElement('img');
            roundedImage.src = roundedCanvas.toDataURL()
            result.innerHTML = '';
            result.appendChild(roundedImage);
        };
    });

    function getRoundedCanvas(sourceCanvas) {
        var canvas = document.createElement('canvas');
        var context = canvas.getContext('2d');
        var width = sourceCanvas.width;
        var height = sourceCanvas.height;
        canvas.width = width;
        canvas.height = height;
        context.imageSmoothingEnabled = true;
        context.drawImage(sourceCanvas, 0, 0, width, height);
        context.globalCompositeOperation = 'destination-in';
        context.beginPath();
        context.arc(width / 2, height / 2, Math.min(width, height) / 2, 0, 2 * Math.PI, true);
        context.fill();
        return canvas;
    }


    function download() {
        var linkSource = $('#cropped_image_result img').attr('src');
        var fileName = 'download.png';
        const downloadLink = document.createElement("a");
        downloadLink.href = linkSource;
        downloadLink.download = fileName;
        downloadLink.click();
    }

    function upload() {
        var base64data = $('#cropped_image_result img').attr('src');
        //alert(base64data);
        debugger;
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "controlerName/methodName",
            data: {
                image: base64data
            },
            success: function (response) {
                if (response.status == true) {
                    alert(response.msg);
                } else {
                    alert("Image not uploaded.");
                }
            }
        });
    }




});