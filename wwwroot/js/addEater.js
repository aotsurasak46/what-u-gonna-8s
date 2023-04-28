// Get the modal element
const modal = document.getElementById("modal");

// get button
const btn = document.getElementById("open-modal-btn");
//get close
const span = document.getElementsByClassName("close")[0];

//when onclick
btn.onclick = function () {
    modal.style.display = "block";
};

// when click x 
span.onclick = function () {
    modal.style.display = "none";
};

//click out x
// window.onclick = function (event) {
//   if (event.target == modal) {
//     modal.style.display = "none";
//   }
// };