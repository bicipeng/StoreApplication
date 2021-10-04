(function(){
  let stores= JSON.parse(localStorage.getItem("stores"));
  console.log (stores);
  let storePicked = JSON.parse(localStorage.getItem("storeDetailId")) ;
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
  
//
  
  // for(let invent of storeInvens){[
  //   
  // ]}
  
  })();