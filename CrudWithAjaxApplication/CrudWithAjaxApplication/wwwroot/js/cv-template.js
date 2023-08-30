let editable = document.querySelectorAll('.editable');
let edittableId = document.getElementById('cvEditable');
let saveButton = document.getElementById('saveData');

let uploadImage = document.getElementById('image-upload');

let imageChange = document.getElementById('image-change');

let ulli = document.querySelectorAll('ul li');

const editButton = document.querySelector('.mkp__card');

// Get the modal
let modal = document.getElementById("myModal");
// Get the <span> element that closes the modal
let span = document.getElementsByClassName("close")[0];

uploadImage.addEventListener('click', function (event) {
    modal.style.display = 'block'
    console.log(uploadImage);
});

span.addEventListener("click", function (event) {

    modal.style.display = 'none';

});

// let anchor = document.querySelector('a');

// p.addEventListener('click', function(){
//     console.log(p.innerHTML);
// })



//editable.forEach(function (elem) {

//    elem.addEventListener('mouseenter', function (ev) {
//        ev.preventDefault();
//        // console.log(elem.innerHTML);
//        //  elem.setAttribute('contenteditable', 'true');
//        ev.target.setAttribute('contenteditable', 'true');
//        ev.target.style.border = '1px solid #ddd';
//        ev.target.padding = 'none';

//       // editButton.style.top = (ev.layerY) + 'px';
//      //  editButton.style.display = 'block';

//      //  console.log(ev);        // let anchor = ev.tagret.document.querySelector('a');
//        // anchor.setAttribute('contenteditable', 'true');
//        // anchor.addEventListener('input', function(e){


//        // });
//    });
//})

//editable.forEach(function (elem) {

//    elem.addEventListener('click', function (ev) {
//        ev.preventDefault();
//        // console.log(elem.innerHTML);
//        //  elem.setAttribute('contenteditable', 'true');
//        ev.target.setAttribute('contenteditable', 'true');
//        ev.target.style.border = '1px solid #ddd';
//        ev.target.padding = 'none';

//       // editButton.style.top = (ev.layerY) + 'px';
//      //  editButton.style.display = 'block';

//     //   console.log(ev);        // let anchor = ev.tagret.document.querySelector('a');
//        // anchor.setAttribute('contenteditable', 'true');
//        // anchor.addEventListener('input', function(e){


//        // });
//    });
//})

// mouse leave event

//editable.forEach(function (elem) {

//    elem.addEventListener('mouseout', function (ev) {
//        ev.preventDefault();

//        ev.target.setAttribute('contenteditable', false);
//        ev.target.style.border = 'none';
//        ev.target.style.padding = '0px';
//        editButton.style.display = 'none';

//        // });
//    });
//})


edittableId.addEventListener('click', function (ev) {
    ev.preventDefault();
    //console.log("clicked edit button");
    editable.forEach(function (el) {
        el.setAttribute('contenteditable', 'true');
        el.style.border = '1px solid #ddd';
        el.style.padding = '5px 10px';
        console.log("clicked edit button");
    })
    saveButton.style.display = 'block';

});



// p.forEach(function(elem){

//   elem.addEventListener('click', function(ev){
//       ev.preventDefault();
//       // console.log(elem.innerHTML);
//       // elem.setAttribute('contenteditable', 'true');
//       console.log(ev.target.setAttribute('contenteditable',true));
//       // let anchor = ev.tagret.document.querySelector('a');
//       // anchor.setAttribute('contenteditable', 'true');
//       // anchor.addEventListener('input', function(e){


//      // });
//   });
// })



//  show button on mouse click

// p.forEach(element => {
//   // console.log('foreach is running');
//   let isEventTrue = false;
//    element.addEventListener('mouseenter', ev =>{

//     editButton.style.top = (ev.layerY+10)+'px';
//     editButton.style.left = (ev.layerX)+'px';
//     editButton.style.display = 'block';
//     //
//     //element.after(`10283`)
//    //  element.innerText = 'hello kamal';


//    // console.log(ev);
//    })
// });

// edtibale Button

//const editiableButtonForelementEdit = document.getElementById('edit-section');

// editiableButtonForelementEdit.addEventListener('click', function(e){

//   // console.log(e);
//   editable.forEach(function(elem){

//     elem.addEventListener('input', function(ev){
//       ev.target.setAttribute('contenteditable',true);
//       console.log(ev.target);
//       elem.style.border= '2px solid red';
//       elem.style.padding = '5px 10px';
//       elem.style.margin = '10px 10px';
//     });
//     //  console.log(elem);
//     // elem.target.setAttribute('contenteditable',true);
//     // elem.style.border= '2px solid red';
//     // elem.style.padding = '5px 10px';
//     // elem.style.margin = '10px 10px';
//    })
// // })