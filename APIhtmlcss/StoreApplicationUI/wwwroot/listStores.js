(function() {
  // const buttonStores = document.getElementById("refer-btn")
   const listStores = document.getElementById("listStores")
   //console.log(buttonStores);

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
                   listStores.innerHTML += `<li>  StoreId:${res[i].storeId}    StoreName: ${res[i].storeName}       StoreLocation: ${res[i].storeLocation} </li>`
         
               }
               window.localStorage.removeItem("stores");
               window.localStorage.setItem("stores",JSON.stringify(res));
           })
   
    
//   let custNameDiv = document.getElementById("custInStore");
  
// let custName= JSON.parse(window.localStorage.getItem("user"));
// if(custName.firstName && custName.lastName){
//   custNameDiv.innerHTML =`${custName.firstName} ${custName.lastName} `;
// }

   

})();