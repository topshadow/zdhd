$(function(){
    $("#btnshare").click(function(){
        $(".f_mask1").hide();
        $('#choose_attr1').animate({height:'0'},[10000]);

        $("#posters").show();

        $("#closeBut").click(function(){
            $("#closeBut").parent().hide();
        })
    })
})


$(function(){
    $("#btnSave").click(function(){
    //	$("#Download").css("display","block");
        $("#Download").show();
    })

    $("#Download").click(function(){
        $("#Download").hide();
    })
})
