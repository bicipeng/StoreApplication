(function(){
  let user =JSON.parse(window.localStorage.getItem("user"));
  let ele = document.getElementById("cusId");
  ele.innerHTML=`${user.firstName} ${user.lastName}`;

})()