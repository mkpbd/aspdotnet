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



        console.log(socialMeida, skillItem);
      
 

    });


});