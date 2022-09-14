function myFunction (){
  var un = document.forms ["myForm"]["uname"].value;
  var pw = document.forms ["myForm"]["psw"].value;
  if (un === 'abc' && pw === '123'){
    alert ("Succesfully Signed In!");
     window.location.href = "loginPage.html";
  } else {
    alert ("Invalid Username and Password");
  }
}

