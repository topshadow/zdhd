$(document).ready(function(){
    $(".tabLi").click(function(){
        var i=$(this).index();
        $(this).addClass("selectLi").siblings().removeClass("selectLi");
    })
})