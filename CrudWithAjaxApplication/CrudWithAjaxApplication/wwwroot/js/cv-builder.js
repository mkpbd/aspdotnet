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

            socialMeida.push({ SocailName : icon, SocialLink:name });
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

            skillItem.push({skillName: skillName})
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
                debugger;
                let workingTool = workingTools[j].innerText;
                Tools.push({ item: workingTool });
            }
           // countForNestLopping += positionName.length;


            WorkingExperince.push({ positionName: positionName, companyName: companyName, workingYear: workingYear, workingTool: Tools })

        }

        // Personal and industrial project

        console.log(socialMeida, skillItem, WorkingExperince);
      
 

    });


});