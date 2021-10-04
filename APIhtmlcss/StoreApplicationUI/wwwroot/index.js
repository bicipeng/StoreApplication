  
//const button = document.querySelector('.weatherlist');
//const listofweathers = document.querySelector('.listofweathers');

//button.addEventListener('click', (e) => {

//  fetch('WeatherForecast')
//  .then(res => {
//    if (!res.ok) {
//      console.log('NOT OK')
//      throw new Error(`Network response was not ok (${res.status})`);
//    }
//    else {
//      return res.json();
//    }
//  })
//  .then(res => {
//    console.log(res);
 
//    for (let x = 0; x < res.length;x++) {
//      listofweathers.innerText += `The temp is ${res[x].temperatureC}.\nThe weather is ${res[x].summary}.\n`
//    }
//  })
//    .catch(err => console.log(`There was an error ${err}`));
//});

//const button2 = document.getElementById("login");
//button2.addEventListener('click', (e) => {

//    var lastName = document.getElementById('lastName').value;
//    var firstName = document.getElementById('firstName').value;
//    var password = document.getElementById('firstName').value
//    fetch('Customer/Add', {
//        method: 'post',
//        body: JSON.stringify({
//            LastName: lastName,
//            FirstName: firstName,
//            CustPassword: password
//        })
//    }).catch(err => console.log(err));
//})
//list stores
//const buttonStores = document.querySelector(".Stores")
function listStores() {
   // const buttonStores = document.getElementById("refer-btn")
    const listStores = document.getElementById("listStores")
    //console.log(buttonStores);
    let loaded = false;

    if (!loaded) {
        fetch('stores')
            .then(res => {
                if (!res.ok) {
                    console.log("Unable to fetch!")
                    throw new Error(`this is the error ${res.status}`);
                }
                else {
                    return res.json();
                }
            })
            .then(res => {
                console.log(res)
            //    window.location.href = "/listStores.html";

                for (let i = 0; i < res.length; i++) {
                    listStores.innerHTML += `<li>  StoreId:${res[i].storeId}         StoreName: ${res[i].storeName}            StoreLocation: ${res[i].storeLocation} </li>`
          
                }
                window.localStorage.removeItem("store");
                window.localStorage.setItem("stores",JSON.stringify(res));
            })
    } 
        loaded = true;
    //let newDiv = document.getElementById("choosestore");
   
    //newDiv.appendChild('<label for="pickstore">Pick a store </label>');
    //newDIv.appendChild(<'input id="storeId" type="number" min="1" max="6" required/>');

    

    return;
    

}
//function addElement(){
//    let newDiv = document.createElement("div");
    
//    let newLabel = document.createElement("label");
//    newLabel.innerHTML = "Pick a store to view Products:";
//    let newInput = document.createElement("input");
//    newInput.id = "storeId",
//        newInput.type = "number";
//    newInput.min = "1";
//    newInput.max = "6";
//    newDiv.appendChild(newLabel);
//    newDiv.appendChild(newInput);

//}



function login() {
    //log in customer
    const busttonCustomers = document.getElementById("login-LoginP")
    const listCustomer = document.getElementById("uniqCustomer")
    const inputFirstName = document.getElementById("signUpfirstName").value;
    const inputPassword = document.getElementById("signUppassword").value;
    console.log(`**input firstName${inputFirstName}`);
    fetch(`customers/${inputFirstName}/${inputPassword}`)
        .then(res => {
            if (!res.ok) {
                console.log("Unable to fetch!")
                throw new Error(`this is the error ${res.status}`);
            }
            else {
                return res.json();
            }
        })
        .then(res => {
            console.log(`here is res ${res}`)
            console.log(res)
            //listCustomer.innerHTML = `${res.firstName} ,${res.lastName} `;
            window.localStorage.setItem("user", JSON.stringify(res));
            window.location.href = "/displayCust.html";
        })

}

function checkLogin() {
    var userInfo = window.localStorage.getItem("user");
    if (!userInfo) {
        alert("You have not been logged in yet!");
        window.location.href = "/login.html";
    }
    userInfo = JSON.parse(userInfo);
    document.getElementById("uniqCustomer").innerHTML = `${userInfo.firstName} ${userInfo.lastName}`;
}
//log out window.localstorage.setItem("user",null)

//fucntion get store inventory based on ID
//function getInventories() {
//    //listStores.HTML LINE 24
//    const inputVal = document.getElementById("storeId");
//    const storeId = inputVal.value;
//    fetch(`stores/${storeId}`)
//        .then(res => {
//            if (!res.ok) {
//                console.log("Unable to fetch!")
//                throw new Error(`this is the error ${res.status}`);
//            }
//            else {
//                return res.json();
//            }
//        })
//        .then(res => {
           
//            console.log(res)
//            //listCustomer.innerHTML = `${res.firstName} ,${res.lastName} `;
          
//        })

   
//}

function signUp(e) {
    console.log(e);
    console.log(e);
    console.log("function is calling...");
    const newCustFn = document.getElementById("signUpfirstName").value;
    const newCustLn = document.getElementById("signUplastName").value;
    const newPassWord = document.getElementById("signUppassword").value;
let data ={
    FirstName:newCustFn,
    LastName:newCustLn,
    CustPassword:newPassWord
}
    fetch("Customers/newcustomer", {
        method: "POST",
        headers: {
          'Content-Type': 'application/json;charset=UTF-8',
          'Accept':'application/json'
        },
        body: JSON.stringify(data)      
    }).then(response =>  response.json()) 
    .then(json => {
           window.localStorage.removeItem("user");
    window.localStorage.setItem("user", JSON.stringify(json));
    window.location.href = "/newCust.html";
    })
        .catch(err => console.log(err));
    //window.localStorage.setItem("user", data);\
 

}

function listInventories() {

    //listStores.HTML LINE 24
    const inputId = document.getElementById("storeId").value;

    fetch(`stores/${inputId}`)
        .then(res => {
            if (!res.ok) {
                console.log("Unable to fetch!")
                throw new Error(`this is the error ${res.status}`);
            }
            else {
                return res.json();
            }
        })
        .then(res => {

            console.log(res)
            //listCustomer.innerHTML = `${res.firstName} ,${res.lastName} `;
            window.localStorage.setItem("inventories", JSON.stringify(res));
            window.localStorage.setItem("pickedId", inputId);
            window.location.href = "/listInventories.html";
            console.log(localStorage.getItem("inventories"));
            console.log(localStorage.getItem("pickedId"));

        })



};


function newCust() {
    const userInfo = window.localStorage.getItem("user");

    userInfo = JSON.parse(userInfo);
    document.getElementById("newCust").innerHTML = `${userInfo.firstName} ${userInfo.lastName}`;
}