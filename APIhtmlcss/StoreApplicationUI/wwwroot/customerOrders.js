//list orders for cust 



(function(){
let customer = JSON.parse (window.localStorage.getItem("user"));
if(!customer) return "customer doesnt exits....";
let orderCustName = document.getElementById("cusName");

orderCustName.innerHTML = `${customer.firstName} ,${customer.lastName} `;

const custId = parseInt(customer.customerId);
fetch(`orders/customer/${custId}`)
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

    let listOrder = document.getElementById("custOrders");
    for (let i = 0; i < res.length; i++) {
      listOrder.innerHTML += `<li>  OrderId :${res[i].orderId}, OrderDate: ${res[i].orderDate},  OrderTotal: ${res[i].orderTotal} </li>`

  }
   
})
})();