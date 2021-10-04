(function(){
let stores= JSON.parse(localStorage.getItem("stores"));
console.log (stores);
let storePicked = JSON.parse(localStorage.getItem("pickedId")) ;
let storeName,storeLocation;
//console.log(storePicked===1);
for(let i=0;i<stores.length;i++){
  let store=stores[i]
  if(store.storeId === parseInt(storePicked)){
storeName= store.storeName,
storeLocation=store.storeLocation
  }

}
//}
 let ele = document.getElementById("title");
ele.innerHTML=`Welcome to the ${storeName} , location ${storeLocation}`;
let listInvent = document.getElementById("listInventories");

 window.storeInvens = JSON.parse(localStorage.getItem("inventories"));
// console.log(storeInvens);

for(let j=0;j<storeInvens.length;j++){
  let invent=storeInvens[j];
  listInvent.innerHTML += `<li> ProductId:${invent.productId}       ProductName:${invent.productName}  productPrice:$ ${invent.productPrice}     productDescription: ${invent.productDescription} </li>`
}

    displayCart();

// for(let invent of storeInvens){[
//   
// ]}

})();

function getCartObjects() {
    let cartStr = window.localStorage.getItem("shoppingCart");
    let shoppingCart = [];
    if (cartStr) {
        shoppingCart = JSON.parse(cartStr);
    }
    return shoppingCart;
}

function setCartObjects(items) {
    window.localStorage.setItem("shoppingCart", JSON.stringify(items));
}

function displayCart() {
    let cartEle = document.getElementById("shoppingCart");
    let items = getCartObjects();//get shopping obj
    console.log(items);
    cartEle.innerHTML = items.map(i =>
        `<li>${i.productName} Unit Price: \$${i.productPrice}  Quantity: [${i.quantity}]` +
        ` <b>Total: \$${i.quantity * i.productPrice}</b>` +
        ` <button onclick="deleteItem(${i.productId})">Delete</button>` +
        `</li>`
    ).join('');
}
//use filter to delete item
function deleteItem(productId) {
    let items = getCartObjects();
    items = items.filter(i => i.productId !== productId);
    setCartObjects(items);
    displayCart();
}

//everytime the shopping cart in localstorage is updated, this needs to be called
function addToCart() {
    let productId = parseInt(document.getElementById("productId").value);
    let quant = parseInt(document.getElementById("quant").value);
    let res = window.storeInvens.filter(i => i.productId === productId);
    if (res.length === 0) {
        alert("Your product id is not valid");
        return;
    }
    let product = res[0];

    let items = getCartObjects();//line 36 get shopping cart arr

    let existings = items.filter(i => i.productId === productId);
    if (existings.length > 0) {
        let existItem = existings[0];
        if (existItem.quantity + quant > product.quantity) {
            alert("The quantity you typed in is greater than available!");
            return;
        }
        existItem.quantity += quant;
    }
    else {
        let addProdAttempt = {
            productId: product.productId,
            productName: product.productName,
            quantity: quant,
            productPrice : product.productPrice,
            productDescription: product.productDescription
        };
        if (addProdAttempt.quantity < quant) {
            alert("The quantity you typed in is greater than available!");
            return;
        }
        items.push(addProdAttempt);
    }

    setCartObjects(items);

    displayCart();
    console.log(window.storeInvens);
}

//function 

function checkOut() {
  
    const shoppingCart = getCartObjects();
    let totalPrice = 0;
    let price;
    let arr = [];

    for (let i = 0; i < shoppingCart.length; i++) {
        let singleProduct = shoppingCart[i];
        price = singleProduct.quantity * singleProduct.productPrice;
        totalPrice += price;
        arr.push({
            ProductId: singleProduct.productId,
            Quantity: singleProduct.quantity,

        })
    };
    if (totalPrice === 0) {
 alert("Nothing to check out")
        return;
    }
        let enter = window.prompt(`Your Order total is ${totalPrice}, do you want to check out? Y/N`);
        if (enter.toLowerCase() !== "y") return;
  
  

    let storeId = parseInt(localStorage.getItem("pickedId"));
    let orderDate = Date();
    let user = JSON.parse(localStorage.getItem("user"));
    let userId = parseInt(user.customerId);
    let data = {
        StoreId: storeId,
        OrderTotal: totalPrice,
        OrderProducts: arr,
        CustomerId: userId
    }
    fetch("orders/neworder", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=UTF-8',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(response => response.json())
        .then(json => console.log(json))
        .catch(err => console.log(err));
}
