(function(){
  let stores= JSON.parse(localStorage.getItem("stores"));
  let storeId =  parseInt(window.localStorage.getItem("storeDetailId"));
  let sName;
  for(let i=0;i<stores.length;i++){
    if(storeId === stores[i].storeId){
      sName=stores[i].storeName;
  
     
    }
   
  }
  // window.localStorage.setItem("storeName",sName);
  // window.localStorage.setItem("storeLocation",sLocation);


  let ele = document.getElementById("storeN");
 


  ele.innerHTML=`${sName}`;
  
})();