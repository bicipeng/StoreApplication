// function signUp () {
//   // console.log(e);
//   // console.log(e);
//   console.log("function is calling...");
//   const newCustFn = document.getElementById("signUpfirstName").value;
//   const newCustLn = document.getElementById("signUplastName").value;
//   const newPassWord = document.getElementById("signUppassword").value;
// let data ={
//   FirstName:newCustFn,
//   LastName:newCustLn,
//   CustPassword:newPassWord
// }
//   fetch("Customers/newcustomer", {
//       method: "POST",
//       headers: {
//         'Content-Type': 'application/json;charset=UTF-8',
//         'Accept':'application/json'
//       },
//       body: JSON.stringify(data)      
//   }).then(response =>  response.json()).then(result => {

//  let userInfo = window.localStorage.getItem("user");
//   if(userInfo)  window.localStorage.removeItem("user");
//  window.localStorage.setItem("user", JSON.stringify(result));
//   window.location.href = "/newCust.html";
//   });
//   //window.localStorage.setItem("user", data);\
// };
function signUp() {

  console.log("function is calling...");
  const newCustFn = document.getElementById("signUpfirstName").value;
  const newCustLn = document.getElementById("signUplastName").value;
  const newPassWord = document.getElementById("signUppassword").value;
let data ={
  FirstName:JSON.stringify(newCustFn),
  LastName:JSON.stringify(newCustLn),
  CustPassword:JSON.stringify(newPassWord)
}
  fetch("Customers/newcustomer", {
      method: "POST",
      headers: { 
         'Accept':'application/json',
        'Content-Type': 'application/json'
      
      },
      body: JSON.stringify(data)      
  }).then(response =>  response.json()) 
  .then(json => {console.log(json)
  let userInfo = window.localStorage.getItem("user");
if(userInfo)  window.localStorage.removeItem("user");
window.localStorage.setItem("user", JSON.stringify(json));
 window.location.href = "/newCust.html";
  
  })
      .catch(err => console.log(err));
  //window.localStorage.setItem("user", data);\
 
  // window.localStorage.setItem("user", JSON.stringify(json));
  //window.location.href = "/newCust.html";
  

}

function loadUser(){
  var userInfo = window.localStorage.getItem("user");
  userInfo = JSON.parse(userInfo);
  console.log(userInfo)
  document.getElementById("newCust").innerHTML = `${userInfo.firstName} ${userInfo.lastName}`;
}