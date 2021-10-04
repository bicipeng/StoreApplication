
//list orders for cust 



(function(){
  let storeId = JSON.parse (window.localStorage.getItem("storeDetailId"));
  if(!storeId) return "customer doesnt exits....";
  let sId = parseInt(storeId);
  console.log(sId);
//   let sn, sl;
let stores = JSON.parse(window.localStorage.getItem("stores"));
console.log(stores);
for(let i =0 ;i<stores.length;i++){
    let store=stores[i];
    if(sId === store.storeId){
sn= store.storeName
sl=store.storeLocation
    }
}
  let orderCustName = document.getElementById("storeNameO");
  
  orderCustName.innerHTML = `Welcome to ${sn} , located in ${sl} `;
  

  fetch(`orders/${sId}`)
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
  
      let listOrder = document.getElementById("sOrderList");
      let arr=[];
      for (let i = 0; i < res.length; i++) {
        listOrder.innerHTML += `<li>  OrderId :${res[i].orderId}, OrderDate: ${res[i].orderDate},  OrderTotal: ${res[i].orderTotal} Quantity: ${res[i].orderProducts.map(ele => arr.push(ele.quantity))}</li>`
  
    }
     
  })
  })();