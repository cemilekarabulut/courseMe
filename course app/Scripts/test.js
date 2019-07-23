
function GetInstructers() {

    var x = document.getElementById("course").value
    var list1 = document.getElementById("ins");
    $.ajax({

        url: '/Course/getInstructor/' + x,
        data: { x: x },
        type: "POST",
        dataType: 'json',
        success: function (data) {
            $.each(data, function (i, item) {
            

                list1.options[i] = new Option(text = item.name, value=item.id);
                
            });}
    });
}
function pass_fail() {
    var str="#a"
    var numofstu = parseInt(document.getElementById("temp").innerHTML);

    for (i = 0; i < numofstu; i++) {
        $(str).show();

        str+="a";
    }
    $("#average").show();
    
}


//function pass_fail(button, model) {
//    var model = new UserViewModel(model);
//    var formRef = $(button).attr("data-ref")
//    $.ajax({

//        url: '/Course/pass_fail/' + model,
//        data: { model: model },
//        type: "POST",
//        error: function (req, status, error) {
//            // do something with error
//        }

//    });

//    function UserViewModel(model) {
//        this.Name = model.Name;
//        this.Role = model.Role;
//    }
   
//}