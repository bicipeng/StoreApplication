
  function StoreDetails(){
    console.log("runningggg....")
    let storeId = document.getElementById("yourPicked").value;
   console.log(storeId);
    window.localStorage.setItem("storeDetailId", storeId);

    window.location.href="StoreHome.html";

  };
