// A $( document ).ready() block.
$(document).ready(function () {

    $("#saveData").click(function () {

        let name = document.querySelector('.cvName');
        let email = document.querySelector('.email');
        let mobile = document.querySelector('.mobile');
        let socailName = document.querySelectorAll('.socialName');
        let sociallink = document.querySelectorAll('.sociallink');
        let address = document.querySelector('.address');

        let socialMeida = [];

        for (let socialIcon = 0; socialIcon < sociallink.length; socialIcon++) {
            //debugger
            let icon = socailName[socialIcon].innerText;
            let name = sociallink[socialIcon].innerText;

            socialMeida.push({ SocailName: icon, SocialLink: name });
        }

        // professional sumarray 
        let professionalHeading = document.querySelector('.professional-heading');
        let professionaltext = document.querySelector('.professionaltext');


        // language framework and tools

        let skill = document.querySelector('.skills');
        let skillList = document.querySelectorAll('.skill-list li');

        const skillItem = [];

        for (let i = 0; i < skillList.length; i++) {
            let skillName = skillList[i].innerText;

            skillItem.push({ skillName: skillName })
        }



        //  working expericene

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


            WorkingExperince.push({ positionName: positionName, Company: companyName, workingYear: workingYear, workingTool: Tools })

        }

        // Personal and industrial project
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
                project: project.innerText, projectPersonal: projectPersonal.innerText,
                Description: projecDscription.innerText, Title: projectCompany, projectCompanyDescription: projectCompanyDescription
            })




        }



        // profesional Traing

        let traings = document.querySelectorAll('.professionTraining');


        // education
        const education = [];

        let subjects = document.querySelectorAll('.subject');

        let passingYears = document.querySelectorAll('.passing-year');

        for (let i = 0; i < subjects.length; i++) {
            let subject = subjects[i].innerText;
            let passingYear = passingYears[i].innerText;

            education.push({ Institution: subject, GraduationYear: passingYear })

        }


        //  referece

        let reffenceDesig = document.querySelectorAll('.reffenceDesig');
        let reffenceName = document.querySelectorAll('.reffenceName');

        const refference = [];
        for (let i = 0; i < reffenceDesig.length; i++) {
            let designation = reffenceDesig[i].innerText;
            let name = reffenceName[i].innerText;

            refference.push({ Designation: designation, name: name });
        }


        const Data = {
            name: name.innerText,
            email: email.innerText,
            mobile: mobile.innerText,
            socialMeida: socialMeida,
            skillItem: skillItem,
            WorkExperience: WorkingExperince,
            Project: projects,
            Education: education,
            Reference: refference

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


});