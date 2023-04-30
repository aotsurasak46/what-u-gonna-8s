function myFunction() {
    var x = document.getElementById("myTopnav");
      
      if (x.className.indexOf("responsive") != -1) {
        x.className = x.className.replace("responsive", "");
      } else {
        x.className += " responsive";
      }
  }

  document.addEventListener('DOMContentLoaded', function() {
    //change user icon
    const userButton = document.getElementById("user_img");
    let isUserEnabled = false;
    
    userButton.addEventListener("click", function() {
  
      userButton.src = "https://cdn.discordapp.com/attachments/975683623804100679/1101101923815395328/1946429.png";
      eaterBtn.style.backgroundColor = '';
      eaterBtn.style.color = '';
      deliverBtn.style.color = '';
      deliverBtn.style.backgroundColor = '';
  
      isUserEnabled = !isUserEnabled;
    });

    //deliver-eater 
    // get the button elements
    const deliverBtn = document.getElementById('Deliver');
    const eaterBtn = document.getElementById('Eater');
    const userBtn = document.getElementById('user');


    // add event listeners to the buttons
    deliverBtn.addEventListener('click', function() {
      deliverBtn.style.backgroundColor = 'rgba(255, 255, 255, 0.8)';
      deliverBtn.style.color = '#002D44';
      eaterBtn.style.backgroundColor = '';
      eaterBtn.style.color = '';
      userBtn.style.backgroundColor = '';
      userBtn.style.color = '';
      isUserEnabled = false;
      userButton.src = "https://cdn.discordapp.com/attachments/975683623804100679/1101101923467276388/userpic.png";
    });

    eaterBtn.addEventListener('click', function() {
      eaterBtn.style.backgroundColor = 'rgba(255, 255, 255, 0.8)';
      eaterBtn.style.color = '#002D44';
      deliverBtn.style.color = '';
      deliverBtn.style.backgroundColor = '';
      userBtn.style.backgroundColor = '';
      userBtn.style.color = '';
      isUserEnabled = false;
      userButton.src = "https://cdn.discordapp.com/attachments/975683623804100679/1101101923467276388/userpic.png";
    });

    userBtn.addEventListener('click', function() {
      userBtn.style.backgroundColor = 'rgba(255, 255, 255, 0.8)';
      userBtn.style.color = '#002D44';
      eaterBtn.style.backgroundColor = '';
      eaterBtn.style.color = '';
      deliverBtn.style.color = '';
      deliverBtn.style.backgroundColor = '';
    });
});
