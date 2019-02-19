
    function focus_Mobile() {
        var resultObj=document.getElementById('result_Mobile');
        resultObj.innerHTML=" ";
        resultObj.style.color="blue";
       } 
       function blur_Mobile() {    
        var resultObj=document.getElementById('result_Mobile') 
        var pre=document.form.Mobile.value;
        var reg=/^1[3|5|7|8][0-9]{9}$/;
        if (pre=='') {
          resultObj.innerHTML="不能为空";
          resultObj.style.color="red";      
        }else if (!reg.test(pre)) {
          resultObj.innerHTML="不正确";  
        }else {
         resultObj.innerHTML="ok";
         resultObj.style.color="green";      
        }        
       }